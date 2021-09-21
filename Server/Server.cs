using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server
    {
        static int port = 8000;
        static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Start server please wait...");
            try
            {
                socket.Bind(iPEndPoint);
                socket.Listen(10);
                while (true)
                {
                    Socket socketClient = socket.Accept();
                    socketClient.Send(Encoding.Unicode.GetBytes("Welcome to the server..."));
                    StringBuilder stringBuilder = new StringBuilder();
                    int bytes = 0;
                    string[] words;
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = socketClient.Receive(data);
                        stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (socketClient.Available > 0);
                    words = stringBuilder.ToString().Split(' ');
                    Console.WriteLine($"{DateTime.Now}: \"{stringBuilder}\" / {words.Length} words");
                    //socketClient.Send();
                    socketClient.Shutdown(SocketShutdown.Both);
                    socketClient.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
