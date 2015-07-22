#region

using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Common.DataTypes
{
    /// <summary>
    ///     Contains information about the session, including name of the computer; name of the user; open files, pipes, and
    ///     devices on the computer; and the name of the transport the client is using. Descriptions taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb525401(v=vs.85).aspx (SESSION_INFO_502 structure).
    /// </summary>
    public class SessionInfo502
    {
        /// <summary>
        ///     Pointer to a Unicode string specifying the name of the computer that established the session. This string cannot
        ///     contain a backslash (\).
        /// </summary>
        /// <value>
        ///     The name of the computer.
        /// </value>
        public string ComputerName { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string specifying the name of the user who established the session.
        /// </summary>
        /// <value>
        ///     The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        ///     Specifies the number of files, devices, and pipes opened during the session.
        /// </summary>
        /// <value>
        ///     The number of opens.
        /// </value>
        public uint NumberOfOpens { get; set; }

        /// <summary>
        ///     Specifies the number of seconds the session has been active.
        /// </summary>
        /// <value>
        ///     The seconds active.
        /// </value>
        public uint SecondsActive { get; set; }

        /// <summary>
        ///     Specifies the number of seconds the session has been idle.
        /// </summary>
        /// <value>
        ///     The seconds idle.
        /// </value>
        public uint SecondsIdle { get; set; }

        /// <summary>
        ///     Specifies a value that describes how the user established the session. This member can be one of the following
        ///     values.
        /// </summary>
        /// <value>
        ///     The user flags.
        /// </value>
        public Enum.SessionUserFlags UserFlags { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string that specifies the type of client that established the session. Following are the
        ///     defined types for LAN Manager servers.
        /// </summary>
        /// <value>
        ///     The type of the client.
        /// </value>
        public string ClientType { get; set; }

        /// <summary>
        ///     Specifies the name of the transport that the client is using to communicate with the server.
        /// </summary>
        /// <value>
        ///     The transport.
        /// </value>
        public string Transport { get; set; }

        /// <summary>
        ///     Maps the native SessionInfo502 Structure to a managed SessionInfo502 Class.
        /// </summary>
        /// <param name="sessionInfo">The native source SessionInfo502.</param>
        /// <returns>A managed SessionInfo502 Object.</returns>
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
                UserFlags = (Enum.SessionUserFlags) sessionInfo.UserFlags,
                UserName = sessionInfo.UserName
            };
        }
    }
}