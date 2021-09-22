using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client1 client1 = new Client1();
            try
            {

                client1.connectToServer();
                string sms = Console.ReadLine();
                client1.sendMsg(sms);
                client1.getMsg();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
