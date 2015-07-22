#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.NetworkShareManagementFunctions.NetShareDel
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true)]
        internal static extern uint NetShareDel(
            [MarshalAs(UnmanagedType.LPWStr)] string strServer,
            [MarshalAs(UnmanagedType.LPWStr)] string strNetName,
            Int32 reserved //must be 0
            );
    }
}