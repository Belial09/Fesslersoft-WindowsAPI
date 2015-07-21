#region

using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionDel;
using Fesslersoft.WindowsAPI.Managed.Helpers;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetSessionDel function
    /// </summary>
    public sealed class NetSessionDel
    {
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
        public static Enum.NetApiResult DeleteSession(string server, string client, string user)
        {
            return ((Enum.NetApiResult) DllImports.NetSessionDel(server, client, user));
        }
    }
}