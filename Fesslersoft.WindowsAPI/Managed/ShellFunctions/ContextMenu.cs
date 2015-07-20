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
using Fesslersoft.WindowsAPI.Properties;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.ShellFunctions
{
    /// <summary>
    /// ContextMenu Shell Wrapper
    /// </summary>
    public sealed class ContextMenu
    {
        private const int SOk = 0;
        private const int MaxPath = 260;
        private const uint CmdFirst = 1;
        private const uint CmdLast = 30000;
        private static string _strParentFolder;
        private static IShellFolder _oParentFolder;
        private static IShellFolder _oDesktopFolder;
        private static IContextMenu _oContextMenu;
        private static IContextMenu2 _oContextMenu2;
        private static IContextMenu3 _oContextMenu3;
        private static readonly int CbInvokeCommand = Marshal.SizeOf(typeof (Structs.Cminvokecommandinfoex));
        private static Guid _iidIShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");
        private static Guid _iidIContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");
        private static Guid _iidIContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");
        private static Guid _iidIContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");

        private static bool GetContextMenuInterfaces(IShellFolder oParentFolder, IntPtr PIDLs, out IntPtr ctxMenuPtr)
        {
            var arrPidLs = new IntPtr[1];
            arrPidLs[0] = PIDLs;
            var nResult = oParentFolder.GetUIObjectOf(IntPtr.Zero, (uint) arrPidLs.Length, arrPidLs, ref _iidIContextMenu, IntPtr.Zero, out ctxMenuPtr);
            if (SOk == nResult)
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
            if (null == _oDesktopFolder)
            {
                IntPtr pUnkownDesktopFolder;
                var nResult = DllImports.SHGetDesktopFolder(out pUnkownDesktopFolder);
                if (SOk != nResult)
                {
                    throw new ShellContextMenuException("Failed to retrieve Desktop Shell Folder");
                }
                _oDesktopFolder = (IShellFolder) Marshal.GetTypedObjectForIUnknown(pUnkownDesktopFolder, typeof (IShellFolder));
            }
            return _oDesktopFolder;
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
                IntPtr pPidl;
                uint pchEaten = 0;
                Enums.Sfgao pdwAttributes = 0;
                var nResult = oDesktopFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, folderName, ref pchEaten, out pPidl, ref pdwAttributes);
                if (SOk != nResult)
                {
                    return null;
                }
                var pStrRet = Marshal.AllocCoTaskMem(MaxPath*2 + 4);
                Marshal.WriteInt32(pStrRet, 0, 0);
                nResult = _oDesktopFolder.GetDisplayNameOf(pPidl, Enums.Shgno.FORPARSING, pStrRet);
                var strFolder = new StringBuilder(MaxPath);
                DllImports.StrRetToBuf(pStrRet, pPidl, strFolder, MaxPath);
                Marshal.FreeCoTaskMem(pStrRet);
                pStrRet = IntPtr.Zero;
                _strParentFolder = strFolder.ToString();
                IntPtr pUnknownParentFolder;
                nResult = oDesktopFolder.BindToObject(pPidl, IntPtr.Zero, ref _iidIShellFolder, out pUnknownParentFolder);
                Marshal.FreeCoTaskMem(pPidl);
                if (SOk != nResult)
                {
                    return null;
                }
                _oParentFolder = (IShellFolder) Marshal.GetTypedObjectForIUnknown(pUnknownParentFolder, typeof (IShellFolder));
            }

            return _oParentFolder;
        }

        private static IntPtr GetPidl([NotNull] DirectoryInfo directoryInfo)
        {
            if (directoryInfo.Parent != null)
            {
                var oParentFolder = GetParentFolder(directoryInfo.Parent.FullName);
                if (null == oParentFolder)
                {
                    return IntPtr.Zero;
                }
                uint pchEaten = 0;
                Enums.Sfgao pdwAttributes = 0;
                IntPtr pPidl;
                oParentFolder.ParseDisplayName(IntPtr.Zero, IntPtr.Zero, directoryInfo.Name, ref pchEaten, out pPidl, ref pdwAttributes);
                return pPidl;
            }
            return IntPtr.Zero;
        }

        private static void InvokeCommand(IContextMenu oContextMenu, uint nCmd, string strFolder, Point pointInvoke)
        {
            var invoke = new Structs.Cminvokecommandinfoex
            {
                cbSize = CbInvokeCommand,
                lpVerb = (IntPtr) (nCmd - CmdFirst),
                lpDirectory = strFolder,
                lpVerbW = (IntPtr) (nCmd - CmdFirst),
                lpDirectoryW = strFolder,
                fMask = Enums.Cmic.UNICODE | Enums.Cmic.PTINVOKE | ((Control.ModifierKeys & Keys.Control) != 0 ? Enums.Cmic.CONTROL_DOWN : 0) | ((Control.ModifierKeys & Keys.Shift) != 0 ? Enums.Cmic.SHIFT_DOWN : 0),
                ptInvoke = new Structs.Point(pointInvoke.X, pointInvoke.Y),
                nShow = Enums.Sw.SHOWNORMAL
            };
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
            if (null == _oParentFolder) return;
            Marshal.ReleaseComObject(_oParentFolder);
            _oParentFolder = null;
        }

        /// <summary>
        /// Shows the Current Windows Context Menu for the given Directory at the PointOfScreen passed to the method.
        /// </summary>
        /// <param name="directory">The DirectoryInfo Objects of the directory.</param>
        /// <param name="pointToScreen">The point of screen where the ContextMenu should be shown.</param>
        /// <param name="hwnd">The Window Handle of the Form showing the Context.</param>
        public static void ShowContextMenu(DirectoryInfo directory, Point pointToScreen, IntPtr hwnd)
        {
            ShowContextMenuInternal(directory, pointToScreen, hwnd);
        }

        private static void ShowContextMenuInternal(DirectoryInfo directory, Point pointScreen, IntPtr hwnd)
        {
            var pMenu = IntPtr.Zero;
            var iContextMenuPtr = IntPtr.Zero;
            var iContextMenuPtr2 = IntPtr.Zero;
            var iContextMenuPtr3 = IntPtr.Zero;

            try
            {
                var pidl = GetPidl(directory);
                if (directory.Parent != null && false == GetContextMenuInterfaces(GetParentFolder(directory.FullName), pidl, out iContextMenuPtr))
                {
                    ReleaseAll();
                    return;
                }
                pMenu = DllImports.CreatePopupMenu();
                _oContextMenu.QueryContextMenu(pMenu, 0, CmdFirst, CmdLast, Enums.Cmf.EXPLORE | Enums.Cmf.NORMAL | ((Control.ModifierKeys & Keys.Shift) != 0 ? Enums.Cmf.EXTENDEDVERBS : 0));
                Marshal.QueryInterface(iContextMenuPtr, ref _iidIContextMenu2, out iContextMenuPtr2);
                Marshal.QueryInterface(iContextMenuPtr, ref _iidIContextMenu3, out iContextMenuPtr3);
                _oContextMenu2 = (IContextMenu2) Marshal.GetTypedObjectForIUnknown(iContextMenuPtr2, typeof (IContextMenu2));
                _oContextMenu3 = (IContextMenu3) Marshal.GetTypedObjectForIUnknown(iContextMenuPtr3, typeof (IContextMenu3));
                var nSelected = DllImports.TrackPopupMenuEx(pMenu, Enums.Tpm.RETURNCMD, pointScreen.X, pointScreen.Y, hwnd, IntPtr.Zero);
                DllImports.DestroyMenu(pMenu);
                pMenu = IntPtr.Zero;
                if (nSelected != 0)
                {
                    InvokeCommand(_oContextMenu, nSelected, _strParentFolder, pointScreen);
                }
            }
            catch
            {
            }
            finally
            {
                if (pMenu != IntPtr.Zero)
                {
                    DllImports.DestroyMenu(pMenu);
                }
                if (iContextMenuPtr != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr);
                }
                if (iContextMenuPtr2 != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr2);
                }
                if (iContextMenuPtr3 != IntPtr.Zero)
                {
                    Marshal.Release(iContextMenuPtr3);
                }
                ReleaseAll();
            }
        }
    }
}