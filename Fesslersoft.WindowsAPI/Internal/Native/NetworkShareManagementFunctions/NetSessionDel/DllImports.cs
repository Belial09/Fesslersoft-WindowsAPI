#region

using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionDel
{
    internal static class DllImports
    {
        [DllImport("NetApi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern uint NetSessionDel(
            string serverName,
            string uncClientName,
            string userName);
    }
}