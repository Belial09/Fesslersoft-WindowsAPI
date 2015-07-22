#region

using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareGetInfo function
    /// </summary>
    public sealed class NetShareGetInfo
    {
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
            return Shares.GetInfo(serverName, netName);
        }
    }
}