#region

using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareAdd;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Helpers;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
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
        public static Enum.NetApiResult CreateNetworkShare(string servername, ShareInfo502 shareInfo502)
        {
            var nativeShareInfo502 = ShareInfo502.MapToNativeShareInfo502(shareInfo502);
            uint error = 0;
            return (Enum.NetApiResult) DllImports.NetShareAdd(servername, 502, ref nativeShareInfo502, out error);
        }
    }
}