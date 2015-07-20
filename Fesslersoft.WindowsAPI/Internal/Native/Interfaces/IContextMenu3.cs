#region

using System;
using System.Runtime.InteropServices;
using System.Text;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Interfaces
{
    [ComImport, Guid("bcfce0a0-ec17-11d0-8d10-00a0c90f2719")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IContextMenu3
    {

        [PreserveSig]
        Int32 QueryContextMenu(IntPtr hmenu,uint iMenu,uint idCmdFirst,uint idCmdLast,Enums.Cmf uFlags);

        [PreserveSig]
        Int32 InvokeCommand(ref Structs.Cminvokecommandinfoex info);

        [PreserveSig]
        Int32 GetCommandString(uint idcmd,Enums.Gcs uflags,uint reserved,[MarshalAs(UnmanagedType.LPWStr)] StringBuilder commandstring,int cch);

        [PreserveSig]
        Int32 HandleMenuMsg(uint uMsg,IntPtr wParam,IntPtr lParam);

        [PreserveSig]
        Int32 HandleMenuMsg2(uint uMsg,IntPtr wParam,IntPtr lParam,IntPtr plResult);
    }
}