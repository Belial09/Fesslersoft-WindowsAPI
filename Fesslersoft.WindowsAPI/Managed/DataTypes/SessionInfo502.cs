#region

using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    public class SessionInfo502
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public uint NumberOfOpens { get; set; }
        public uint SecondsActive { get; set; }
        public uint SecondsIdle { get; set; }
        public uint UserFlags { get; set; }
        public string ClientType { get; set; }
        public string Transport { get; set; }

        internal static SessionInfo502 MapToSessionInfo502(Structs.SessionInfo502 sessionInfo)
        {
            return new SessionInfo502
            {
                ClientType = sessionInfo.ClientType,
                ComputerName = sessionInfo.ComputerName,
                NumberOfOpens = sessionInfo.NumOpens,
                SecondsActive = sessionInfo.SecondsActive,
                SecondsIdle = sessionInfo.SecondsIdle,
                Transport = sessionInfo.Transport,
                UserFlags = sessionInfo.UserFlags,
                UserName = sessionInfo.UserName
            };
        }
    }
}