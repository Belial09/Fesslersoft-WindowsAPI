#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Common.DataTypes
{
    /// <summary>
    ///     Copies, moves, renames, or deletes a file system object. This function has been replaced in Windows Vista by
    ///     IFileOperation. Descriptions taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb762164(v=vs.85).aspx (SHFileOperation function).
    /// </summary>
    public sealed class ShFileOpStruct
    {
        /// <summary>
        ///     A window handle to the dialog box to display information about the status of the file operation.
        /// </summary>
        /// <value>
        ///     The HWND.
        /// </value>
        public IntPtr hwnd { get; private set; }

        /// <summary>
        ///     A value that indicates which operation to perform. One of the following values:
        /// </summary>
        /// <value>
        ///     The w function.
        /// </value>
        public Enum.FileOperationType wFunc { get; set; }

        /// <summary>
        ///     Note  This string must be double-null terminated. A pointer to one or more source file names. These names should be
        ///     fully qualified paths to prevent unexpected results. Standard MS-DOS wildcard characters, such as "*", are
        ///     permitted only in the file-name position. Using a wildcard character elsewhere in the string will lead to
        ///     unpredictable results. Although this member is declared as a single null-terminated string, it is actually a buffer
        ///     that can hold multiple null-delimited file names. Each file name is terminated by a single NULL character. The last
        ///     file name is terminated with a double NULL character ("\0\0") to indicate the end of the buffer.
        /// </summary>
        /// <value>
        ///     The p from.
        /// </value>
        public string pFrom { get; set; }

        /// <summary>
        ///     Note  This string must be double-null terminated. A pointer to the destination file or directory name. This
        ///     parameter must be set to NULL if it is not used. Wildcard characters are not allowed. Their use will lead to
        ///     unpredictable results. Like pFrom, the pTo member is also a double-null terminated string and is handled in much
        ///     the same way. However, pTo must meet the following specifications: Wildcard characters are not supported. Copy and
        ///     Move operations can specify destination directories that do not exist. In those cases, the system attempts to
        ///     create them and normally displays a dialog box to ask the user if they want to create the new directory. To
        ///     suppress this dialog box and have the directories created silently, set the FOF_NOCONFIRMMKDIR flag in fFlags. For
        ///     Copy and Move operations, the buffer can contain multiple destination file names if the fFlags member specifies
        ///     FOF_MULTIDESTFILES. Pack multiple names into the pTo string in the same way as for pFrom. Use fully qualified
        ///     paths. Using relative paths is not prohibited, but can have unpredictable results.
        /// </summary>
        /// <value>
        ///     The p to.
        /// </value>
        public string pTo { get; private set; }

        /// <summary>
        ///     Flags that control the file operation. This member can take a combination of the following flags.
        /// </summary>
        /// <value>
        ///     The f flags.
        /// </value>
        public Enum.FileOperationFlags fFlags { get; set; }

        /// <summary>
        ///     When the function returns, this member contains TRUE if any file operations were aborted before they were
        ///     completed; otherwise, FALSE. An operation can be manually aborted by the user through UI or it can be silently
        ///     aborted by the system if the FOF_NOERRORUI or FOF_NOCONFIRMATION flags were set.
        /// </summary>
        /// <value>
        ///     <c>true</c> if [f any operations aborted]; otherwise, <c>false</c>.
        /// </value>
        public bool fAnyOperationsAborted { get; private set; }

        /// <summary>
        ///     When the function returns, this member contains a handle to a name mapping object that contains the old and new
        ///     names of the renamed files. This member is used only if the fFlags member includes the FOF_WANTMAPPINGHANDLE flag.
        ///     See Remarks for more details.
        /// </summary>
        /// <value>
        ///     The h name mappings.
        /// </value>
        public IntPtr hNameMappings { get; private set; }

        /// <summary>
        ///     A pointer to the title of a progress dialog box. This is a null-terminated string. This member is used only if
        ///     fFlags includes the FOF_SIMPLEPROGRESS flag.
        /// </summary>
        /// <value>
        ///     The LPSZ progress title.
        /// </value>
        public string lpszProgressTitle { get; private set; }

        /// <summary>
        ///     Maps the managed ShFileOpStruct Object to a native SHFILEOPSTRUCT Struct.
        /// </summary>
        /// <param name="fs">The managed source ShFileOpStruct Object.</param>
        /// <returns>A native SHFILEOPSTRUCT Struct.</returns>
        internal static Structs.SHFILEOPSTRUCT MapToNativeShFileOpStruct(ShFileOpStruct fs)
        {
            return new Structs.SHFILEOPSTRUCT
            {
                fFlags = (Enums.FileOperationFlags) fs.fFlags,
                pFrom = fs.pFrom,
                wFunc = (Enums.FileOperationType) fs.wFunc
            };
        }
    }
}