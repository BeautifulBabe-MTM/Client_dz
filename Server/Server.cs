using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            Server1 server1 = new Server1();
            Console.WriteLine("Start server please wait...");
            try
            {
                server1.Bind();
                server1.GetMsg();
                server1.sendMsg("got it");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
