#region

using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareSetInfo function
    /// </summary>
    public sealed class NetStatisticsGet
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
            return Statistics.GetStatistics(serverName, netName);
        }
    }
}