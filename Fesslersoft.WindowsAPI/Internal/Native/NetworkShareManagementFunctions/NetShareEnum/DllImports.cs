#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetShareEnum
{
    internal static class DllImports
    {
        [DllImport("netapi32", CharSet = CharSet.Unicode)]
        internal static extern int NetShareEnum(string serverName, int level, out IntPtr buffer, int prefMaxLength, out int entriesRead, out int totalEntries, ref int resumeHandle);
    }
}