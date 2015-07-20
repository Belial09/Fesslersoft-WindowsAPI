#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.DataTypes
{
    internal class Structs
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct Shfileinfo
        {
            internal IntPtr hIcon;
            internal int iIcon;
            internal uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            internal string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            internal string szTypeName;
        };


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct Cminvokecommandinfoex
        {
            internal int cbSize;
            internal Enums.Cmic fMask;
            internal IntPtr hwnd;
            internal IntPtr lpVerb;
            [MarshalAs(UnmanagedType.LPStr)]
            internal string lpParameters;
            [MarshalAs(UnmanagedType.LPStr)]
            internal string lpDirectory;
            internal Enums.Sw nShow;
            internal int dwHotKey;
            internal IntPtr hIcon;
            [MarshalAs(UnmanagedType.LPStr)]
            internal string lpTitle;
            internal IntPtr lpVerbW;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string lpParametersW;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string lpDirectoryW;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string lpTitleW;
            internal Point ptInvoke;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct FileInfo3
        {
            internal int SessionID;
            internal int Permission;
            internal int NumLocks;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string PathName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string UserName;
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

        [StructLayout(LayoutKind.Sequential)]
        internal struct SessionInfo502
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string ComputerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string UserName;
            internal uint NumOpens;
            internal uint SecondsActive;
            internal uint SecondsIdle;
            internal uint UserFlags;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string ClientType;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string Transport;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct ShareInfo2
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string NetName;
            internal int ShareType;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string Remark;
            internal int Permissions;
            internal int MaxUsers;
            internal int CurrentUsers;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string Path;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string Password;
        }
    }
}