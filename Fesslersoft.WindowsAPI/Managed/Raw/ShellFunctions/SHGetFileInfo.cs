#region

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHGetFileInfo;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.ShellFunctions
{
    /// <summary>
    ///     SystemIcons functions
    /// </summary>
    public sealed class SystemIcons
    {
        public enum FolderType
        {
            Closed,
            Open
        }

        public enum IconSize
        {
            Large,
            Small
        }

        private const uint ShgfiIcon = 0x000000100;
        private const uint ShgfiUsefileattributes = 0x000000010;
        private const uint ShgfiOpenicon = 0x000000002;
        private const uint ShgfiSmallicon = 0x000000001;
        private const uint ShgfiLargeicon = 0x000000000;
        private const uint FileAttributeDirectory = 0x00000010;

        /// <summary>
        ///     The current Windows default Folder Icon in the given Size (Large/Small) as System.Drawing.Icon.
        /// </summary>
        /// <param name="size">The Size of the Icon (Small or Large).</param>
        /// <param name="folderType">The folderTypeIcon (closed or Open).</param>
        /// <returns>The Folder Icon as System.Drawing.Icon.</returns>
        public static Icon GetDefaultDirectoryIcon(IconSize size, FolderType folderType)
        {
            var flags = ShgfiIcon | ShgfiUsefileattributes;
            if (FolderType.Open == folderType)
            {
                flags += ShgfiOpenicon;
            }
            if (IconSize.Small == size)
            {
                flags += ShgfiSmallicon;
            }
            else
            {
                flags += ShgfiLargeicon;
            }
            var shfi = new Structs.Shfileinfo();
            var res = DllImports.SHGetFileInfo(@"C:\Windows", FileAttributeDirectory, out shfi, (uint) Marshal.SizeOf(shfi), flags);
            if (res == IntPtr.Zero)
            {
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            Icon.FromHandle(shfi.hIcon);
            var icon = (Icon) Icon.FromHandle(shfi.hIcon).Clone();
            DllImports.DestroyIcon(shfi.hIcon);
            return icon;
        }
    }
}