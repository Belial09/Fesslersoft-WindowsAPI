#region

using System.Collections.Generic;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
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
        public static IEnumerable<ConnectionInfo1> GetConnections(string server, string shareNetName)
        {
            return Shares.GetConnections(server, shareNetName);
        }
    }
}