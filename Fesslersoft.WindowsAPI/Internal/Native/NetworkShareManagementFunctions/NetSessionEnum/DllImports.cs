#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionEnum
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true)]
        internal static extern int NetSessionEnum
            (
            [In, MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string uncClientName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string userName,
            Int32 level,
            out IntPtr buffer,
            int prefmaxlen,
            out int entriesRead,
            out int totalEntries,
            ref int resumeHandle
            );
    }
}