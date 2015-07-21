#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetConnectionEnum;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetConnectionEnum function
    /// </summary>
    public sealed class NetConnectionEnum
    {
        /// <summary>
        ///     Lists all connections made to a shared resource on the server or all connections established from a particular
        ///     computer. If there is more than one user using this connection, then it is possible to get more than one structure
        ///     for the same connection, but with a different user name.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="shareNetName">
        ///     Pointer to a string that specifies a share name or computer name for the connections of
        ///     interest. If it is a share name, then all the connections made to that share name are listed. If it is a computer
        ///     name (for example, it starts with two backslash characters), then NetConnectionEnum lists all connections made from
        ///     that computer to the server specified. This string is Unicode if _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <returns>A IEnumerable of Managed ConnectionInfo1 Objects.</returns>
        public static IEnumerable<ConnectionInfo1> GetNetConnections(string server, string shareNetName)
        {
            var list = new List<ConnectionInfo1>();
            uint entriesRead = 0;
            uint totalEntries = 0;
            uint resumeHandle = 0;
            var pBuffer = IntPtr.Zero;

            var status = DllImports.NetConnectionEnum(Marshal.StringToCoTaskMemAuto(server), Marshal.StringToCoTaskMemAuto(shareNetName), 1, ref pBuffer, 0xFFFFFFFF, ref entriesRead, ref totalEntries, ref resumeHandle);
            if (status == 0 & entriesRead > 0)
            {
                var connectionInfo1Type = typeof (Structs.ConnectionInfo1);
                var offset = Marshal.SizeOf(connectionInfo1Type);
                for (int i = 0, item = pBuffer.ToInt32(); i < entriesRead; i++, item += offset)
                {
                    var pItem = new IntPtr(item);
                    var connectionInfo1 = ConnectionInfo1.MapToConnectionInfo1((Structs.ConnectionInfo1) Marshal.PtrToStructure(pItem, connectionInfo1Type));
                    list.Add(connectionInfo1);
                }
            }
            NetApiBufferFree.FreeBuffer(pBuffer);
            return list;
        }
    }
}