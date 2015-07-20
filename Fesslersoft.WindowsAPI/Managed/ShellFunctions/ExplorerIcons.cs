using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHGetFileInfo;

namespace Fesslersoft.WindowsAPI.Managed.ShellFunctions
{
    public sealed class SystemIcons
    {
        private const uint ShgfiIcon = 0x000000100;
        private const uint ShgfiUsefileattributes = 0x000000010;
        private const uint ShgfiOpenicon = 0x000000002;
        private const uint ShgfiSmallicon = 0x000000001;
        private const uint ShgfiLargeicon = 0x000000000;
        private const uint FileAttributeDirectory = 0x00000010;

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

        public static Icon GetDefaultDirectoryIcon(IconSize size, FolderType folderType)
        {    
            uint flags = ShgfiIcon | ShgfiUsefileattributes;
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
            var res = DllImports.SHGetFileInfo(@"C:\Windows",FileAttributeDirectory,out shfi,(uint)Marshal.SizeOf(shfi),flags);
            if (res == IntPtr.Zero)
            {
                throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
            }
            Icon.FromHandle(shfi.hIcon);
            var icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();
            DllImports.DestroyIcon(shfi.hIcon);        
            return icon;
        }
    }
}
