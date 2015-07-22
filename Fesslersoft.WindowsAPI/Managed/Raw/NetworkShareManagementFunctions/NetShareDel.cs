#region

using Fesslersoft.WindowsAPI.Common;
using Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Raw.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetShareDel function
    /// </summary>
    public sealed class NetShareDel
    {
        /// <summary>
        ///     Deletes a share name from a server's list of shared resources, disconnecting all connections to the shared
        ///     resource. The extended function DeleteEx allows the caller to specify a SHARE_INFO_0, SHARE_INFO_1, SHARE_INFO_2,
        ///     SHARE_INFO_502, or SHARE_INFO_503 structure.
        /// </summary>
        /// <param name="servername">The servername.</param>
        /// <param name="sharename">The sharename.</param>
        /// <returns></returns>
        public static Enum.NetApiResult Delete(string servername, string sharename)
        {
            return Shares.Delete(servername, sharename);
        }
    }
}