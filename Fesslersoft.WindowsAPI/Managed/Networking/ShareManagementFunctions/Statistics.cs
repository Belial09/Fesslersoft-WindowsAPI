#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ManagementFunctions;
using Fesslersoft.WindowsAPI.NetworkShareManagementFunctions.NetShareGetInfo;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions
{
    /// <summary>
    ///     NetStatisticsGet function
    /// </summary>
    public sealed class Statistics
    {
        /// <summary>
        ///     Retrieves operating statistics for a service. Currently, only the workstation and server services are supported.
        /// </summary>
        /// <param name="serverName">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the server on which the function
        ///     is to execute. If this parameter is NULL, the local computer is used.
        /// </param>
        /// <param name="netName">
        ///     Pointer to a string that specifies the name of the service about which to get the statistics.
        ///     Only the values SERVICE_SERVER and SERVICE_WORKSTATION are currently allowed.
        /// </param>
        /// <returns>
        ///     If the function succeeds, the return value is NERR_Success. If the function fails, the return value is a
        ///     system error code. For a list of error codes, see System Error Codes.
        /// </returns>
        public static Statworkstation0 GetStatistics(string serverName, string netName)
        {
            var returnValue = new Statworkstation0();
            IntPtr pBuffer;
            var status = DllImports.NetShareGetInfo(serverName, netName, 503, out pBuffer);
            if (status == 0)
            {
                var shareinfoType = typeof (Structs.StatWorkstation0);
                var pItem = new IntPtr(pBuffer.ToInt32());
                var statworkstation0 = (Structs.StatWorkstation0) Marshal.PtrToStructure(pItem, shareinfoType);
                returnValue = Statworkstation0.MapToStatworkstation0(statworkstation0);
                ApiBuffer.FreeBuffer(pBuffer);
            }
            return returnValue;
        }
    }
}