#region

using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
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
        public static SessionInfo2 GetSession(string servername, string clientame, string username)
        {
            return Sessions.GetSession(servername, clientame, username);
        }
    }
}