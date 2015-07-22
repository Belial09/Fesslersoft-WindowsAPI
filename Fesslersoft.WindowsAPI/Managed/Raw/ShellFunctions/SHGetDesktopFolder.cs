#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Common.Interfaces;
using Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.SHGetDesktopFolder;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.ShellFunctions
{
    /// <summary>
    ///     SHGetDesktopFolder function
    /// </summary>
    public sealed class SHGetDesktopFolder
    {
        /// <summary>
        ///     Gets the desktop folder. Retrieves the IShellFolder interface for the desktop folder, which is the root of the
        ///     Shell's namespace.
        /// </summary>
        /// <returns>A Managed IShellFolder Object.</returns>
        public static IShellFolder GetDesktopFolder()
        {
            IShellFolder iShellFolder = null;
            IntPtr pUnkownDesktopFolder;
            var nResult = DllImports.SHGetDesktopFolder(out pUnkownDesktopFolder);
            return (IShellFolder) Marshal.GetTypedObjectForIUnknown(pUnkownDesktopFolder, typeof (IShellFolder));
        }
    }
}