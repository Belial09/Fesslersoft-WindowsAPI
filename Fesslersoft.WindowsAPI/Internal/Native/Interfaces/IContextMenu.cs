#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Interfaces
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    internal interface IContextMenu
    {
        [PreserveSig]
        Int32 QueryContextMenu(IntPtr hmenu,uint iMenu,uint idCmdFirst,uint idCmdLast,Enums.Cmf uFlags);

        [PreserveSig]
        Int32 InvokeCommand(ref Structs.Cminvokecommandinfoex info);

        [PreserveSig]
        Int32 GetCommandString(uint idcmd,Enums.Gcs uflags,uint reserved,[MarshalAs(UnmanagedType.LPArray)] byte[] commandstring,int cch);
    }
}