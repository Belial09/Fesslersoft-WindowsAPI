#region

using System;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFileGetInfo;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    /// <summary>
    ///     NetFileGetInfo function
    /// </summary>
    public sealed class NetFileGetInfo
    {
        /// <summary>
        ///     Retrieves information about a particular opening of a server resource. Descriptions taken from
        ///     https://msdn.microsoft.com/en-us/library/windows/desktop/bb525379(v=vs.85).aspx (NetFileGetInfo function).
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="fileid">
        ///     Specifies the file identifier of the open resource for which to return information. The value of
        ///     this parameter must have been returned in a previous enumeration call. For more information, see the following
        ///     Remarks section.
        /// </param>
        /// <returns></returns>
        public static FileInfo3 GetFileInfo(string servername, int fileid)
        {
            var returnValue = new FileInfo3();
            IntPtr pBuffer;
            var status = DllImports.NetFileGetInfo(servername, fileid, 3, out pBuffer);
            if (status == 0)
            {
                var shareinfoType = typeof (Structs.FileInfo3);
                var pItem = new IntPtr(pBuffer.ToInt32());
                var fileInfo3 = (Structs.FileInfo3) Marshal.PtrToStructure(pItem, shareinfoType);
                returnValue = FileInfo3.MapToFileInfo3(fileInfo3);
                NetApiBufferFree.FreeBuffer(pBuffer);
            }
            return returnValue;
        }
    }
}