#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkManagementFunctions.APIBufferFunctions
{
    internal static class DllImports
    {
        [DllImport("Netapi32.dll", SetLastError = true)]
        internal static extern int NetApiBufferFree(IntPtr buffer);
    }
}