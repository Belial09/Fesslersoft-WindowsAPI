#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionGetInfo;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetSessionGetInfo function
    /// </summary>
    public sealed class NetSessionGetInfo
    {
        /// <summary>
        ///     Retrieves information about a session established between a particular server and workstation. Descriptions taken
        ///     from https://msdn.microsoft.com/en-us/library/windows/desktop/bb525383(v=vs.85).aspx (NetSessionGetInfo function).
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="clientame">
        ///     Pointer to a string that specifies the name of the computer session for which information is to
        ///     be returned. This parameter is required and cannot be NULL. For more information, see NetSessionEnum.
        /// </param>
        /// <param name="username">
        ///     Pointer to a string that specifies the name of the user whose session information is to be
        ///     returned. This parameter is required and cannot be NULL.
        /// </param>
        /// <returns></returns>
        public static SessionInfo2 GetSessionInfo(string servername, string clientame, string username)
        {
            var returnValue = new SessionInfo2();
            IntPtr pBuffer;
            var status = DllImports.NetSessionGetInfo(servername, clientame, username, 3, out pBuffer);
            if (status == 0)
            {
                var shareinfoType = typeof (Structs.SessionInfo2);
                var pItem = new IntPtr(pBuffer.ToInt32());
                var sessionInfo2 = (Structs.SessionInfo2) Marshal.PtrToStructure(pItem, shareinfoType);
                returnValue = SessionInfo2.MapToSessionInfo2(sessionInfo2);
                NetApiBufferFree.FreeBuffer(pBuffer);
            }
            return returnValue;
        }
    }
}