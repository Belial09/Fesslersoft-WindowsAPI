#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Common.DataTypes
{
    /// <summary>
    ///     Contains information about the shared resource, including name of the resource, type and permissions, and the
    ///     number of current connections. For more information about controlling access to securable objects, see Access
    ///     Control, Privileges, and Securable Objects. Description taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb525408(v=vs.85).aspx (SHARE_INFO_502 structure).
    /// </summary>
    public sealed class ShareInfo502
    {
        /// <summary>
        ///     Reserved; must be zero. Calls to the NetShareSetInfo function ignore this member.
        /// </summary>
        /// <value>
        ///     The reserved.
        /// </value>
        public int Reserved { get; set; }

        /// <summary>
        ///     Specifies the SECURITY_DESCRIPTOR associated with this share.
        /// </summary>
        /// <value>
        ///     The security descriptor.
        /// </value>
        public IntPtr SecurityDescriptor { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string specifying the share name of a resource. Calls to the NetShareSetInfo function ignore
        ///     this member.
        /// </summary>
        /// <value>
        ///     The name of the net.
        /// </value>
        public string NetName { get; set; }

        /// <summary>
        ///     A combination of values that specify the type of the shared resource. Calls to the NetShareSetInfo function ignore
        ///     this member. One of the following values may be specified. You can isolate these values by using the STYPE_MASK
        ///     value.
        /// </summary>
        /// <value>
        ///     The type of the share.
        /// </value>
        public Enum.ShareType ShareType { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string that contains an optional comment about the shared resource.
        /// </summary>
        /// <value>
        ///     The remark.
        /// </value>
        public string Remark { get; set; }

        /// <summary>
        ///     Specifies a DWORD value that indicates the shared resource's permissions for servers running with share-level
        ///     security. A server running user-level security ignores this member. This member can be one or more of the following
        ///     values. Calls to the NetShareSetInfo function ignore this member. Note that Windows does not support share-level
        ///     security.
        /// </summary>
        /// <value>
        ///     The permissions.
        /// </value>
        public Enum.SharePermissions Permissions { get; set; }

        /// <summary>
        ///     Specifies a DWORD value that indicates the maximum number of concurrent connections that the shared resource can
        ///     accommodate. The number of connections is unlimited if the value specified in this member is –1.
        /// </summary>
        /// <value>
        ///     The maximum users.
        /// </value>
        public int MaxUsers { get; set; }

        /// <summary>
        ///     Specifies a DWORD value that indicates the number of current connections to the resource. Calls to the
        ///     NetShareSetInfo function ignore this member.
        /// </summary>
        /// <value>
        ///     The current users.
        /// </value>
        public int CurrentUsers { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string specifying the local path for the shared resource. For disks, shi2_path is the path
        ///     being shared. For print queues, shi2_path is the name of the print queue being shared. Calls to the NetShareSetInfo
        ///     function ignore this member.
        /// </summary>
        /// <value>
        ///     The path.
        /// </value>
        public string Path { get; set; }

        /// <summary>
        ///     Pointer to a Unicode string that specifies the share's password when the server is running with share-level
        ///     security. If the server is running with user-level security, this member is ignored. The shi2_passwd member can be
        ///     no longer than SHPWLEN+1 bytes (including a terminating null character). Calls to the NetShareSetInfo function
        ///     ignore this member. Note that Windows does not support share-level security.
        /// </summary>
        /// <value>
        ///     The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        ///     Maps the managed ShareInfo502 Object to a native ShareInfo502 Struct.
        /// </summary>
        /// <param name="shareInfo">The managed source ShareInfo502 Object.</param>
        /// <returns>A native ShareInfo502 Struct.</returns>
        internal static Structs.ShareInfo502 MapToNativeShareInfo502(ShareInfo502 shareInfo)
        {
            return new Structs.ShareInfo502
            {
                shi502_current_uses = shareInfo.CurrentUsers,
                shi502_max_uses = shareInfo.MaxUsers,
                shi502_netname = shareInfo.NetName,
                shi502_passwd = shareInfo.Password,
                shi502_path = shareInfo.Path,
                shi502_permissions = (int) shareInfo.Permissions,
                shi502_remark = shareInfo.Remark,
                shi502_reserved = shareInfo.Reserved,
                shi502_security_descriptor = shareInfo.SecurityDescriptor,
                shi502_type = (int) shareInfo.ShareType
            };
        }

        /// <summary>
        ///     Maps the native ShareInfo502 Structure to a managed ShareInfo502 Class.
        /// </summary>
        /// <param name="shareInfo">The native source ShareInfo502.</param>
        /// <returns>A managed ShareInfo502 Object.</returns>
        internal static ShareInfo502 MapToShareInfo502(Structs.ShareInfo502 shareInfo)
        {
            return new ShareInfo502
            {
                CurrentUsers = shareInfo.shi502_current_uses,
                MaxUsers = shareInfo.shi502_max_uses,
                NetName = shareInfo.shi502_netname,
                Password = shareInfo.shi502_passwd,
                Path = shareInfo.shi502_path,
                Permissions = (Enum.SharePermissions) shareInfo.shi502_permissions,
                Remark = shareInfo.shi502_remark,
                ShareType = (Enum.ShareType) shareInfo.shi502_type,
                Reserved = shareInfo.shi502_reserved,
                SecurityDescriptor = shareInfo.shi502_security_descriptor
            };
        }
    }
}