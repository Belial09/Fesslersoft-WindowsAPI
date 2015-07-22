#region

using Fesslersoft.WindowsAPI.Common;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareAdd function
    /// </summary>
    public sealed class NetShareAdd
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
            return Shares.Create(servername, shareInfo502);
        }
    }
}