#region

using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFile;
using Fesslersoft.WindowsAPI.Managed.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    public sealed class NetFileClose
    {
        public static Enums.NetApiResult CloseFile(string servername, int id)
        {
            return (Enums.NetApiResult) ((uint) DllImports.NetFileClose(servername, id));
        }
    }
}