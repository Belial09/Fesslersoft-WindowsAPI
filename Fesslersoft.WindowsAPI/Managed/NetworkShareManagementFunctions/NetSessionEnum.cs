#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;
using Fesslersoft.WindowsAPI.Internal.Native.NetworkShareManagementFunctions.NetSessionEnum;
using Fesslersoft.WindowsAPI.Managed.DataTypes;
using Fesslersoft.WindowsAPI.Managed.NetworkManagementFunctions;

#endregion

namespace Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions
{
    public sealed class NetSessionEnum
    {
        public static List<SessionInfo502> GetNetSessions(string server)
        {
            var list = new List<SessionInfo502>();
            int entriesRead;
            int totalEntries;
            var resumeHandle = 0;
            IntPtr pBuffer;
            var status = DllImports.NetSessionEnum(server, null, null, 502, out pBuffer, -1, out entriesRead, out totalEntries, ref resumeHandle);
            if (status == 0 & entriesRead > 0)
            {
                var shareinfoType = typeof (Structs.SessionInfo502);
                var offset = Marshal.SizeOf(shareinfoType);
                for (int i = 0, item = pBuffer.ToInt32(); i < entriesRead; i++, item += offset)
                {
                    var pItem = new IntPtr(item);
                    var sessionInfo502 = (Structs.SessionInfo502) Marshal.PtrToStructure(pItem, shareinfoType);
                    var netSessionEnumResult = SessionInfo502.MapToSessionInfo502(sessionInfo502);
                    list.Add(netSessionEnumResult);
                }
            }
            ApiBufferFunctions.NetApiBufferFree(pBuffer);
            return list;
        }
    }
}