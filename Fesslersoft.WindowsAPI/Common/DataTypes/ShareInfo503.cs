#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Common.DataTypes
{
    /// <summary>
    ///     Contains information about the shared resource. It is identical to the SHARE_INFO_502 structure, except that it
    ///     also contains the server name. Description taken from
    ///     https://msdn.microsoft.com/en-us/library/windows/desktop/cc462916(v=vs.85).aspx (SHARE_INFO_503 structure).
    /// </summary>
    public sealed class ShareInfo503
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
        ///     A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the shared resource
        ///     resides. A value of "*" indicates no configured server name.
        /// </summary>
        /// <value>
        ///     The servername.
        /// </value>
        public string Servername { get; set; }

        /// <summary>
        ///     Maps the managed ShareInfo503 Object to a native ShareInfo503 Struct.
        /// </summary>
        /// <param name="shareInfo">The managed source ShareInfo503 Object.</param>
        /// <returns>A native ShareInfo503 Struct.</returns>
        internal static Structs.ShareInfo503 MapToNativeShareInfo503(ShareInfo503 shareInfo)
        {
            return new Structs.ShareInfo503
            {
                shi503_current_uses = shareInfo.CurrentUsers,
                shi503_max_uses = shareInfo.MaxUsers,
                shi503_netname = shareInfo.NetName,
                shi503_passwd = shareInfo.Password,
                shi503_path = shareInfo.Path,
                shi503_permissions = (int) shareInfo.Permissions,
                shi503_remark = shareInfo.Remark,
                shi503_reserved = shareInfo.Reserved,
                shi503_security_descriptor = shareInfo.SecurityDescriptor,
                shi503_type = (int) shareInfo.ShareType,
                shi503_servername = shareInfo.Servername
            };
        }

        /// <summary>
        ///     Maps the native ShareInfo503 Structure to a managed ShareInfo503 Class.
        /// </summary>
        /// <param name="shareInfo">The native source ShareInfo503.</param>
        /// <returns>A managed ShareInfo503 Object.</returns>
        internal static ShareInfo503 MapToShareInfo503(Structs.ShareInfo503 shareInfo)
        {
            return new ShareInfo503
            {
                CurrentUsers = shareInfo.shi503_current_uses,
                MaxUsers = shareInfo.shi503_max_uses,
                NetName = shareInfo.shi503_netname,
                Password = shareInfo.shi503_passwd,
                Path = shareInfo.shi503_path,
                Permissions = (Enum.SharePermissions) shareInfo.shi503_permissions,
                Remark = shareInfo.shi503_remark,
                ShareType = (Enum.ShareType) shareInfo.shi503_type,
                Reserved = shareInfo.shi503_reserved,
                SecurityDescriptor = shareInfo.shi503_security_descriptor,
                Servername = shareInfo.shi503_servername
            };
        }
    }
}