#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHGetFileInfo
{
    internal static class DllImports
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, out Structs.Shfileinfo psfi, uint cbFileInfo, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DestroyIcon(IntPtr hIcon);
    }
}