#region

using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareCheck;
using Fesslersoft.WindowsAPI.Managed.Helpers;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareCheck function
    /// </summary>
    public sealed class NetShareCheck
    {
        /// <summary>
        ///     Checks whether or not a server is sharing a device.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="localpath">Pointer to a string that specifies the name of the device to check for shared access.</param>
        /// <param name="shareType">
        ///     Pointer to a variable that receives a bitmask of flags that specify the type of the shared
        ///     device. This parameter is set only if the function returns successfully.
        /// </param>
        /// <returns>Return a NetError Enumeration.</returns>
        public static Enum.NetError CheckShare(string servername, string localpath, out Enum.ShareType shareType)
        {
            uint type = 0;
            var result = (Enum.NetError) DllImports.NetShareCheck(servername, localpath, out type);
            shareType = (Enum.ShareType) type;
            return result;
        }
    }
}