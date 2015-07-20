#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetFile;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    
    sealed class NetFileEnum
    {
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
                ApiBufferFunctions.NetApiBufferFree(pBuffer);
            }
            return list;
        }
    }
}