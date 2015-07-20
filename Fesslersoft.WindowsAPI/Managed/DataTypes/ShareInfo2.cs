#region

using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    public sealed class ShareInfo2
    {
        public string NetName { get; set; }
        public int ShareType { get; set; }
        public string Remark { get; set; }
        public int Permissions { get; set; }
        public int MaxUsers { get; set; }
        public int CurrentUsers { get; set; }
        public string Path { get; set; }
        public string Password { get; set; }

        internal static ShareInfo2 MapToSessionInfo502(Structs.ShareInfo2 shareInfo)
        {
            return new ShareInfo2
            {
                CurrentUsers = shareInfo.CurrentUsers,
                MaxUsers = shareInfo.MaxUsers,
                NetName = shareInfo.NetName,
                Password = shareInfo.Password,
                Path = shareInfo.Path,
                Permissions = shareInfo.Permissions,
                Remark = shareInfo.Remark,
                ShareType = shareInfo.ShareType
            };
        }
    }
}