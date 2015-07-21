namespace Fesslersoft.WindowsAPI.Managed.Helpers
{
    /// <summary>
    ///     Collection of Enumerations, used by the managed Classes.
    /// </summary>
    public static class Enum
    {
        public enum NetApiResult : uint
        {
            /// <summary>
            ///     The operation completed successfully.
            /// </summary>
            NerrSuccess = 0,

            /// <summary>
            ///     This computer name is invalid.
            /// </summary>
            NerrInvalidComputer = 2351,

            /// <summary>
            ///     This operation is only allowed on the primary domain controller of the domain.
            /// </summary>
            NerrNotPrimary = 2226,

            /// <summary>
            ///     This operation is not allowed on this special group.
            /// </summary>
            NerrSpeGroupOp = 2234,

            /// <summary>
            ///     This operation is not allowed on the last administrative account.
            /// </summary>
            NerrLastAdmin = 2452,

            /// <summary>
            ///     The password parameter is invalid.
            /// </summary>
            NerrBadPassword = 2203,

            /// <summary>
            ///     The password does not meet the password policy requirements.
            ///     Check the minimum
            /// </summary>
            NerrPasswordTooShort = 2245,

            /// <summary>
            ///     The user name could not be found.
            /// </summary>
            NerrUserNotFound = 2221,

            /// <summary>
            ///     The user does not have access to the requested information.
            /// </summary>
            ErrorAccessDenied = 5,

            /// <summary>
            ///     Not enough storage is available to process this command.
            /// </summary>
            ErrorNotEnoughMemory = 8,

            /// <summary>
            ///     The parameter is incorrect.
            /// </summary>
            ErrorInvalidParameter = 87,

            /// <summary>
            ///     The filename, directory name, or volume label syntax is incorrect.
            /// </summary>
            ErrorInvalidName = 123,

            /// <summary>
            ///     The system call level is not correct. This error is returned if the level parameter is set to a value not
            ///     supported.
            /// </summary>
            ErrorInvalidLevel = 124,

            /// <summary>
            ///     More entries are available. Specify a large enough buffer to receive all entries.
            /// </summary>
            ErrorMoreData = 234,

            /// <summary>
            ///     Multiple connections to a server or shared resource by the same user, using more than one user name, are not
            ///     allowed. Disconnect all previous connections to the server or shared resource and try again.
            /// </summary>
            ErrorSessionCredentialConflict = 1219,

            /// <summary>
            ///     The RPC server is not available. This error is returned if a remote computer was specified in
            ///     the lpServer parameter and the RPC server is not available.
            /// </summary>
            RpcSServerUnavailable = 2147944122,

            /// <summary>
            ///     Remote calls are not allowed for this process. This error is returned if a remote computer was
            ///     specified in the lpServer parameter and remote calls are not allowed for this process.
            /// </summary>
            RpcERemoteDisabled = 2147549468
        }

        public enum NetError : uint
        {
            /// <summary>
            ///     The operation completed successfully.
            /// </summary>
            NERR_Success = 0,

            /// <summary>
            ///     Not enough storage is available to process this command
            /// </summary>
            ERROR_NOT_ENOUGH_MEMORY = 8,

            /// <summary>
            ///     This device is not shared.
            /// </summary>
            NERR_DeviceNotShared = 2311,
        }

        public enum SessionUserFlags : uint
        {
            /// <summary>
            ///     The user specified by the sesi*_username member established the session by using a guest account.
            /// </summary>
// ReSharper disable once InconsistentNaming
            SESS_GUEST = 1,

            /// <summary>
            ///     The user specified by the sesi*_username member established the session without using password encryption.
            /// </summary>
// ReSharper disable once InconsistentNaming
            SESS_NOENCRYPTION = 2
        }

        public enum SharePermissions : uint
        {
            ACCESS_NONE = 0,

            /// <summary>
            ///     Permission to read data from a resource and, by default, to execute the resource.
            /// </summary>
            ACCESS_READ = 1,

            /// <summary>
            ///     Permission to write data to the resource.
            /// </summary>
            ACCESS_WRITE = 2,

            /// <summary>
            ///     Permission to create an instance of the resource (such as a file); data can be written to the resource as the
            ///     resource is created.
            /// </summary>
            ACCESS_CREATE = 4,

            /// <summary>
            ///     Permission to execute the resource.
            /// </summary>
            ACCESS_EXEC = 8,

            /// <summary>
            ///     Permission to delete the resource.
            /// </summary>
            ACCESS_DELETE = 0x10,

            /// <summary>
            ///     Permission to modify the resource's attributes (such as the date and time when a file was last modified).
            /// </summary>
            ACCESS_ATRIB = 0x20,

            /// <summary>
            ///     Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user
            ///     or application.
            /// </summary>
            ACCESS_PERM = 0x40,

            /// <summary>
            ///     Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.
            /// </summary>
            ACCESS_ALL = ACCESS_READ + ACCESS_WRITE + ACCESS_CREATE + ACCESS_EXEC + ACCESS_DELETE + ACCESS_ATRIB + ACCESS_PERM,
            ACCESS_GROUP = 0x8000
        }

        public enum ShareType : uint
        {
            /// <summary>
            ///     Disk drive.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_DISKTREE = 0,

            /// <summary>
            ///     Print queue.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_PRINTQ = 1,

            /// <summary>
            ///     Communication device.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_DEVICE = 2,

            /// <summary>
            ///     Interprocess communication (IPC).
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_IPC = 3,

            /// <summary>
            ///     A temporary share.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_TEMPORARY = 0x40000000,

            /// <summary>
            ///     Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can
            ///     also refer to administrative shares such as C$, D$, E$, and so forth. For more information, see the network share
            ///     functions.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_SPECIAL = 0x80000000,
        }
    }
}