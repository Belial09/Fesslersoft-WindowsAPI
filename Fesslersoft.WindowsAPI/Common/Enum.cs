#region

using System;

#endregion

namespace Fesslersoft.WindowsAPI.Common
{
    /// <summary>
    ///     Collection of Enumerations, used by the managed Classes.
    /// </summary>
    public static class Enum
    {
        /// <summary>
        ///     Possible flags for the SHFileOperation method.
        /// </summary>
        [Flags]
        public enum FileOperationFlags : ushort
        {
            /// <summary>
            ///     Do not show a dialog during the process
            /// </summary>
            FOF_SILENT = 0x0004,

            /// <summary>
            ///     Do not ask the user to confirm selection
            /// </summary>
            FOF_NOCONFIRMATION = 0x0010,

            /// <summary>
            ///     Delete the file to the recycle bin.  (Required flag to send a file to the bin
            /// </summary>
            FOF_ALLOWUNDO = 0x0040,

            /// <summary>
            ///     Do not show the names of the files or folders that are being recycled.
            /// </summary>
            FOF_SIMPLEPROGRESS = 0x0100,

            /// <summary>
            ///     Surpress errors, if any occur during the process.
            /// </summary>
            FOF_NOERRORUI = 0x0400,

            /// <summary>
            ///     Warn if files are too big to fit in the recycle bin and will need
            ///     to be deleted completely.
            /// </summary>
            FOF_WANTNUKEWARNING = 0x4000,
        }

        /// <summary>
        ///     File Operation Function Type for SHFileOperation
        /// </summary>
        public enum FileOperationType : uint
        {
            /// <summary>
            ///     Move the objects
            /// </summary>
            FO_MOVE = 0x0001,

            /// <summary>
            ///     Copy the objects
            /// </summary>
            FO_COPY = 0x0002,

            /// <summary>
            ///     Delete (or recycle) the objects
            /// </summary>
            FO_DELETE = 0x0003,

            /// <summary>
            ///     Rename the object(s)
            /// </summary>
            FO_RENAME = 0x0004,
        }

        public enum NetApiResult : uint
        {
            /// <summary>
            ///     The operation completed successfully.
            /// </summary>
            NerrSuccess = 0,

            /// <summary>
            ///     This computer name is invalid.
            /// </summary>
            NerrInvalidComputer = 2351,

            /// <summary>
            ///     This operation is only allowed on the primary domain controller of the domain.
            /// </summary>
            NerrNotPrimary = 2226,

            /// <summary>
            ///     This operation is not allowed on this special group.
            /// </summary>
            NerrSpeGroupOp = 2234,

            /// <summary>
            ///     This operation is not allowed on the last administrative account.
            /// </summary>
            NerrLastAdmin = 2452,

            /// <summary>
            ///     The password parameter is invalid.
            /// </summary>
            NerrBadPassword = 2203,

            /// <summary>
            ///     The password does not meet the password policy requirements.
            ///     Check the minimum
            /// </summary>
            NerrPasswordTooShort = 2245,

            /// <summary>
            ///     The user name could not be found.
            /// </summary>
            NerrUserNotFound = 2221,

            /// <summary>
            ///     The user does not have access to the requested information.
            /// </summary>
            ErrorAccessDenied = 5,

            /// <summary>
            ///     Not enough storage is available to process this command.
            /// </summary>
            ErrorNotEnoughMemory = 8,

            /// <summary>
            ///     The parameter is incorrect.
            /// </summary>
            ErrorInvalidParameter = 87,

            /// <summary>
            ///     The filename, directory name, or volume label syntax is incorrect.
            /// </summary>
            ErrorInvalidName = 123,

            /// <summary>
            ///     The system call level is not correct. This error is returned if the level parameter is set to a value not
            ///     supported.
            /// </summary>
            ErrorInvalidLevel = 124,

            /// <summary>
            ///     More entries are available. Specify a large enough buffer to receive all entries.
            /// </summary>
            ErrorMoreData = 234,

            /// <summary>
            ///     Multiple connections to a server or shared resource by the same user, using more than one user name, are not
            ///     allowed. Disconnect all previous connections to the server or shared resource and try again.
            /// </summary>
            ErrorSessionCredentialConflict = 1219,

            /// <summary>
            ///     The RPC server is not available. This error is returned if a remote computer was specified in
            ///     the lpServer parameter and the RPC server is not available.
            /// </summary>
            RpcSServerUnavailable = 2147944122,

            /// <summary>
            ///     Remote calls are not allowed for this process. This error is returned if a remote computer was
            ///     specified in the lpServer parameter and remote calls are not allowed for this process.
            /// </summary>
            RpcERemoteDisabled = 2147549468
        }

        public enum NetError : uint
        {
            /// <summary>
            ///     The operation completed successfully.
            /// </summary>
            NERR_Success = 0,

            /// <summary>
            ///     Not enough storage is available to process this command
            /// </summary>
            ERROR_NOT_ENOUGH_MEMORY = 8,

            /// <summary>
            ///     This device is not shared.
            /// </summary>
            NERR_DeviceNotShared = 2311,
        }

        public enum SHFileOperationError : uint
        {
            /// <summary>
            ///     The source and destination files are the same file.
            /// </summary>
            DE_SAMEFILE = 0x71,

            /// <summary>
            ///     Multiple file paths were specified in the source buffer, but only one destination file path.
            /// </summary>
            DE_MANYSRC1DEST = 0x72,

            /// <summary>
            ///     Rename operation was specified but the destination path is a different directory. Use the move operation instead.
            /// </summary>
            DE_DIFFDIR = 0x73,

            /// <summary>
            ///     The source is a root directory, which cannot be moved or renamed.
            /// </summary>
            DE_ROOTDIR = 0x74,

            /// <summary>
            ///     The operation was canceled by the user, or silently canceled if the appropriate flags were supplied to
            ///     SHFileOperation.
            /// </summary>
            DE_OPCANCELLED = 0x75,

            /// <summary>
            ///     The destination is a subtree of the source.
            /// </summary>
            DE_DESTSUBTREE = 0x76,

            /// <summary>
            ///     Security settings denied access to the source.
            /// </summary>
            DE_ACCESSDENIEDSRC = 0x78,

            /// <summary>
            ///     The source or destination path exceeded or would exceed MAX_PATH.
            /// </summary>
            DE_PATHTOODEEP = 0x79,

            /// <summary>
            ///     The operation involved multiple destination paths, which can fail in the case of a move operation.
            /// </summary>
            DE_MANYDEST = 0x7A,

            /// <summary>
            ///     The path in the source or destination or both was invalid.
            /// </summary>
            DE_INVALIDFILES = 0x7C,

            /// <summary>
            ///     The source and destination have the same parent folder.
            /// </summary>
            DE_DESTSAMETREE = 0x7D,

            /// <summary>
            ///     The destination path is an existing file.
            /// </summary>
            DE_FLDDESTISFILE = 0x7E,

            /// <summary>
            ///     The destination path is an existing folder.
            /// </summary>
            DE_FILEDESTISFLD = 0x80,

            /// <summary>
            ///     The name of the file exceeds MAX_PATH.
            /// </summary>
            DE_FILENAMETOOLONG = 0x81,

            /// <summary>
            ///     The destination is a read-only CD-ROM, possibly unformatted.
            /// </summary>
            DE_DEST_IS_CDROM = 0x82,

            /// <summary>
            ///     The destination is a read-only DVD, possibly unformatted.
            /// </summary>
            DE_DEST_IS_DVD = 0x83,

            /// <summary>
            ///     The destination is a writable CD-ROM, possibly unformatted.
            /// </summary>
            DE_DEST_IS_CDRECORD = 0x84,

            /// <summary>
            ///     The file involved in the operation is too large for the destination media or file system.
            /// </summary>
            DE_FILE_TOO_LARGE = 0x85,

            /// <summary>
            ///     The source is a read-only CD-ROM, possibly unformatted.
            /// </summary>
            DE_SRC_IS_CDROM = 0x86,

            /// <summary>
            ///     The source is a read-only DVD, possibly unformatted.
            /// </summary>
            DE_SRC_IS_DVD = 0x87,

            /// <summary>
            ///     The source is a writable CD-ROM, possibly unformatted.
            /// </summary>
            DE_SRC_IS_CDRECORD = 0x88,

            /// <summary>
            ///     MAX_PATH was exceeded during the operation.
            /// </summary>
            DE_ERROR_MAX = 0xB7,

            /// <summary>
            ///     An unknown error occurred. This is typically due to an invalid path in the source or destination. This error does
            ///     not occur on Windows Vista and later.
            /// </summary>
            DE_ERROR_UNKNOWN = 0x402,

            /// <summary>
            ///     An unspecified error occurred on the destination.
            /// </summary>
            ERRORONDEST = 0x10000,

            /// <summary>
            ///     Destination is a root directory and cannot be renamed.
            /// </summary>
            DE_ROOTDIR_ERRORONDEST = 0x10074
        }

        public enum SessionUserFlags : uint
        {
            /// <summary>
            ///     The user specified by the sesi*_username member established the session by using a guest account.
            /// </summary>
// ReSharper disable once InconsistentNaming
            SESS_GUEST = 1,

            /// <summary>
            ///     The user specified by the sesi*_username member established the session without using password encryption.
            /// </summary>
// ReSharper disable once InconsistentNaming
            SESS_NOENCRYPTION = 2
        }

        [Flags]
        public enum Sfgao : uint
        {
            /// <summary>
            ///     The specified items can be hosted inside a web browser or Windows Explorer frame.
            /// </summary>
            BROWSABLE = 0x8000000,

            /// <summary>
            ///     The specified items can be copied.
            /// </summary>
            CANCOPY = 1,

            /// <summary>
            ///     The specified items can be deleted.
            /// </summary>
            CANDELETE = 0x20,

            /// <summary>
            ///     Shortcuts can be created for the specified items. This attribute has the same value as DROPEFFECT_LINK. If a
            ///     namespace extension returns this attribute, a Create Shortcut entry with a default handler is added to the shortcut
            ///     menu that is displayed during drag-and-drop operations. The extension can also implement its own handler for the
            ///     link verb in place of the default. If the extension does so, it is responsible for creating the shortcut. A Create
            ///     Shortcut item is also added to the Windows Explorer File menu and to normal shortcut menus. If the item is
            ///     selected, your application's IContextMenu::InvokeCommand method is invoked with the lpVerb member of the
            ///     CMINVOKECOMMANDINFO structure set to link. Your application is responsible for creating the link.
            /// </summary>
            CANLINK = 4,

            /// <summary>
            ///     Not supported.
            /// </summary>
            CANMONIKER = 0x400000,

            /// <summary>
            ///     The specified items can be moved.
            /// </summary>
            CANMOVE = 2,

            /// <summary>
            ///     The specified items can be renamed. Note that this value is essentially a suggestion; not all namespace clients
            ///     allow items to be renamed. However, those that do must have this attribute set.
            /// </summary>
            CANRENAME = 0x10,

            /// <summary>
            ///     This flag is a mask for the capability attributes: SFGAO_CANCOPY, SFGAO_CANMOVE, SFGAO_CANLINK, SFGAO_CANRENAME,
            ///     SFGAO_CANDELETE, SFGAO_HASPROPSHEET, and SFGAO_DROPTARGET. Callers normally do not use this value.
            /// </summary>
            CAPABILITYMASK = 0x177,

            /// <summary>
            ///     The specified items are compressed.
            /// </summary>
            COMPRESSED = 0x4000000,

            /// <summary>
            ///     This flag is a mask for content attributes, at present only SFGAO_HASSUBFOLDER. Callers normally do not use this
            ///     value.
            /// </summary>
            CONTENTSMASK = 0x80000000,

            /// <summary>
            ///     Do not use.
            /// </summary>
            DISPLAYATTRMASK = 0xfc000,

            /// <summary>
            ///     The specified items are drop targets.
            /// </summary>
            DROPTARGET = 0x100,

            /// <summary>
            ///     The specified items are encrypted and might require special presentation.
            /// </summary>
            ENCRYPTED = 0x2000,

            /// <summary>
            ///     The specified folders are either file system folders or contain at least one descendant (child, grandchild, or
            ///     later) that is a file system (SFGAO_FILESYSTEM) folder.
            /// </summary>
            FILESYSANCESTOR = 0x10000000,

            /// <summary>
            ///     The specified folders or files are part of the file system (that is, they are files, directories, or root
            ///     directories). The parsed names of the items can be assumed to be valid Win32 file system paths. These paths can be
            ///     either UNC or drive-letter based.
            /// </summary>
            FILESYSTEM = 0x40000000,

            /// <summary>
            ///     The specified items are folders. Some items can be flagged with both SFGAO_STREAM and SFGAO_FOLDER, such as a
            ///     compressed file with a .zip file name extension. Some applications might include this flag when testing for items
            ///     that are both files and containers.
            /// </summary>
            FOLDER = 0x20000000,

            /// <summary>
            ///     The specified items are shown as dimmed and unavailable to the user.
            /// </summary>
            GHOSTED = 0x8000,

            /// <summary>
            ///     The specified items have property sheets.
            /// </summary>
            HASPROPSHEET = 0x40,

            /// <summary>
            ///     Not supported.
            /// </summary>
            HASSTORAGE = 0x400000,

            /// <summary>
            ///     The specified folders have subfolders. The SFGAO_HASSUBFOLDER attribute is only advisory and might be returned by
            ///     Shell folder implementations even if they do not contain subfolders. Note, however, that the converse—failing to
            ///     return SFGAO_HASSUBFOLDER—definitively states that the folder objects do not have subfolders. Returning
            ///     SFGAO_HASSUBFOLDER is recommended whenever a significant amount of time is required to determine whether any
            ///     subfolders exist. For example, the Shell always returns SFGAO_HASSUBFOLDER when a folder is located on a network
            ///     drive.
            /// </summary>
            HASSUBFOLDER = 0x80000000,

            /// <summary>
            ///     The item is hidden and should not be displayed unless the Show hidden files and folders option is enabled in Folder
            ///     Settings.
            /// </summary>
            HIDDEN = 0x80000,

            /// <summary>
            ///     Accessing the item (through IStream or other storage interfaces) is expected to be a slow operation. Applications
            ///     should avoid accessing items flagged with SFGAO_ISSLOW. Note  Opening a stream for an item is generally a slow
            ///     operation at all times. SFGAO_ISSLOW indicates that it is expected to be especially slow, for example in the case
            ///     of slow network connections or offline (FILE_ATTRIBUTE_OFFLINE) files. However, querying SFGAO_ISSLOW is itself a
            ///     slow operation. Applications should query SFGAO_ISSLOW only on a background thread. An alternate method, such as
            ///     retrieving the PKEY_FileAttributes property and testing for FILE_ATTRIBUTE_OFFLINE, could be used in place of a
            ///     method call that involves SFGAO_ISSLOW.
            /// </summary>
            ISSLOW = 0x4000,

            /// <summary>
            ///     The specified items are shortcuts.
            /// </summary>
            LINK = 0x10000,

            /// <summary>
            ///     The items contain new content, as defined by the particular application.
            /// </summary>
            NEWCONTENT = 0x200000,

            /// <summary>
            ///     The items are nonenumerated items and should be hidden. They are not returned through an enumerator such as that
            ///     created by the IShellFolder::EnumObjects method.
            /// </summary>
            NONENUMERATED = 0x100000,

            /// <summary>
            ///     The specified items are read-only. In the case of folders, this means that new items cannot be created in those
            ///     folders. This should not be confused with the behavior specified by the FILE_ATTRIBUTE_READONLY flag retrieved by
            ///     IColumnProvider::GetItemData in a SHCOLUMNDATA structure. FILE_ATTRIBUTE_READONLY has no meaning for Win32 file
            ///     system folders.
            /// </summary>
            READONLY = 0x40000,

            /// <summary>
            ///     The specified items are on removable media or are themselves removable devices.
            /// </summary>
            REMOVABLE = 0x2000000,

            /// <summary>
            ///     The specified objects are shared.
            /// </summary>
            SHARE = 0x20000,

            /// <summary>
            ///     The specified items can be bound to an IStorage object through IShellFolder::BindToObject. For more information
            ///     about namespace manipulation capabilities, see IStorage.
            /// </summary>
            STORAGE = 8,

            /// <summary>
            ///     Children of this item are accessible through IStream or IStorage. Those children are flagged with SFGAO_STORAGE or
            ///     SFGAO_STREAM.
            /// </summary>
            STORAGEANCESTOR = 0x800000,

            /// <summary>
            ///     This flag is a mask for the storage capability attributes: SFGAO_STORAGE, SFGAO_LINK, SFGAO_READONLY, SFGAO_STREAM,
            ///     SFGAO_STORAGEANCESTOR, SFGAO_FILESYSANCESTOR, SFGAO_FOLDER, and SFGAO_FILESYSTEM. Callers normally do not use this
            ///     value.
            /// </summary>
            STORAGECAPMASK = 0x70c50008,

            /// <summary>
            ///     Indicates that the item has a stream associated with it. That stream can be accessed through a call to
            ///     IShellFolder::BindToObject or IShellItem::BindToHandler with IID_IStream in the riid parameter.
            /// </summary>
            STREAM = 0x400000,

            /// <summary>
            ///     When specified as input, SFGAO_VALIDATE instructs the folder to validate that the items contained in a folder or
            ///     Shell item array exist. If one or more of those items do not exist, IShellFolder::GetAttributesOf and
            ///     IShellItemArray::GetAttributes return a failure code. This flag is never returned as an [out] value. When used with
            ///     the file system folder, SFGAO_VALIDATE instructs the folder to discard cached properties retrieved by clients of
            ///     IShellFolder2::GetDetailsEx that might have accumulated for the specified items.
            /// </summary>
            VALIDATE = 0x1000000
        }

        public enum SharePermissions : uint
        {
            ACCESS_NONE = 0,

            /// <summary>
            ///     Permission to read data from a resource and, by default, to execute the resource.
            /// </summary>
            ACCESS_READ = 1,

            /// <summary>
            ///     Permission to write data to the resource.
            /// </summary>
            ACCESS_WRITE = 2,

            /// <summary>
            ///     Permission to create an instance of the resource (such as a file); data can be written to the resource as the
            ///     resource is created.
            /// </summary>
            ACCESS_CREATE = 4,

            /// <summary>
            ///     Permission to execute the resource.
            /// </summary>
            ACCESS_EXEC = 8,

            /// <summary>
            ///     Permission to delete the resource.
            /// </summary>
            ACCESS_DELETE = 0x10,

            /// <summary>
            ///     Permission to modify the resource's attributes (such as the date and time when a file was last modified).
            /// </summary>
            ACCESS_ATRIB = 0x20,

            /// <summary>
            ///     Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user
            ///     or application.
            /// </summary>
            ACCESS_PERM = 0x40,

            /// <summary>
            ///     Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.
            /// </summary>
            ACCESS_ALL = ACCESS_READ + ACCESS_WRITE + ACCESS_CREATE + ACCESS_EXEC + ACCESS_DELETE + ACCESS_ATRIB + ACCESS_PERM,
            ACCESS_GROUP = 0x8000
        }

        public enum ShareType : uint
        {
            /// <summary>
            ///     Disk drive.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_DISKTREE = 0,

            /// <summary>
            ///     Print queue.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_PRINTQ = 1,

            /// <summary>
            ///     Communication device.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_DEVICE = 2,

            /// <summary>
            ///     Interprocess communication (IPC).
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_IPC = 3,

            /// <summary>
            ///     A temporary share.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_TEMPORARY = 0x40000000,

            /// <summary>
            ///     Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can
            ///     also refer to administrative shares such as C$, D$, E$, and so forth. For more information, see the network share
            ///     functions.
            /// </summary>
// ReSharper disable once InconsistentNaming
            STYPE_SPECIAL = 0x80000000,
        }

        /// <summary>
        ///     Determines the types of items included in an enumeration. These values are used with the IShellFolder::EnumObjects
        ///     method.
        /// </summary>
        [Flags]
        public enum Shcontf
        {
            /// <summary>
            ///     0x00020. Include items that are folders in the enumeration.
            /// </summary>
            FOLDERS = 0x0020,

            /// <summary>
            ///     0x00040. Include items that are not folders in the enumeration.
            /// </summary>
            NONFOLDERS = 0x0040,

            /// <summary>
            ///     0x00080. Include hidden items in the enumeration. This does not include hidden system items. (To include hidden
            ///     system items, use SHCONTF_INCLUDESUPERHIDDEN.)
            /// </summary>
            INCLUDEHIDDEN = 0x0080,

            /// <summary>
            ///     0x00100. No longer used; always assumed. IShellFolder::EnumObjects can return without validating the enumeration
            ///     object. Validation can be postponed until the first call to IEnumIDList::Next. Use this flag when a user interface
            ///     might be displayed prior to the first IEnumIDList::Next call. For a user interface to be presented, hwnd must be
            ///     set to a valid window handle.
            /// </summary>
            INIT_ON_FIRST_NEXT = 0x0100,

            /// <summary>
            ///     0x00200. The calling application is looking for printer objects.
            /// </summary>
            NETPRINTERSRCH = 0x0200,

            /// <summary>
            ///     0x00400. The calling application is looking for resources that can be shared.
            /// </summary>
            SHAREABLE = 0x0400,

            /// <summary>
            ///     0x00800. Include items with accessible storage and their ancestors, including hidden items.
            /// </summary>
            STORAGE = 0x0800,
        }

        [Flags]
        public enum Shhdnf
        {
            /// <summary>
            ///     When not combined with another flag, return the parent-relative name that identifies the item, suitable for
            ///     displaying to the user. This name often does not include extra information such as the file name extension and does
            ///     not need to be unique. This name might include information that identifies the folder that contains the item. For
            ///     instance, this flag could cause IShellFolder::GetDisplayNameOf to return the string "username (on Machine)" for a
            ///     particular user's folder.
            /// </summary>
            NORMAL = 0x0000,

            /// <summary>
            ///     The name is relative to the folder from which the request was made. This is the name display to the user when used
            ///     in the context of the folder. For example, it is used in the view and in the address bar path segment for the
            ///     folder. This name should not include disambiguation information—for instance "username" instead of "username (on
            ///     Machine)" for a particular user's folder. Use this flag in combinations with SHGDN_FORPARSING and SHGDN_FOREDITING.
            /// </summary>
            INFOLDER = 0x0001,

            /// <summary>
            ///     The name is used for in-place editing when the user renames the item.
            /// </summary>
            FOREDITING = 0x1000,

            /// <summary>
            ///     The name is displayed in an address bar combo box.
            /// </summary>
            FORADDRESSBAR = 0x4000,

            /// <summary>
            ///     The name is used for parsing. That is, it can be passed to IShellFolder::ParseDisplayName to recover the object's
            ///     PIDL. The form this name takes depends on the particular object. When SHGDN_FORPARSING is used alone, the name is
            ///     relative to the desktop. When combined with SHGDN_INFOLDER, the name is relative to the folder from which the
            ///     request was made.
            /// </summary>
            FORPARSING = 0x8000
        }
    }
}