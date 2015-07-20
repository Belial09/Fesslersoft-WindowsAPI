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
        // Takes a STRRET structure returned by IShellFolder::GetDisplayNameOf, converts it to a string, and places the result in a buffer. 

        // The DestroyMenu function destroys the specified menu and frees any memory that the menu occupies.
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr CreatePopupMenu();

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern bool DestroyMenu(IntPtr hMenu);

        // Retrieves the IShellFolder interface for the desktop folder, which is the root of the Shell's namespace.

        // Determines the default menu item on the specified menu
        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetMenuDefaultItem(IntPtr hMenu, bool fByPos, uint gmdiFlags);

        [DllImport("shell32.dll")]
        internal static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);

        [DllImport("shlwapi.dll", EntryPoint = "StrRetToBuf", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern Int32 StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

        // The CreatePopupMenu function creates a drop-down menu, submenu, or shortcut menu. The menu is initially empty. You can insert or append menu items by using the InsertMenuItem function. You can also use the InsertMenu function to insert menu items and the AppendMenu function to append menu items.

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        internal static extern uint TrackPopupMenuEx(IntPtr hmenu, Enums.TPM flags, int x, int y, IntPtr hwnd, IntPtr lptpm);
    }
}