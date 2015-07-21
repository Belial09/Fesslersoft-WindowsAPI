namespace Fesslersoft.WindowsAPI.Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var myShareInfo502 = new ShareInfo502();

            //string shareName = "DCMLog";
            //string shareDesc = "This is a test share of me";
            //string path = @"C:\DCMLog"; // do not append comma, it'll fail

            //myShareInfo502.NetName = shareName;
            //myShareInfo502.ShareType = Enum.ShareType.STYPE_DISKTREE;
            //myShareInfo502.Remark = shareDesc;
            //myShareInfo502.Permissions = Enum.SharePermissions.ACCESS_ALL;    // ignored for user-level security
            //myShareInfo502.MaxUsers = -1;
            //myShareInfo502.CurrentUsers= 0;    // ignored for set
            //myShareInfo502.Path = path;
            //myShareInfo502.Password= null;        // ignored for user-level security
            //myShareInfo502.Reserved= 0;
            //myShareInfo502.SecurityDescriptor = IntPtr.Zero;

            //var result = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetShareAdd.CreateNetworkShare("localhost", myShareInfo502);

            //while (true)
            //{
            //    Application.DoEvents();

            //    var shares = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetShareEnum.GetNetShares("localhost");

            //    foreach (var shareInfo2 in shares)
            //    {
            //        var connections = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetConnectionEnum.GetNetConnections("localhost", shareInfo2.NetName);
            //        foreach (var connectionInfo1 in connections)
            //        {
            //            Console.WriteLine("{0};{1};{2};{3};{4};{5};{6};", connectionInfo1.ConnectionId, connectionInfo1.NetName, connectionInfo1.NumberOfOpens, connectionInfo1.NumberOfUsers, connectionInfo1.ConnectionTime, Enum.GetName(typeof(Managed.Helpers.Enum.ShareType),connectionInfo1.ConnectionType), connectionInfo1.UserName);
            //        }
            //        var xxx = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetFileEnum.GetNetFileList("localhost");
            //        foreach (var fileInfo3 in xxx)
            //        {

            //        }

            //    }
            //    System.Threading.Thread.Sleep(15000);
            //}
        }
    }
}