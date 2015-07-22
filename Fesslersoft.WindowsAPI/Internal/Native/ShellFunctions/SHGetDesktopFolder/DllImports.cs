#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHGetDesktopFolder
{
    internal static class DllImports
    {
        [DllImport("shell32.dll")]
        internal static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);
    }
}