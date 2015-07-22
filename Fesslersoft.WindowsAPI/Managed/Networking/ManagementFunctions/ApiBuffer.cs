#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkManagementFunctions.APIBufferFunctions;
using Enum = Fesslersoft.WindowsAPI.Common.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Networking.ManagementFunctions
{
    public sealed class ApiBuffer
    {
        /// <summary>
        ///     The FreeBuffer function frees the memory that the NetApiBufferAllocate function allocates. Applications should also
        ///     call FreeBuffer to free the memory that other network management functions use internally to return information.
        /// </summary>
        /// <param name="buffer">
        ///     A pointer to a buffer returned previously by another network management function or memory
        ///     allocated by calling the NetApiBufferAllocate function.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is NERR_Success. If the function fails, the return value is a
        ///     system error code. For a list of error codes, see System Error Codes.
        /// </returns>
        public static Enum.NetApiResult FreeBuffer(IntPtr buffer)
        {
            return (Enum.NetApiResult) DllImports.NetApiBufferFree(buffer);
        }
    }
}