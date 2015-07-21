#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionEnum;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetSessionEnum function
    /// </summary>
    public sealed class NetSessionEnum
    {
        /// <summary>
        ///     Provides information about sessions established on a server.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="clientName">
        ///     Pointer to a string that specifies the name of the computer session for which information is
        ///     to be returned. If this parameter is NULL, NetSessionEnum returns information for all computer sessions on the
        ///     server.
        /// </param>
        /// <param name="userName">
        ///     Pointer to a string that specifies the name of the user for which information is to be returned.
        ///     If this parameter is NULL, NetSessionEnum returns information for all users.
        /// </param>
        /// <returns>A Ienumerable of managed SessionInfo502 Objects.</returns>
        public static IEnumerable<SessionInfo502> GetNetSessions(string server, string clientName, string userName)
        {
            var list = new List<SessionInfo502>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            IntPtr pBuffer;
            var status = DllImports.NetSessionEnum(server, null, null, 502, out pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
            if (status == 0 & entriesRead > 0)
            {
                var shareinfoType = typeof (Structs.SessionInfo502);
                var offset = Marshal.SizeOf(shareinfoType);
                for (int i = 0, item = pBuffer.ToInt32(); i < entriesRead; i++, item += offset)
                {
                    var pItem = new IntPtr(item);
                    var sessionInfo502 = (Structs.SessionInfo502) Marshal.PtrToStructure(pItem, shareinfoType);
                    var netSessionEnumResult = SessionInfo502.MapToSessionInfo502(sessionInfo502);
                    list.Add(netSessionEnumResult);
                }
            }
            NetApiBufferFree.FreeBuffer(pBuffer);
            return list;
        }
    }
}