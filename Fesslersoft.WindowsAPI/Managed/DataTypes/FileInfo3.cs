#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.DataTypes
{
    
    public sealed class FileInfo3
    {
        public Int32 Id { get; set; }
        public Int32 Permission { get; set; }
        public Int32 NumberOfLocks { get; set; }
        public String Username { get; set; }
        public String Pathname { get; set; }

        internal static FileInfo3 MapToFileInfo3(Structs.FileInfo3 fileInfo)
        {
            return new FileInfo3
            {
                Id = fileInfo.SessionID,
                NumberOfLocks = fileInfo.NumLocks,
                Pathname = fileInfo.PathName,
                Permission = fileInfo.Permission,
                Username = fileInfo.UserName
            };
        }
    }
}