#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFile
{
    internal static class DllImports
    {
        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int NetFileClose(
            string servername,
            int id);

        [DllImport("netapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int NetFileEnum(
            string serverName,
            string basePath,
            string userName,
            int level,
            ref IntPtr buffer,
            int prefMaxLength,
            out int entriesRead,
            out int totalEntries,
            ref int resumeHandle
            );
    }
}