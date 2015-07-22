#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.NetworkShareManagementFunctions.NetStatisticsGet
{
    internal static class DllImports
    {
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        internal static extern int NetStatisticsGet(
            [MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [MarshalAs(UnmanagedType.LPWStr)] string service,
            int level,
            int options,
            out IntPtr BufPtr);
    }
}