#region

using System;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHFileOperation;
using Enum = Fesslersoft.WindowsAPI.Common.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.ShellFunctions
{
    /// <summary>
    ///     Copies, moves, renames, or deletes a file system object. This function has been replaced in Windows Vista by
    ///     IFileOperation. Descriptions taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb762164(v=vs.85).aspx (SHFileOperation function).
    /// </summary>
    public sealed class ShFileOperation
    {
        /// <summary>
        ///     Send file silently to recycle bin.  Surpress dialog, surpress errors, delete if too large.
        /// </summary>
        /// <param name="path">Location of directory or file to recycle</param>
        public static bool MoveToRecycleBin(string path)
        {
            return Send(path, Enum.FileOperationFlags.FOF_NOCONFIRMATION | Enum.FileOperationFlags.FOF_NOERRORUI | Enum.FileOperationFlags.FOF_SILENT);
        }

        /// <summary>
        ///     Send file silently to recycle bin.  Surpress dialog, surpress errors, delete if too large.
        /// </summary>
        /// <param name="path">Location of directory or file to recycle</param>
        public static bool MoveToRecycleBin(string path, Enum.FileOperationFlags flags)
        {
            return Send(path, flags);
        }

        /// <summary>
        ///     Send file to recycle bin
        /// </summary>
        /// <param name="path">Location of directory or file to recycle</param>
        /// <param name="flags">FileOperationFlags to add in addition to FOF_ALLOWUNDO</param>
        internal static bool Send(string path, Enum.FileOperationFlags flags)
        {
            try
            {
                var fs = new ShFileOpStruct
                {
                    wFunc = Enum.FileOperationType.FO_DELETE,
                    pFrom = path + '\0' + '\0',
                    fFlags = Enum.FileOperationFlags.FOF_ALLOWUNDO | flags
                };
                var nativeShFileOpStruct = ShFileOpStruct.MapToNativeShFileOpStruct(fs);
                DllImports.SHFileOperation(ref nativeShFileOpStruct);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}