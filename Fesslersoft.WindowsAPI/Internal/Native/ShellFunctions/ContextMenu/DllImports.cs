#region

using System;
using System.Runtime.InteropServices;
using System.Text;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.ContextMenu
{
    internal static class DllImports
    {
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr CreatePopupMenu();

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern bool DestroyMenu(IntPtr hMenu);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

        [DllImport("shell32.dll")]
        internal static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);

        [DllImport("shlwapi.dll", EntryPoint = "StrRetToBuf", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern Int32 StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        internal static extern uint TrackPopupMenuEx(IntPtr hmenu, Enums.Tpm flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    }
}