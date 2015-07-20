#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetConnectionEnum
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", EntryPoint = "NetConnectionEnum")]
        internal static extern uint NetConnectionEnum(
                IntPtr ServerName,
                IntPtr Qualifier,
                uint Level,
                ref IntPtr BufPtr,
                uint PrefMaxLen,
                ref uint EntriesRead,
                ref uint TotalEntries,
                ref uint ResumeHandle); 
    }
}