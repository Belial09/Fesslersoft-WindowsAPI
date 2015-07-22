#region

using System.Collections.Generic;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
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
        public static IEnumerable<SessionInfo502> GetSessions(string server, string clientName, string userName)
        {
            return Sessions.GetSessions(server, clientName, userName);
        }
    }
}