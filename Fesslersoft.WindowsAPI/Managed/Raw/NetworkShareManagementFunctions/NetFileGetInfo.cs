#region

using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetFileGetInfo function
    /// </summary>
    public sealed class NetFileGetInfo
    {
        /// <summary>
        ///     Retrieves information about a particular opening of a server resource. Descriptions taken from
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb525379(v=vs.85).aspx (NetFileGetInfo function).
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="fileid">
        ///     Specifies the file identifier of the open resource for which to return information. The value of
        ///     this parameter must have been returned in a previous enumeration call. For more information, see the following
        ///     Remarks section.
        /// </param>
        /// <returns></returns>
        public static FileInfo3 GetFileInfo(string servername, int fileid)
        {
            return Files.GetFileInfo(servername, fileid);
        }
    }
}