#region

using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Managed.Helpers;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    /// <summary>
    ///     CONNECTION_INFO_1 structure: Contains the identification number of a connection, number of open files, connection
    ///     time, number of users on the connection, and the type of connection. All Descriptions are Taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb525373(v=vs.85).aspx (CONNECTION_INFO_1 structure).
    /// </summary>
    public class ConnectionInfo1
    {
        /// <summary>
        ///     Specifies a connection identification number.
        /// </summary>
        /// <value>
        ///     The ConnectionId.
        /// </value>
        public uint ConnectionId { get; set; }

        /// <summary>
        ///     A combination of values that specify the type of connection made from the local device name to the shared resource.
        /// </summary>
        /// <value>
        ///     The ConnectionType.
        /// </value>
        public Enum.ShareType ConnectionType { get; set; }

        /// <summary>
        ///     Specifies the number of files currently open as a result of the connection.
        /// </summary>
        /// <value>
        ///     The NumberOfOpens.
        /// </value>
        public uint NumberOfOpens { get; set; }

        /// <summary>
        ///     Specifies the number of users on the connection.
        /// </summary>
        /// <value>
        ///     The NumberOfUsers.
        /// </value>
        public uint NumberOfUsers { get; set; }

        /// <summary>
        ///     Specifies the number of seconds that the connection has been established.
        /// </summary>
        /// <value>
        ///     The ConnectionTime.
        /// </value>
        public uint ConnectionTime { get; set; }

        /// <summary>
        ///     Pointer to a string. If the server sharing the resource is running with user-level security, the UserName member
        ///     describes which user made the connection. If the server is running with share-level security, UserName describes
        ///     which computer (computername) made the connection. Note that Windows does not support share-level security. This
        ///     string is Unicode if _WIN32_WINNT or FORCE_UNICODE are defined.
        /// </summary>
        /// <value>
        ///     The UserName.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        ///     Pointer to a string that specifies either the share name of the server's shared resource or the computername of the
        ///     client. The value of this member depends on which name was specified as the qualifier parameter to the
        ///     NetConnectionEnum function. The name not specified in the qualifier parameter to NetConnectionEnum is automatically
        ///     supplied to NetName. This string is Unicode if _WIN32_WINNT or FORCE_UNICODE are defined.
        /// </summary>
        /// <value>
        ///     The NetName.
        /// </value>
        public string NetName { get; set; }

        /// <summary>
        ///     Maps the native ConnectionInfo1 Structure to a managed ConnectionInfo1 Class.
        /// </summary>
        /// <param name="connectionInfo1">The native source ConnectionInfo1.</param>
        /// <returns>A Managed ConnectionInfo1 Object.</returns>
        internal static ConnectionInfo1 MapToConnectionInfo1(Structs.ConnectionInfo1 connectionInfo1)
        {
            return new ConnectionInfo1
            {
                ConnectionId = connectionInfo1.coni1_id,
                NetName = connectionInfo1.coni1_netname,
                NumberOfOpens = connectionInfo1.coni1_num_opens,
                NumberOfUsers = connectionInfo1.coni1_num_users,
                ConnectionTime = connectionInfo1.coni1_time,
                ConnectionType = (Enum.ShareType) connectionInfo1.coni1_type,
                UserName = connectionInfo1.coni1_username
            };
        }
    }
}