#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.NetworkShareManagementFunctions.NetShareGetInfo
{
    internal static class DllImports
    {
        [DllImport("Netapi32.dll", SetLastError = true)]
        internal static extern int NetShareGetInfo(
            [MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [MarshalAs(UnmanagedType.LPWStr)] string netName,
            Int32 level,
            out IntPtr bufPtr);
    }
}