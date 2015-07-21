#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionGetInfo
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true)]
        internal static extern int NetSessionGetInfo
            (
            [In, MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string uncClientName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string userName,
            Int32 level,
            out IntPtr buffer
            );
    }
}