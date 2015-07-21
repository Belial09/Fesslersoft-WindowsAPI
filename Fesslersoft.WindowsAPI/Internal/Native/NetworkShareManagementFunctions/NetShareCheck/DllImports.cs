#region

using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareCheck
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true)]
        internal static extern uint NetShareCheck(
            [MarshalAs(UnmanagedType.LPWStr)] string servername,
            [MarshalAs(UnmanagedType.LPWStr)] string device,
            out uint type
            );
    }
}