#region

using Fesslersoft.WindowsAPI.Common;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareSetInfo function
    /// </summary>
    public sealed class NetShareSetInfo
    {
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
            return Shares.SetInfo(serverName, netName, shareInfo503);
        }
    }
}