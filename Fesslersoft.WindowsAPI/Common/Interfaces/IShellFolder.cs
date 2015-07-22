#region

using System;
using System.Runtime.InteropServices;

#endregion

namespace Fesslersoft.WindowsAPI.Common.Interfaces
{
    /// <summary>
    ///     Exposed by all Shell namespace folder objects, its methods are used to manage folders.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214E6-0000-0000-C000-000000000046")]
    public interface IShellFolder
    {
        /// <summary>
        ///     Translates the display name of a file object or a folder into an item identifier list.
        /// </summary>
        /// <param name="hwnd">
        ///     A window handle. The client should provide a window handle if it displays a dialog or message box.
        ///     Otherwise set hwnd to NULL.
        /// </param>
        /// <param name="pbc">
        ///     Optional. A pointer to a bind context used to pass parameters as inputs and outputs to the parsing
        ///     function. These passed parameters are often specific to the data source and are documented by the data source
        ///     owners. For example, the file system data source accepts the name being parsed (as a WIN32_FIND_DATA structure),
        ///     using the STR_FILE_SYS_BIND_DATA bind context parameter. STR_PARSE_PREFER_FOLDER_BROWSING can be passed to indicate
        ///     that URLs are parsed using the file system data source when possible. Construct a bind context object using
        ///     CreateBindCtx and populate the values using IBindCtx::RegisterObjectParam. See Bind Context String Keys for a
        ///     complete list of these. If no data is being passed to or received from the parsing function, this value can be
        ///     NULL.
        /// </param>
        /// <param name="pszDisplayName">
        ///     A null-terminated Unicode string with the display name. Because each Shell folder defines
        ///     its own parsing syntax, the form this string can take may vary. The desktop folder, for instance, accepts paths
        ///     such as "C:\My Docs\My File.txt". It also will accept references to items in the namespace that have a GUID
        ///     associated with them using the "::{GUID}" syntax. For example, to retrieve a fully qualified identifier list for
        ///     the control panel from the desktop folder, you can use the following:
        /// </param>
        /// <param name="pchEaten">
        ///     A pointer to a ULONG value that receives the number of characters of the display name that was
        ///     parsed. If your application does not need this information, set pchEaten to NULL, and no value will be returned.
        /// </param>
        /// <param name="ppidl">
        ///     When this method returns, contains a pointer to the PIDL for the object. The returned item
        ///     identifier list specifies the item relative to the parsing folder. If the object associated with pszDisplayName is
        ///     within the parsing folder, the returned item identifier list will contain only one SHITEMID structure. If the
        ///     object is in a subfolder of the parsing folder, the returned item identifier list will contain multiple SHITEMID
        ///     structures. If an error occurs, NULL is returned in this address. When it is no longer needed, it is the
        ///     responsibility of the caller to free this resource by calling CoTaskMemFree.
        /// </param>
        /// <param name="pdwAttributes">
        ///     The value used to query for file attributes. If not used, it should be set to NULL. To
        ///     query for one or more attributes, initialize this parameter with the SFGAO flags that represent the attributes of
        ///     interest. On return, those attributes that are true and were requested will be set.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 ParseDisplayName(IntPtr hwnd, IntPtr pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, ref uint pchEaten, out IntPtr ppidl, ref Enum.Sfgao pdwAttributes);

        /// <summary>
        ///     Enables a client to determine the contents of a folder by creating an item identifier enumeration object and
        ///     returning its IEnumIDList interface. The methods supported by that interface can then be used to enumerate the
        ///     folder's contents.
        /// </summary>
        /// <param name="hwnd">
        ///     If user input is required to perform the enumeration, this window handle should be used by the
        ///     enumeration object as the parent window to take user input. An example would be a dialog box to ask for a password
        ///     or prompt the user to insert a CD or floppy disk. If hwndOwner is set to NULL, the enumerator should not post any
        ///     messages, and if user input is required, it should silently fail.
        /// </param>
        /// <param name="grfFlags">
        ///     Flags indicating which items to include in the enumeration. For a list of possible values, see
        ///     the SHCONTF enumerated type.
        /// </param>
        /// <param name="enumIdList">
        ///     The address that receives a pointer to the IEnumIDList interface of the enumeration object
        ///     created by this method. If an error occurs or no suitable subobjects are found, ppenumIDList is set to NULL.
        /// </param>
        /// <returns></returns>
        [PreserveSig]
        Int32 EnumObjects(IntPtr hwnd, Enum.Shcontf grfFlags, out IntPtr enumIdList);

        /// <summary>
        ///     Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional
        ///     parameters that control the construction of the handler are passed in the bind context.
        /// </summary>
        /// <param name="pidl">
        ///     The address of an ITEMIDLIST structure (PIDL) that identifies the subfolder. This value can refer to
        ///     an item at any level below the parent folder in the namespace hierarchy. The structure contains one or more
        ///     SHITEMID structures, followed by a terminating NULL.
        /// </param>
        /// <param name="pbc">
        ///     A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to
        ///     the construction of the handler. If this parameter is not used, set it to NULL. Because support for this parameter
        ///     is optional for folder object implementations, some folders may not support the use of bind contexts. Information
        ///     that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that
        ///     indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
        ///     IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
        /// </param>
        /// <param name="riid">
        ///     The identifier of the interface to return. This may be IID_IShellFolder, IID_IStream, or any other
        ///     interface that identifies a particular handler.
        /// </param>
        /// <param name="ppv">
        ///     When this method returns, contains the address of a pointer to the requested interface. If an error
        ///     occurs, a NULL pointer is returned at this address.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 BindToObject(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

        /// <summary>
        ///     Requests a pointer to an object's storage interface.
        /// </summary>
        /// <param name="pidl">
        ///     The address of an ITEMIDLIST structure that identifies the subfolder relative to its parent folder.
        ///     The structure must contain exactly one SHITEMID structure followed by a terminating zero.
        /// </param>
        /// <param name="pbc">
        ///     The optional address of an IBindCtx interface on a bind context object to be used during this
        ///     operation. If this parameter is not used, set it to NULL. Because support for pbc is optional for folder object
        ///     implementations, some folders may not support the use of bind contexts.
        /// </param>
        /// <param name="riid">
        ///     The IID of the requested storage interface. To retrieve an IStream, IStorage, or IPropertySetStorage
        ///     interface pointer, set riid to IID_IStream, IID_IStorage, or IID_IPropertySetStorage, respectively.
        /// </param>
        /// <param name="ppv">
        ///     The address that receives the interface pointer specified by riid. If an error occurs, a NULL pointer
        ///     is returned in this address.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 BindToStorage(IntPtr pidl, IntPtr pbc, ref Guid riid, out IntPtr ppv);

        /// <summary>
        ///     Determines the relative order of two file objects or folders, given their item identifier lists.
        /// </summary>
        /// <param name="lParam">
        ///     A value that specifies how the comparison should be performed. The lower sixteen bits of lParam
        ///     define the sorting rule. Most applications set the sorting rule to the default value of zero, indicating that the
        ///     two items should be compared by name. The system does not define any other sorting rules. Some folder objects might
        ///     allow calling applications to use the lower sixteen bits of lParam to specify folder-specific sorting rules. The
        ///     rules and their associated lParam values are defined by the folder. When the system folder view object calls
        ///     IShellFolder::CompareIDs, the lower sixteen bits of lParam are used to specify the column to be used for the
        ///     comparison. The upper sixteen bits of lParam are used for flags that modify the sorting rule.
        /// </param>
        /// <param name="pidl1">
        ///     A pointer to the first item's ITEMIDLIST structure. It will be relative to the folder. This
        ///     ITEMIDLIST structure can contain more than one element; therefore, the entire structure must be compared, not just
        ///     the first element.
        /// </param>
        /// <param name="pidl2">
        ///     A pointer to the second item's ITEMIDLIST structure. It will be relative to the folder. This
        ///     ITEMIDLIST structure can contain more than one element; therefore, the entire structure must be compared, not just
        ///     the first element.
        /// </param>
        /// <returns>
        ///     If this method is successful, the CODE field of the HRESULT contains one of the following values. For
        ///     information regarding the extraction of the CODE field from the returned HRESULT, see Remarks. If this method is
        ///     unsuccessful, it returns a COM error code. (Negative, Positive, Zero).
        /// </returns>
        [PreserveSig]
        Int32 CompareIDs(IntPtr lParam, IntPtr pidl1, IntPtr pidl2);

        /// <summary>
        ///     Requests an object that can be used to obtain information from or interact with a folder object.
        /// </summary>
        /// <param name="hwndOwner">
        ///     A handle to the owner window. If you have implemented a custom folder view object, your folder
        ///     view window should be created as a child of hwndOwner.
        /// </param>
        /// <param name="riid">A reference to the IID of the interface to retrieve through ppv, typically IID_IShellView.</param>
        /// <param name="ppv">
        ///     When this method returns successfully, contains the interface pointer requested in riid. This is
        ///     typically IShellView. See the Remarks section for more details.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 CreateViewObject(IntPtr hwndOwner, Guid riid, out IntPtr ppv);

        /// <summary>
        ///     Gets the attributes of one or more file or folder objects contained in the object represented by IShellFolder.
        /// </summary>
        /// <param name="cidl">The number of items from which to retrieve attributes.</param>
        /// <param name="apidl">
        ///     The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies an
        ///     item relative to the parent folder. Each ITEMIDLIST structure must contain exactly one SHITEMID structure followed
        ///     by a terminating zero.
        /// </param>
        /// <param name="rgfInOut">
        ///     Pointer to a single ULONG value that, on entry, contains the bitwise SFGAO attributes that the
        ///     calling application is requesting. On exit, this value contains the requested attributes that are common to all of
        ///     the specified items.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 GetAttributesOf(uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Enum.Sfgao rgfInOut);

        /// <summary>
        ///     Gets an object that can be used to carry out actions on the specified file objects or folders.
        /// </summary>
        /// <param name="hwndOwner">
        ///     A handle to the owner window that the client should specify if it displays a dialog box or
        ///     message box.
        /// </param>
        /// <param name="cidl">The number of file objects or subfolders specified in the apidl parameter.</param>
        /// <param name="apidl">
        ///     The address of an array of pointers to ITEMIDLIST structures, each of which uniquely identifies a
        ///     file object or subfolder relative to the parent folder. Each item identifier list must contain exactly one SHITEMID
        ///     structure followed by a terminating zero.
        /// </param>
        /// <param name="riid">
        ///     A reference to the IID of the interface to retrieve through ppv. This can be any valid interface
        ///     identifier that can be created for an item. The most common identifiers used by the Shell are listed in the
        ///     comments at the end of this reference.
        /// </param>
        /// <param name="rgfReserved">Reserved.</param>
        /// <param name="ppv">When this method returns successfully, contains the interface pointer requested in riid.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 GetUIObjectOf(IntPtr hwndOwner, uint cidl, [MarshalAs(UnmanagedType.LPArray)] IntPtr[] apidl, ref Guid riid, IntPtr rgfReserved, out IntPtr ppv);

        /// <summary>
        ///     Retrieves the display name for the specified file object or subfolder.
        /// </summary>
        /// <param name="pidl">PIDL that uniquely identifies the file object or subfolder relative to the parent folder.</param>
        /// <param name="uFlags">
        ///     Flags used to request the type of display name to return. For a list of possible values, see the
        ///     SHGDNF enumerated type.
        /// </param>
        /// <param name="lpName">
        ///     When this method returns, contains a pointer to a STRRET structure in which to return the display
        ///     name. The type of name returned in this structure can be the requested type, but the Shell folder might return a
        ///     different type.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 GetDisplayNameOf(IntPtr pidl, Enum.Shhdnf uFlags, IntPtr lpName);

        /// <summary>
        ///     Sets the display name of a file object or subfolder, changing the item identifier in the process.
        /// </summary>
        /// <param name="hwnd">A handle to the owner window of any dialog or message box that the client displays.</param>
        /// <param name="pidl">
        ///     A pointer to an ITEMIDLIST structure that uniquely identifies the file object or subfolder relative
        ///     to the parent folder. The structure must contain exactly one SHITEMID structure followed by a terminating zero.
        /// </param>
        /// <param name="pszName">A pointer to a null-terminated string that specifies the new display name.</param>
        /// <param name="uFlags">
        ///     Flags that indicate the type of name specified by the pszName parameter. For a list of possible
        ///     values and combinations of values, see SHGDNF.
        /// </param>
        /// <param name="ppidlOut">
        ///     Optional. If specified, the address of a pointer to an ITEMIDLIST structure that receives the
        ///     ITEMIDLIST of the renamed item. The caller requests this value by passing a non-null ppidlOut. Implementations of
        ///     IShellFolder::SetNameOf must return a pointer to the new ITEMIDLIST in the ppidlOut parameter.
        /// </param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        Int32 SetNameOf(IntPtr hwnd, IntPtr pidl, [MarshalAs(UnmanagedType.LPWStr)] string pszName, Enum.Shhdnf uFlags, out IntPtr ppidlOut);
    }
}