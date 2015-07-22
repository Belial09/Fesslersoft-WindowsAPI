#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.DataTypes
{
    internal class Structs
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct Cminvokecommandinfoex
        {
            internal int cbSize;
            internal Enums.Cmic fMask;
            internal IntPtr hwnd;
            internal IntPtr lpVerb;
            [MarshalAs(UnmanagedType.LPStr)] internal string lpParameters;
            [MarshalAs(UnmanagedType.LPStr)] internal string lpDirectory;
            internal Enums.Sw nShow;
            internal int dwHotKey;
            internal IntPtr hIcon;
            [MarshalAs(UnmanagedType.LPStr)] internal string lpTitle;
            internal IntPtr lpVerbW;
            [MarshalAs(UnmanagedType.LPWStr)] internal string lpParametersW;
            [MarshalAs(UnmanagedType.LPWStr)] internal string lpDirectoryW;
            [MarshalAs(UnmanagedType.LPWStr)] internal string lpTitleW;
            internal Point ptInvoke;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct ConnectionInfo1
        {
            internal uint coni1_id;
            internal uint coni1_type;
            internal uint coni1_num_opens;
            internal uint coni1_num_users;
            internal uint coni1_time;
            [MarshalAs(UnmanagedType.LPWStr)] internal string coni1_username;
            [MarshalAs(UnmanagedType.LPWStr)] internal string coni1_netname;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct FileInfo3
        {
            internal int SessionID;
            internal int Permission;
            internal int NumLocks;
            [MarshalAs(UnmanagedType.LPWStr)] internal string PathName;
            [MarshalAs(UnmanagedType.LPWStr)] internal string UserName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct Point
        {
            internal Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            internal int x;
            internal int y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
        internal struct SHFILEOPSTRUCT
        {
            internal readonly IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)] internal Enums.FileOperationType wFunc;
            internal string pFrom;
            internal readonly string pTo;
            internal Enums.FileOperationFlags fFlags;
            [MarshalAs(UnmanagedType.Bool)] internal readonly bool fAnyOperationsAborted;
            internal readonly IntPtr hNameMappings;
            internal readonly string lpszProgressTitle;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct SessionInfo2
        {
            [MarshalAs(UnmanagedType.LPWStr)] internal string sesi2_cname;
            [MarshalAs(UnmanagedType.LPWStr)] internal string sesi2_username;
            internal uint sesi2_num_opens;
            internal uint sesi2_time;
            internal uint sesi2_idle_time;
            internal uint sesi2_user_flags;
            [MarshalAs(UnmanagedType.LPWStr)] internal string sesi2_cltype_name;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SessionInfo502
        {
            [MarshalAs(UnmanagedType.LPWStr)] internal string ComputerName;
            [MarshalAs(UnmanagedType.LPWStr)] internal string UserName;
            internal uint NumOpens;
            internal uint SecondsActive;
            internal uint SecondsIdle;
            internal uint UserFlags;
            [MarshalAs(UnmanagedType.LPWStr)] internal string ClientType;
            [MarshalAs(UnmanagedType.LPWStr)] internal string Transport;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct ShareInfo2
        {
            [MarshalAs(UnmanagedType.LPWStr)] internal string NetName;
            internal int ShareType;
            [MarshalAs(UnmanagedType.LPWStr)] internal string Remark;
            internal int Permissions;
            internal int MaxUsers;
            internal int CurrentUsers;
            [MarshalAs(UnmanagedType.LPWStr)] internal string Path;
            [MarshalAs(UnmanagedType.LPWStr)] internal string Password;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct ShareInfo502
        {
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi502_netname;
            internal int shi502_type;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi502_remark;
            internal Int32 shi502_permissions;
            internal Int32 shi502_max_uses;
            internal Int32 shi502_current_uses;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi502_path;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi502_passwd;
            internal Int32 shi502_reserved;
            internal IntPtr shi502_security_descriptor;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct ShareInfo503
        {
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi503_netname;
            internal int shi503_type;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi503_remark;
            internal Int32 shi503_permissions;
            internal Int32 shi503_max_uses;
            internal Int32 shi503_current_uses;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi503_path;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi503_passwd;
            [MarshalAs(UnmanagedType.LPWStr)] internal string shi503_servername;
            internal Int32 shi503_reserved;
            internal IntPtr shi503_security_descriptor;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct Shfileinfo
        {
            internal IntPtr hIcon;
            internal int iIcon;
            internal uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] internal string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)] internal string szTypeName;
        };

        [StructLayout(LayoutKind.Sequential)]
        internal struct StatWorkstation0
        {
            [MarshalAs(UnmanagedType.I8)] public Int64 StatisticsStartTime;
            public long BytesReceived;
            public long SmbsReceived;
            public long PagingReadBytesRequested;
            public long NonPagingReadBytesRequested;
            public long CacheReadBytesRequested;
            public long NetworkReadBytesRequested;
            public long BytesTransmitted;
            public long SmbsTransmitted;
            public long PagingWriteBytesRequested;
            public long NonPagingWriteBytesRequested;
            public long CacheWriteBytesRequested;
            public long NetworkWriteBytesRequested;
            public int InitiallyFailedOperations;
            public int FailedCompletionOperations;
            public int ReadOperations;
            public int RandomReadOperations;
            public int ReadSmbs;
            public int LargeReadSmbs;
            public int SmallReadSmbs;
            public int WriteOperations;
            public int RandomWriteOperations;
            public int WriteSmbs;
            public int LargeWriteSmbs;
            public int SmallWriteSmbs;
            public int RawReadsDenied;
            public int RawWritesDenied;
            public int NetworkErrors;
            public int Sessions;
            public int FailedSessions;
            public int Reconnects;
            public int CoreConnects;
            public int Lanman20Connects;
            public int Lanman21Connects;
            public int LanmanNtConnects;
            public int ServerDisconnects;
            public int HungSessions;
            public int UseCount;
            public int FailedUseCount;
            public int CurrentCommands;
        }
    }
}