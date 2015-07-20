#region

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.Helper;
using Fesslersoft.WindowsAPI.Internal.Native.Interfaces;
using Fesslersoft.WindowsAPI.Internal.Native.ShellFunctions.ContextMenu;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.ShellFunctions
{
    public sealed class ContextMenu
    {
        private const int S_OK = 0;
        private const int MAX_PATH = 260;
        private const uint CMD_FIRST = 1;
        private const uint CMD_LAST = 30000;
        private static IntPtr PIDL;
        private static string _strParentFolder;
        private static IShellFolder _oParentFolder;
        private static IShellFolder _oDesktopFolder;
        private static IContextMenu _oContextMenu;
        private static IContextMenu2 _oContextMenu2;
        private static IContextMenu3 _oContextMenu3;

        private static readonly int cbInvokeCommand = Marshal.SizeOf(typeof (Structs.CMINVOKECOMMANDINFOEX));
        private static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");
        private static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");
        private static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");
        private static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

        private static void FreePIDL(IntPtr arrPIDLs)
        {
            if (arrPIDLs != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(arrPIDLs);
                arrPIDLs = IntPtr.Zero;
            }
        }

        private static bool GetContextMenuInterfaces(IShellFolder oParentFolder, IntPtr PIDLs, out IntPtr ctxMenuPtr)
        {
            var arrPIDLs = new IntPtr[1];
            arrPIDLs[0] = PIDLs;

            var nResult = oParentFolder.GetUIObjectOf(
                IntPtr.Zero,
                (uint) arrPIDLs.Length,
                arrPIDLs,
                ref IID_IContextMenu,
                IntPtr.Zero,
                out ctxMenuPtr);

            if (S_OK == nResult)
            {
                _oContextMenu = (IContextMenu) Marshal.GetTypedObjectForIUnknown(ctxMenuPtr, typeof (IContextMenu));

                return true;
            }
            ctxMenuPtr = IntPtr.Zero;
            _oContextMenu = null;
            return false;
        }

        private static IShellFolder GetDesktopFolder()
        {
            var pUnkownDesktopFolder = IntPtr.Zero;

            if (null == _oDesktopFolder)
            {
                // Get desktop IShellFolder
                var nResult = DllImports.SHGetDesktopFolder(out pUnkownDesktopFolder);
                if (S_OK != nResult)
                {
                    throw new ShellContextMenuException("Failed to get the desktop shell folder");
                }
                _oDesktopFolder = (IShellFolder) Marshal.GetTypedObjectForIUnknown(pUnkownDesktopFolder, typeof (IShellFolder));
            }

            return _oDesktopFolder;
        }

        private static IntPtr GetPIDL(DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Parent != null)
            {
                var oParentFolder = GetParentFolder(directoryInfo.Parent.FullName);
                if (null == oParentFolder)
                {
                    return IntPtr.Zero;
                }
                // Get the file relative to folder
                uint pchEaten = 0;
                Enums.SFGAO pdwAttributes = 0;
                var pPIDL = IntPtr.Zero;
                var nResult = oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, directoryInfo.Name, ref pchEaten, out pPIDL, ref pdwAttributes);
                return pPIDL;
            }
            return IntPtr.Zero;
        }

        private static IShellFolder GetParentFolder(string folderName)
        {
            if (null == _oParentFolder)
            {
                var oDesktopFolder = GetDesktopFolder();
                if (null == oDesktopFolder)
                {
                    return null;
                }

                // Get the PIDL for the folder file is in
                var pPIDL = IntPtr.Zero;
                uint pchEaten = 0;
                Enums.SFGAO pdwAttributes = 0;
                var nResult = oDesktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref pchEaten, out pPIDL, ref pdwAttributes);
                if (S_OK != nResult)
                {
                    return null;
                }

                var pStrRet = Marshal.AllocCoTaskMem(MAX_PATH*2 + 4);
                Marshal.WriteInt32(pStrRet, 0, 0);
                nResult = _oDesktopFolder.GetDisplayNameOf(pPIDL, Enums.SHGNO.FORPARSING, pStrRet);
                var strFolder = new StringBuilder(MAX_PATH);
                DllImports.StrRetToBuf(pStrRet, pPIDL, strFolder, MAX_PATH);
                Marshal.FreeCoTaskMem(pStrRet);
                pStrRet = IntPtr.Zero;
                _strParentFolder = strFolder.ToString();

                // Get the IShellFolder for folder
                var pUnknownParentFolder = IntPtr.Zero;
                nResult = oDesktopFolder.BindToObject(pPIDL, IntPtr.Zero, ref IID_IShellFolder, out pUnknownParentFolder);
                // Free the PIDL first
                Marshal.FreeCoTaskMem(pPIDL);
                if (S_OK != nResult)
                {
                    return null;
                }
                _oParentFolder = (IShellFolder) Marshal.GetTypedObjectForIUnknown(pUnknownParentFolder, typeof (IShellFolder));
            }

            return _oParentFolder;
        }

        private static void InvokeCommand(IContextMenu oContextMenu, uint nCmd, string strFolder, Point pointInvoke)
        {
            var invoke = new Structs.CMINVOKECOMMANDINFOEX();
            invoke.cbSize = cbInvokeCommand;
            invoke.lpVerb = (IntPtr) (nCmd - CMD_FIRST);
            invoke.lpDirectory = strFolder;
            invoke.lpVerbW = (IntPtr) (nCmd - CMD_FIRST);
            invoke.lpDirectoryW = strFolder;
            invoke.fMask = Enums.CMIC.UNICODE | Enums.CMIC.PTINVOKE |
                           ((Control.ModifierKeys & Keys.Control) != 0 ? Enums.CMIC.CONTROL_DOWN : 0) |
                           ((Control.ModifierKeys & Keys.Shift) != 0 ? Enums.CMIC.SHIFT_DOWN : 0);
            invoke.ptInvoke = new Structs.POINT(pointInvoke.X, pointInvoke.Y);
            invoke.nShow = Enums.SW.SHOWNORMAL;

            oContextMenu.InvokeCommand(ref invoke);
        }

        private static void ReleaseAll()
        {
            if (null != _oContextMenu)
            {
                Marshal.ReleaseComObject(_oContextMenu);
                _oContextMenu = null;
            }
            if (null != _oContextMenu2)
            {
                Marshal.ReleaseComObject(_oContextMenu2);
                _oContextMenu2 = null;
            }
            if (null != _oContextMenu3)
            {
                Marshal.ReleaseComObject(_oContextMenu3);
                _oContextMenu3 = null;
            }
            if (null != _oDesktopFolder)
            {
                Marshal.ReleaseComObject(_oDesktopFolder);
                _oDesktopFolder = null;
            }
            if (null != _oParentFolder)
            {
                Marshal.ReleaseComObject(_oParentFolder);
                _oParentFolder = null;
            }
            FreePIDL(PIDL);
        }

        public static void ShowContextMenu(DirectoryInfo directory, Point pointToScreen, IntPtr hwnd)
        {
            ShowContextMenuInternal(directory, pointToScreen, hwnd);
        }

        private static void ShowContextMenuInternal(DirectoryInfo directory, Point pointScreen, IntPtr hwnd)
        {
            IntPtr pMenu = IntPtr.Zero,
                iContextMenuPtr = IntPtr.Zero,
                iContextMenuPtr2 = IntPtr.Zero,
                iContextMenuPtr3 = IntPtr.Zero;

            try
            {
                var pidl = GetPIDL(directory);
                if (directory.Parent != null && false == GetContextMenuInterfaces(GetParentFolder(directory.FullName), pidl, out iContextMenuPtr))
                {
                    ReleaseAll();
                    return;
                }

                pMenu = DllImports.CreatePopupMenu();

                var nResult = _oContextMenu.QueryContextMenu(
                    pMenu,
                    0,
                    CMD_FIRST,
                    CMD_LAST,
                    Enums.CMF.EXPLORE |
                    Enums.CMF.NORMAL |
                    ((Control.ModifierKeys & Keys.Shift) != 0 ? Enums.CMF.EXTENDEDVERBS : 0));

                Marshal.QueryInterface(iContextMenuPtr, ref IID_IContextMenu2, out iContextMenuPtr2);
                Marshal.QueryInterface(iContextMenuPtr, ref IID_IContextMenu3, out iContextMenuPtr3);

                _oContextMenu2 = (IContextMenu2) Marshal.GetTypedObjectForIUnknown(iContextMenuPtr2, typeof (IContextMenu2));
                _oContextMenu3 = (IContextMenu3) Marshal.GetTypedObjectForIUnknown(iContextMenuPtr3, typeof (IContextMenu3));

                var nSelected = DllImports.TrackPopupMenuEx(
                    pMenu,
                    Enums.TPM.RETURNCMD,
                    pointScreen.X,
                    pointScreen.Y,
                    hwnd,
                    IntPtr.Zero);

                DllImports.DestroyMenu(pMenu);
                pMenu = IntPtr.Zero;

                if (nSelected != 0)
                {
                    InvokeCommand(_oContextMenu, nSelected, _strParentFolder, pointScreen);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                //hook.Uninstall();
                if (pMenu != IntPtr.Zero)
                {
                    DllImports.DestroyMenu(pMenu);
                }

                if (iContextMenuPtr != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr);

                if (iContextMenuPtr2 != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr2);

                if (iContextMenuPtr3 != IntPtr.Zero)
                    Marshal.Release(iContextMenuPtr3);

                ReleaseAll();
            }
        }
    }
}