namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    public class Enums
    {
        public enum NetApiResult : uint
        {
            NerrSuccess = 0,
            NerrInvalidComputer = 2351,
            NerrNotPrimary = 2226,
            NerrSpeGroupOp = 2234,
            NerrLastAdmin = 2452,
            NerrBadPassword = 2203,
            NerrPasswordTooShort = 2245,
            NerrUserNotFound = 2221,
            ErrorAccessDenied = 5,
            ErrorNotEnoughMemory = 8,
            ErrorInvalidParameter = 87,
            ErrorInvalidName = 123,
            ErrorInvalidLevel = 124,
            ErrorMoreData = 234,
            ErrorSessionCredentialConflict = 1219,
            RpcSServerUnavailable = 2147944122,
            RpcERemoteDisabled = 2147549468
        }
    }
}