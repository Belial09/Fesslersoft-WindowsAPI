#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.NetworkShareManagementFunctions.NetShareSetInfo
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true)]
        internal static extern UInt32 NetShareSetInfo(String servername, String netname, UInt32 level, ref object buf, out UInt32 parm_err);
    }
}