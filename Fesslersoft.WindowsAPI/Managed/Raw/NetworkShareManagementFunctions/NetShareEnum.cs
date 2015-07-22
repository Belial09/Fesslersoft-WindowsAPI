#region

using System.Collections.Generic;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
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
        public static IEnumerable<ShareInfo2> GetShares(string server)
        {
            return Shares.GetShares(server);
        }
    }
}