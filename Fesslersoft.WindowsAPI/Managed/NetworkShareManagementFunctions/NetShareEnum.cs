#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareEnum;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareEnum function
    /// </summary>
    public sealed class NetShareEnum
    {
        /// <summary>
        ///     Retrieves information about each shared resource on a server.You can also use the WNetEnumResource function to
        ///     retrieve resource information. However, WNetEnumResource does not enumerate hidden shares or users connected to a
        ///     share.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <returns>A IEnumerable of managed ShareInfo2 Objects.</returns>
        public static IEnumerable<ShareInfo2> GetNetShares(string server)
        {
            var list = new List<ShareInfo2>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            IntPtr pBuffer;
            var status = DllImports.NetShareEnum(server, 2, out pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
            if (status == 0 & entriesRead > 0)
            {
                var shareinfoType = typeof (Structs.ShareInfo2);
                var offset = Marshal.SizeOf(shareinfoType);
                for (int i = 0, item = pBuffer.ToInt32(); i < entriesRead; i++, item += offset)
                {
                    var pItem = new IntPtr(item);
                    var shareInfo2 = (Structs.ShareInfo2) Marshal.PtrToStructure(pItem, shareinfoType);
                    var netShareInfoResult = ShareInfo2.MapToSessionInfo502(shareInfo2);
                    list.Add(netShareInfoResult);
                }
            }
            NetApiBufferFree.FreeBuffer(pBuffer);
            return list;
        }
    }
}