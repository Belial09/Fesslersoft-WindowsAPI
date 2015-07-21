#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFileGetInfo
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int NetFileGetInfo(
            [In, MarshalAs(UnmanagedType.LPWStr)] string servername,
            int fileid,
            int level,
            out IntPtr bufptr
            );
    }
}