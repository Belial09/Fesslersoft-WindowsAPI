using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using Fesslersoft.WindowsAPI.Managed.DataTypes;

namespace Fesslersoft.WindowsAPI.Tester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Application.DoEvents();

                var shares = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetShareEnum.GetNetShares("localhost");

                foreach (var shareInfo2 in shares)
                {
                    var connections = Fesslersoft.WindowsAPI.Managed.NetworkShareManagementFunctions.NetConnectionEnum.GetNetConnections("localhost", shareInfo2.NetName);
                    foreach (var connectionInfo1 in connections)
                    {
                        Console.WriteLine("{0};{1};{2};{3};{4};{5};{6};", connectionInfo1.ConnectionId, connectionInfo1.NetName, connectionInfo1.NumberOfOpens, connectionInfo1.NumberOfUsers, connectionInfo1.ConnectionTime, Enum.GetName(typeof(Managed.Helpers.Enum.ShareType),connectionInfo1.ConnectionType), connectionInfo1.UserName);
                    }
                }
                System.Threading.Thread.Sleep(15000);
            }
        }
    }
}