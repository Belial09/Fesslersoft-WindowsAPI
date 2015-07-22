#region

using System;
using Fesslersoft.WindowsAPI.Internal.Native.DataTypes;

#endregion

namespace Fesslersoft.WindowsAPI.Common.DataTypes
{
    /// <summary>
    ///     Contains statistical information about the specified workstation.
    /// </summary>
    public sealed class Statworkstation0
    {
        /// <summary>
        ///     Specifies the time statistics collection started. This member also indicates when statistics for the workstations
        ///     were last cleared. The value is stored as the number of seconds elapsed since 00:00:00, January 1, 1970.
        /// </summary>
        /// <value>
        ///     The statistics start time.
        /// </value>
        public Int64 StatisticsStartTime { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes received by the workstation.
        /// </summary>
        /// <value>
        ///     The bytes received.
        /// </value>
        public long BytesReceived { get; set; }

        /// <summary>
        ///     Specifies the total number of server message blocks (SMBs) received by the workstation.
        /// </summary>
        /// <value>
        ///     The SMBS received.
        /// </value>
        public long SmbsReceived { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been read by paging I/O requests.
        /// </summary>
        /// <value>
        ///     The paging read bytes requested.
        /// </value>
        public long PagingReadBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been read by non-paging I/O requests.
        /// </summary>
        /// <value>
        ///     The non paging read bytes requested.
        /// </value>
        public long NonPagingReadBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been read by cache I/O requests.
        /// </summary>
        /// <value>
        ///     The cache read bytes requested.
        /// </value>
        public long CacheReadBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total amount of bytes that have been read by disk I/O requests.
        /// </summary>
        /// <value>
        ///     The network read bytes requested.
        /// </value>
        public long NetworkReadBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes transmitted by the workstation.
        /// </summary>
        /// <value>
        ///     The bytes transmitted.
        /// </value>
        public long BytesTransmitted { get; set; }

        /// <summary>
        ///     Specifies the total number of SMBs transmitted by the workstation.
        /// </summary>
        /// <value>
        ///     The SMBS transmitted.
        /// </value>
        public long SmbsTransmitted { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been written by paging I/O requests.
        /// </summary>
        /// <value>
        ///     The paging write bytes requested.
        /// </value>
        public long PagingWriteBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been written by non-paging I/O requests.
        /// </summary>
        /// <value>
        ///     The non paging write bytes requested.
        /// </value>
        public long NonPagingWriteBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been written by cache I/O requests.
        /// </summary>
        /// <value>
        ///     The cache write bytes requested.
        /// </value>
        public long CacheWriteBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of bytes that have been written by disk I/O requests.
        /// </summary>
        /// <value>
        ///     The network write bytes requested.
        /// </value>
        public long NetworkWriteBytesRequested { get; set; }

        /// <summary>
        ///     Specifies the total number of network operations that failed to begin.
        /// </summary>
        /// <value>
        ///     The initially failed operations.
        /// </value>
        public int InitiallyFailedOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of network operations that failed to complete.
        /// </summary>
        /// <value>
        ///     The failed completion operations.
        /// </value>
        public int FailedCompletionOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of read operations initiated by the workstation.
        /// </summary>
        /// <value>
        ///     The read operations.
        /// </value>
        public int ReadOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of random access reads initiated by the workstation.
        /// </summary>
        /// <value>
        ///     The random read operations.
        /// </value>
        public int RandomReadOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of read requests the workstation has sent to servers.
        /// </summary>
        /// <value>
        ///     The read SMBS.
        /// </value>
        public int ReadSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of read requests the workstation has sent to servers that are greater than twice the
        ///     size of the server's negotiated buffer size.
        /// </summary>
        /// <value>
        ///     The large read SMBS.
        /// </value>
        public int LargeReadSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of read requests the workstation has sent to servers that are less than 1/4 of the size
        ///     of the server's negotiated buffer size.
        /// </summary>
        /// <value>
        ///     The small read SMBS.
        /// </value>
        public int SmallReadSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of write operations initiated by the workstation.
        /// </summary>
        /// <value>
        ///     The write operations.
        /// </value>
        public int WriteOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of random access writes initiated by the workstation.
        /// </summary>
        /// <value>
        ///     The random write operations.
        /// </value>
        public int RandomWriteOperations { get; set; }

        /// <summary>
        ///     Specifies the total number of write requests the workstation has sent to servers.
        /// </summary>
        /// <value>
        ///     The write SMBS.
        /// </value>
        public int WriteSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of write requests the workstation has sent to servers that are greater than twice the
        ///     size of the server's negotiated buffer size.
        /// </summary>
        /// <value>
        ///     The large write SMBS.
        /// </value>
        public int LargeWriteSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of write requests the workstation has sent to servers that are less than 1/4 of the size
        ///     of the server's negotiated buffer size.
        /// </summary>
        /// <value>
        ///     The small write SMBS.
        /// </value>
        public int SmallWriteSmbs { get; set; }

        /// <summary>
        ///     Specifies the total number of raw read requests made by the workstation that have been denied.
        /// </summary>
        /// <value>
        ///     The raw reads denied.
        /// </value>
        public int RawReadsDenied { get; set; }

        /// <summary>
        ///     Specifies the total number of raw write requests made by the workstation that have been denied.
        /// </summary>
        /// <value>
        ///     The raw writes denied.
        /// </value>
        public int RawWritesDenied { get; set; }

        /// <summary>
        ///     Specifies the total number of network errors received by the workstation.
        /// </summary>
        /// <value>
        ///     The network errors.
        /// </value>
        public int NetworkErrors { get; set; }

        /// <summary>
        ///     Specifies the total number of workstation sessions that were established.
        /// </summary>
        /// <value>
        ///     The sessions.
        /// </value>
        public int Sessions { get; set; }

        /// <summary>
        ///     Specifies the number of times the workstation attempted to create a session but failed.
        /// </summary>
        /// <value>
        ///     The failed sessions.
        /// </value>
        public int FailedSessions { get; set; }

        /// <summary>
        ///     Specifies the total number of connections that have failed.
        /// </summary>
        /// <value>
        ///     The reconnects.
        /// </value>
        public int Reconnects { get; set; }

        /// <summary>
        ///     Specifies the total number of connections to servers supporting the PCNET dialect that have succeeded.
        /// </summary>
        /// <value>
        ///     The core connects.
        /// </value>
        public int CoreConnects { get; set; }

        /// <summary>
        ///     Specifies the total number of connections to servers supporting the LanManager 2.0 dialect that have succeeded.
        /// </summary>
        /// <value>
        ///     The lanman20 connects.
        /// </value>
        public int Lanman20Connects { get; set; }

        /// <summary>
        ///     Specifies the total number of connections to servers supporting the LanManager 2.1 dialect that have succeeded.
        /// </summary>
        /// <value>
        ///     The lanman21 connects.
        /// </value>
        public int Lanman21Connects { get; set; }

        /// <summary>
        ///     Specifies the total number of connections to servers supporting the NTLM dialect that have succeeded.
        /// </summary>
        /// <value>
        ///     The lanman nt connects.
        /// </value>
        public int LanmanNtConnects { get; set; }

        /// <summary>
        ///     Specifies the number of times the workstation was disconnected by a network server.
        /// </summary>
        /// <value>
        ///     The server disconnects.
        /// </value>
        public int ServerDisconnects { get; set; }

        /// <summary>
        ///     Specifies the total number of sessions that have expired on the workstation.
        /// </summary>
        /// <value>
        ///     The hung sessions.
        /// </value>
        public int HungSessions { get; set; }

        /// <summary>
        ///     Specifies the total number of network connections established by the workstation.
        /// </summary>
        /// <value>
        ///     The use count.
        /// </value>
        public int UseCount { get; set; }

        /// <summary>
        ///     Specifies the total number of failed network connections for the workstation.
        /// </summary>
        /// <value>
        ///     The failed use count.
        /// </value>
        public int FailedUseCount { get; set; }

        /// <summary>
        ///     Specifies the number of current requests that have not been completed.
        /// </summary>
        /// <value>
        ///     The current commands.
        /// </value>
        public int CurrentCommands { get; set; }

        /// <summary>
        ///     Maps the managed Statworkstation0 Object to a native Statworkstation0 Struct.
        /// </summary>
        /// <param name="statworkstation0">The managed source Statworkstation0 Object.</param>
        /// <returns>A native Statworkstation0 Struct.</returns>
        internal static Structs.StatWorkstation0 MapToNativeStatworkstation0(Statworkstation0 statworkstation0)
        {
            return new Structs.StatWorkstation0
            {
                BytesReceived = statworkstation0.BytesReceived,
                CacheReadBytesRequested = statworkstation0.CacheReadBytesRequested,
                CoreConnects = statworkstation0.CoreConnects,
                BytesTransmitted = statworkstation0.BytesTransmitted,
                CacheWriteBytesRequested = statworkstation0.CacheWriteBytesRequested,
                CurrentCommands = statworkstation0.CurrentCommands,
                FailedCompletionOperations = statworkstation0.FailedCompletionOperations,
                FailedSessions = statworkstation0.FailedSessions,
                FailedUseCount = statworkstation0.FailedUseCount,
                HungSessions = statworkstation0.HungSessions,
                InitiallyFailedOperations = statworkstation0.InitiallyFailedOperations,
                Lanman20Connects = statworkstation0.Lanman20Connects,
                Lanman21Connects = statworkstation0.Lanman21Connects,
                LanmanNtConnects = statworkstation0.LanmanNtConnects,
                LargeReadSmbs = statworkstation0.LargeReadSmbs,
                LargeWriteSmbs = statworkstation0.LargeWriteSmbs,
                NetworkErrors = statworkstation0.NetworkErrors,
                NetworkReadBytesRequested = statworkstation0.NetworkReadBytesRequested,
                NetworkWriteBytesRequested = statworkstation0.NetworkWriteBytesRequested,
                NonPagingReadBytesRequested = statworkstation0.NonPagingReadBytesRequested,
                NonPagingWriteBytesRequested = statworkstation0.NonPagingWriteBytesRequested,
                PagingReadBytesRequested = statworkstation0.PagingReadBytesRequested,
                PagingWriteBytesRequested = statworkstation0.PagingWriteBytesRequested,
                RandomReadOperations = statworkstation0.RandomReadOperations,
                RandomWriteOperations = statworkstation0.RandomWriteOperations,
                RawReadsDenied = statworkstation0.RawReadsDenied,
                RawWritesDenied = statworkstation0.RawWritesDenied,
                ReadOperations = statworkstation0.ReadOperations,
                ReadSmbs = statworkstation0.ReadSmbs,
                Reconnects = statworkstation0.Reconnects,
                ServerDisconnects = statworkstation0.ServerDisconnects,
                Sessions = statworkstation0.Sessions,
                SmallReadSmbs = statworkstation0.SmallReadSmbs,
                SmallWriteSmbs = statworkstation0.SmallWriteSmbs,
                SmbsReceived = statworkstation0.SmbsReceived,
                SmbsTransmitted = statworkstation0.SmbsTransmitted,
                StatisticsStartTime = statworkstation0.StatisticsStartTime,
                UseCount = statworkstation0.UseCount,
                WriteOperations = statworkstation0.WriteOperations,
                WriteSmbs = statworkstation0.WriteSmbs
            };
        }

        /// <summary>
        ///     Maps the native Statworkstation0 Structure to a managed Statworkstation0 Class.
        /// </summary>
        /// <param name="statworkstation0">The native source Statworkstation0.</param>
        /// <returns>A managed Statworkstation0 Object.</returns>
        internal static Statworkstation0 MapToStatworkstation0(Structs.StatWorkstation0 statworkstation0)
        {
            return new Statworkstation0
            {
                BytesReceived = statworkstation0.BytesReceived,
                BytesTransmitted = statworkstation0.BytesTransmitted,
                CacheReadBytesRequested = statworkstation0.CacheReadBytesRequested,
                CacheWriteBytesRequested = statworkstation0.CacheWriteBytesRequested,
                CoreConnects = statworkstation0.CoreConnects,
                CurrentCommands = statworkstation0.CurrentCommands,
                FailedCompletionOperations = statworkstation0.FailedCompletionOperations,
                FailedSessions = statworkstation0.FailedSessions,
                FailedUseCount = statworkstation0.FailedUseCount,
                HungSessions = statworkstation0.HungSessions,
                InitiallyFailedOperations = statworkstation0.InitiallyFailedOperations,
                Lanman20Connects = statworkstation0.Lanman20Connects,
                Lanman21Connects = statworkstation0.Lanman21Connects,
                LanmanNtConnects = statworkstation0.LanmanNtConnects,
                LargeReadSmbs = statworkstation0.LargeReadSmbs,
                LargeWriteSmbs = statworkstation0.LargeWriteSmbs,
                NetworkErrors = statworkstation0.NetworkErrors,
                NetworkReadBytesRequested = statworkstation0.NetworkReadBytesRequested,
                NetworkWriteBytesRequested = statworkstation0.NetworkWriteBytesRequested,
                NonPagingReadBytesRequested = statworkstation0.NonPagingReadBytesRequested,
                NonPagingWriteBytesRequested = statworkstation0.NonPagingWriteBytesRequested,
                PagingReadBytesRequested = statworkstation0.PagingReadBytesRequested,
                PagingWriteBytesRequested = statworkstation0.PagingWriteBytesRequested,
                RandomReadOperations = statworkstation0.RandomReadOperations,
                RawReadsDenied = statworkstation0.RawReadsDenied,
                RandomWriteOperations = statworkstation0.RandomWriteOperations,
                RawWritesDenied = statworkstation0.RawWritesDenied,
                ReadOperations = statworkstation0.ReadOperations,
                ReadSmbs = statworkstation0.ReadSmbs,
                Reconnects = statworkstation0.Reconnects,
                ServerDisconnects = statworkstation0.ServerDisconnects,
                Sessions = statworkstation0.Sessions,
                SmallReadSmbs = statworkstation0.SmallReadSmbs,
                SmallWriteSmbs = statworkstation0.SmallWriteSmbs,
                SmbsReceived = statworkstation0.SmbsReceived,
                SmbsTransmitted = statworkstation0.SmbsTransmitted,
                StatisticsStartTime = statworkstation0.StatisticsStartTime,
                UseCount = statworkstation0.UseCount,
                WriteOperations = statworkstation0.WriteOperations,
                WriteSmbs = statworkstation0.WriteSmbs
            };
        }
    }
}