#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Common.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFile;
using Fesslersoft.WindowsAPI.Managed.Networking.ManagementFunctions;
using Enum = Fesslersoft.WindowsAPI.Common.Enum;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.Networking.ShareManagementFunctions
{
    public sealed class Files
    {
        /// <summary>
        ///     Forces a resource to close. This function can be used when an error prevents closure by any other means. You should
        ///     use NetFileClose with caution because it does not write data cached on the client system to the file before closing
        ///     the file.
        /// </summary>
        /// <param name="servername">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <param name="id">Specifies the file identifier of the opened resource instance to close.</param>
        /// <returns>
        ///     If the function succeeds, the return value is NERR_Success. If the function fails, the return value can be one
        ///     of the following error codes. ERROR_ACCESS_DENIED or ERROR_FILE_NOT_FOUND
        /// </returns>
        public static Enum.NetApiResult CloseFileResource(string servername, int id)
        {
            return (Enum.NetApiResult) ((uint) DllImports.NetFileClose(servername, id));
        }

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
            var status = Internal.Native.NetworkShareManagementFunctions.NetFileGetInfo.DllImports.NetFileGetInfo(servername, fileid, 3, out pBuffer);
            if (status == 0)
            {
                var shareinfoType = typeof (Structs.FileInfo3);
                var pItem = new IntPtr(pBuffer.ToInt32());
                var fileInfo3 = (Structs.FileInfo3) Marshal.PtrToStructure(pItem, shareinfoType);
                returnValue = FileInfo3.MapToFileInfo3(fileInfo3);
                ApiBuffer.FreeBuffer(pBuffer);
            }
            return returnValue;
        }

        /// <summary>
        ///     Returns information about some or all open files on a server, depending on the parameters specified.
        /// </summary>
        /// <param name="server">
        ///     Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the
        ///     function is to execute. If this parameter is NULL, the local computer is used. This string is Unicode if
        ///     _WIN32_WINNT or FORCE_UNICODE is defined.
        /// </param>
        /// <returns>A IEnumerable of Managed FileInfo3 Objects.</returns>
        public static IEnumerable<FileInfo3> GetNetFileList(string server)
        {
            var list = new List<FileInfo3>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            var pBuffer = IntPtr.Zero;
            var status = DllImports.NetFileEnum(server, null, null, 3, ref pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
            if (status == 0 & entriesRead > 0)
            {
                var shareinfoType = typeof (Structs.FileInfo3);
                var offset = Marshal.SizeOf(shareinfoType);
                for (int i = 0, item = pBuffer.ToInt32(); i < entriesRead; i++, item += offset)
                {
                    var pItem = new IntPtr(item);
                    var fileInfo3 = (Structs.FileInfo3) Marshal.PtrToStructure(pItem, shareinfoType);
                    var nEtFileEnumResult = FileInfo3.MapToFileInfo3(fileInfo3);
                    list.Add(nEtFileEnumResult);
                }
                ApiBuffer.FreeBuffer(pBuffer);
            }
            return list;
        }
    }
}