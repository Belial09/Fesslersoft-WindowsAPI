#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionGetInfo;
using Fesslersoft.WindowsAPI.Managed.Networking.ManagementFunctions;
using Enum = Fesslersoft.WindowsAPI.Common.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions
{
    public sealed class Sessions
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
        public static SessionInfo2 GetSession(string servername, string clientame, string username)
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
                ApiBuffer.FreeBuffer(pBuffer);
            }
            return returnValue;
        }

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
        public static IEnumerable<SessionInfo502> GetSessions(string server, string clientName, string userName)
        {
            var list = new List<SessionInfo502>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            IntPtr pBuffer;
            var status = Internal.Native.NetworkShareManagementFunctions.NetSessionEnum.DllImports.NetSessionEnum(server, null, null, 502, out pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
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
            ApiBuffer.FreeBuffer(pBuffer);
            return list;
        }

        /// <summary>
        ///     Ends a network session between a server and a workstation.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="client">
        ///     Pointer to a string that specifies the computer name of the client to disconnect. If the
        ///     UncClientName parameter is NULL, then all the sessions of the user identified by the username parameter will be
        ///     deleted on the server specified by the servername parameter. For more information, see NetSessionEnum.
        /// </param>
        /// <param name="user">
        ///     Pointer to a string that specifies the name of the user whose session is to be terminated. If this
        ///     parameter is NULL, all users' sessions from the client specified by the UncClientName parameter are to be
        ///     terminated.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is NERR_Success. If the function fails, the return value can be one
        ///     of the following error codes: ERROR_ACCESS_DENIED, ERROR_INVALID_PARAMETER, ERROR_NOT_ENOUGH_MEMORY,
        ///     NERR_ClientNameNotFound.
        /// </returns>
        public static Enum.NetApiResult KillSession(string server, string client, string user)
        {
            return ((Enum.NetApiResult) Internal.Native.NetworkShareManagementFunctions.NetSessionDel.DllImports.NetSessionDel(server, client, user));
        }
    }
}