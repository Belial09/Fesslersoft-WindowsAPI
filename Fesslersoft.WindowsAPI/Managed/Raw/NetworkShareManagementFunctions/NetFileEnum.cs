#region

using System.Collections.Generic;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetFileEnum function
    /// </summary>
    public sealed class NetFileEnum
    {
        /// <summary>
        ///     Returns information about some or all open files on a server, depending on the parameters specified.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <returns>A IEnumerable of Managed FileInfo3 Objects.</returns>
        public static IEnumerable<FileInfo3> GetNetFileList(string server)
        {
            return Files.GetNetFileList(server);
        }
    }
}