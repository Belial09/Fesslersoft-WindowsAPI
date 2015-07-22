#region

using Fesslersoft.WindowsAPI.Common;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetFileClose function
    /// </summary>
    public sealed class NetFileClose
    {
        /// <summary>
        ///     Forces a resource to close. This function can be used when an error prevents closure by any other means. You should
        ///     use NetFileClose with caution because it does not write data cached on the client system to the file before closing
        ///     the file.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="id">Specifies the file identifier of the opened resource instance to close.</param>
        /// <returns>
        ///     If the function succeeds, the return value is NERR_Success. If the function fails, the return value can be one
        ///     of the following error codes. ERROR_ACCESS_DENIED or ERROR_FILE_NOT_FOUND
        /// </returns>
        public static Enum.NetApiResult CloseFileResource(string servername, int id)
        {
            return Files.CloseFileResource(servername, id);
        }
    }
}