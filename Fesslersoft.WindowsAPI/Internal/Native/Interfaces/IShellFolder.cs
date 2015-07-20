#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Internal.Native.Interfaces
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214E6-0000-0000-C000-000000000046")]
    internal interface IShellFolder
    {
        [PreserveSig]
        Int32 ParseDisplayName(IntPtr hwnd, IntPtr pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, ref uint pchEaten, out IntPtr ppidl, ref Enums.Sfgao pdwAttributes);

        [PreserveSig]
        Int32 EnumObjects(IntPtr hwnd, Enums.Shcontf grfFlags, out IntPtr enumIdList);

        [PreserveSig]
        Int32 BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

        [PreserveSig]
        Int32 BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

        [PreserveSig]
        Int32 CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2);

        [PreserveSig]
        Int32 CreateViewObject(IntPtr hwndOwner, Guid riid, out IntPtr ppv);

        [PreserveSig]
        Int32 GetAttributesOf(uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Enums.Sfgao rgfInOut);

        [PreserveSig]
        Int32 GetUIObjectOf(IntPtr hwndOwner, uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Guid riid, IntPtr rgfReserved, out IntPtr ppv);

        [PreserveSig]
        Int32 GetDisplayNameOf(IntPtr pidl, Enums.Shgno uFlags, IntPtr lpName);

        [PreserveSig]
        Int32 SetNameOf(IntPtr hwnd, IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, Enums.Shgno uFlags, out IntPtr ppidlOut);
    }
}