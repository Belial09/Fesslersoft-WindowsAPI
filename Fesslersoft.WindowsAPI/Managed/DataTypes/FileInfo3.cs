#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Enum = Fesslersoft.WindowsAPI.Managed.Helpers.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    /// <summary>
    ///     Contains the identification number and other pertinent information about files, devices, and pipes. Descriptions
    ///     taken from https://msdn.microsoft.com/en-us/library/windows/desktop/bb525375(v=vs.85).aspx (FILE_INFO_3 structure).
    /// </summary>
    public sealed class FileInfo3
    {
        /// <summary>
        ///     Specifies a DWORD value that contains the identification number assigned to the resource when it is opened.
        /// </summary>
        /// <value>
        ///     The RessourceId.
        /// </value>
        public Int32 RessourceId { get; set; }

        /// <summary>
        ///     Specifies a DWORD value that contains the access permissions associated with the opening application. This member
        ///     can be one or more of the following values.
        /// </summary>
        /// <value>
        ///     The Permissions.
        /// </value>
        public Enum.SharePermissions Permission { get; set; }

        /// <summary>
        ///     Specifies a DWORD value that contains the number of file locks on the file, device, or pipe.
        /// </summary>
        /// <value>
        ///     The number of locks.
        /// </value>
        public Int32 NumberOfLocks { get; set; }

        /// <summary>
        ///     Pointer to a string that specifies which user (on servers that have user-level security) or which computer (on
        ///     servers that have share-level security) opened the resource. Note that Windows does not support share-level
        ///     security. This string is Unicode if _WIN32_WINNT or FORCE_UNICODE are defined.
        /// </summary>
        /// <value>
        ///     The username.
        /// </value>
        public String Username { get; set; }

        /// <summary>
        ///     Pointer to a string that specifies the path of the opened resource. This string is Unicode if _WIN32_WINNT or
        ///     FORCE_UNICODE are defined.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        public String Path { get; set; }

        /// <summary>
        ///     Maps the native FileInfo3 Structure to a managed FileInfo3 Class.
        /// </summary>
        /// <param name="fileInfo">The native source FileInfo3.</param>
        /// <returns>A Managed FileInfo3 Object.</returns>
        internal static FileInfo3 MapToFileInfo3(Structs.FileInfo3 fileInfo)
        {
            return new FileInfo3
            {
                RessourceId = fileInfo.SessionID,
                NumberOfLocks = fileInfo.NumLocks,
                Path = fileInfo.PathName,
                Permission = (Enum.SharePermissions) fileInfo.Permission,
                Username = fileInfo.UserName
            };
        }
    }
}