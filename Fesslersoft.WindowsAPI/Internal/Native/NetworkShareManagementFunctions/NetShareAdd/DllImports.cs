#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareAdd
{
    internal static class DllImports
    {
        [DllImport("Netapi32.dll")]
        internal static extern uint NetShareAdd(
            [MarshalAs(UnmanagedType.LPWStr)] string strServer,
            Int32 dwLevel,
            ref Structs.ShareInfo502 buf,
            out uint parm_err
            );
    }
}