#region

using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionDel;
using Fesslersoft.WindowsAPI.Managed.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    public sealed class NetSessionDel
    {
        public static Enums.NetApiResult DeleteSession(string server, string client, string user)
        {
            return ((Enums.NetApiResult) DllImports.NetSessionDel(server, client, user));
        }
    }
}