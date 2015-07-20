#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkManagementFunctions.APIBufferFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions
{
    internal sealed class ApiBufferFunctions
    {
        internal static void NetApiBufferFree(IntPtr buffer)
        {
            DllImports.NetApiBufferFree(buffer);
        }
    }
}