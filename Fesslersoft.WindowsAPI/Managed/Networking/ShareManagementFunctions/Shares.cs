#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareAdd;
using Fesslersoft.WindowsAPI.Managed.Networking.ManagementFunctions;
using Fesslersoft.WindowsAPI.Managed.Raw.NetworkManagementFunctions;
using Enum = Fesslersoft.WindowsAPI.Common.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions
{
    /// <summary>
    ///     Wrapped Windows API Networkshare Management functions.
    /// </summary>
    public sealed class Shares
    {
        /// <summary>
        ///     Shares a server resource.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="shareInfo502">
        ///     Specifies the information level of the data. This parameter can be one of the following
        ///     values.
        /// </param>
        /// <returns>Returns a NetApiResult Enumeration.</returns>
        public static Enum.NetApiResult Create(string servername, ShareInfo502 shareInfo502)
        {
            var nativeShareInfo502 = ShareInfo502.MapToNativeShareInfo502(shareInfo502);
            uint error = 0;
            return (Enum.NetApiResult) DllImports.NetShareAdd(servername, 502, ref nativeShareInfo502, out error);
        }

        /// <summary>
        ///     Deletes a share name from a server's list of shared resources, disconnecting all connections to the shared
        ///     resource.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="sharename">
        ///     Pointer to a string that specifies the name of the share to delete. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <returns>Returns a NetApiResult Enumeration.</returns>
        public static Enum.NetApiResult Delete(string servername, string sharename)
        {
            return (Enum.NetApiResult) NetworkShareManagementFunctions.NetShareDel.DllImports.NetShareDel(servername, sharename, 0);
        }

        /// <summary>
        ///     Checks whether or not a server is sharing a device.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="localpath">Pointer to a string that specifies the name of the device to check for shared access.</param>
        /// <param name="shareType">
        ///     Pointer to a variable that receives a bitmask of flags that specify the type of the shared
        ///     device. This parameter is set only if the function returns successfully.
        /// </param>
        /// <returns>Return a NetError Enumeration.</returns>
        public static Enum.NetError Exists(string servername, string localpath, out Enum.ShareType shareType)
        {
            uint type = 0;
            var result = (Enum.NetError) Internal.Native.NetworkShareManagementFunctions.NetShareCheck.DllImports.NetShareCheck(servername, localpath, out type);
            shareType = (Enum.ShareType) type;
            return result;
        }

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
        public static IEnumerable<ConnectionInfo1> GetConnections(string server, string shareNetName)
        {
            var list = new List<ConnectionInfo1>();
            uint entriesRead = 0;
            uint totalEntries = 0;
            uint resumeHandle = 0;
            var pBuffer = IntPtr.Zero;

            var status = Internal.Native.NetworkShareManagementFunctions.NetConnectionEnum.DllImports.NetConnectionEnum(Marshal.StringToCoTaskMemAuto(server), Marshal.StringToCoTaskMemAuto(shareNetName), 1, ref pBuffer, 0xFFFFFFFF, ref entriesRead, ref totalEntries, ref resumeHandle);
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

        /// <summary>
        ///     Retrieves information about a particular shared resource on a server.
        /// </summary>
        /// <param name="serverName">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="netName">Pointer to a string that specifies the name of the share for which to return information.</param>
        /// <returns>A managed ShareInfo503 Object.</returns>
        public static ShareInfo503 GetInfo(string serverName, string netName)
        {
            var returnValue = new ShareInfo503();
            IntPtr pBuffer;
            var status = NetworkShareManagementFunctions.NetShareGetInfo.DllImports.NetShareGetInfo(serverName, netName, 503, out pBuffer);
            if (status == 0)
            {
                var shareinfoType = typeof (Structs.FileInfo3);
                var pItem = new IntPtr(pBuffer.ToInt32());
                var shareInfo503 = (Structs.ShareInfo503) Marshal.PtrToStructure(pItem, shareinfoType);
                returnValue = ShareInfo503.MapToShareInfo503(shareInfo503);
                ApiBuffer.FreeBuffer(pBuffer);
            }
            return returnValue;
        }

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
        public static IEnumerable<ShareInfo2> GetShares(string server)
        {
            var list = new List<ShareInfo2>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            IntPtr pBuffer;
            var status = Internal.Native.NetworkShareManagementFunctions.NetShareEnum.DllImports.NetShareEnum(server, 2, out pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
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

        /// <summary>
        ///     Retrieves information about a particular shared resource on a server.
        /// </summary>
        /// <param name="serverName">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="netName">Pointer to a string that specifies the name of the share for which to return information.</param>
        /// <param name="shareInfo503">
        ///     Pointer to the buffer that specifies the data. The format of this data depends on the value
        ///     of the level parameter. For more information, see Network Management Function Buffers.
        /// </param>
        /// <returns>Returns a NetApiResult Enumeration.</returns>
        public static Enum.NetApiResult SetInfo(string serverName, string netName, ShareInfo503 shareInfo503)
        {
            uint error = 0;
            Object nativeShareInfo503 = ShareInfo503.MapToNativeShareInfo503(shareInfo503);
            return (Enum.NetApiResult) NetworkShareManagementFunctions.NetShareSetInfo.DllImports.NetShareSetInfo(serverName, netName, 503, ref nativeShareInfo503, out error);
        }
    }
}