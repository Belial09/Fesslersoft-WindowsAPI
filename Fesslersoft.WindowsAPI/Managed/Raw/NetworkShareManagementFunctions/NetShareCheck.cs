﻿#region

using Fesslersoft.WindowsAPI.Common;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
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
        public static Enum.NetError Exists(string servername, string localpath, out Enum.ShareType shareType)
        {
            return Shares.Exists(servername, localpath, out shareType);
        }
    }
}