#region

using System;
using System.Runtime.InteropServices;
using System.Text;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Interfaces
{
    [ComImport, Guid("000214f4-0000-0000-c000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IContextMenu2
    {
        [PreserveSig]
        Int32 QueryContextMenu(IntPtr hmenu,uint iMenu,uint idCmdFirst,uint idCmdLast,Enums.Cmf uFlags);

        [PreserveSig]
        Int32 InvokeCommand(ref Structs.Cminvokecommandinfoex info);

        [PreserveSig]
        Int32 GetCommandString(uint idcmd,Enums.Gcs uflags,uint reserved,[MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring,int cch);

        [PreserveSig]
        Int32 HandleMenuMsg(uint uMsg,IntPtr wParam,IntPtr lParam);
    }
}