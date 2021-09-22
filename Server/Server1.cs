using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Server1
    {
        public int port;
        public IPEndPoint iPEndPoint;
        public Socket socket;
        public Socket socketClient;
        public StringBuilder stringBuilder; 
        public byte[] data;

        public Server1()
        {
            this.port = 8000;
            this.iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.stringBuilder = new StringBuilder();
            this.data = new byte[256];
        }
  
        public void ShutDown()
        {
            this.socket.Shutdown(SocketShutdown.Both);
            this.socket.Close();
        }
        public void Bind()
        {

            this.socket.Bind(iPEndPoint); 
            this.socket.Listen(10);
            this.socketClient = socket.Accept();
        }
        public void sendMsg(string sms)
        {
            this.data = Encoding.Unicode.GetBytes(sms);
            this.socketClient.Send(data);
        }
        public void GetMsg()
        {
            int bytes = 0;
            byte[] data = new byte[256];
            this.stringBuilder.Clear();
            do
            {
                bytes = socketClient.Receive(data);
                stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socketClient.Available > 0);
            socketClient.Send(Encoding.Unicode.GetBytes("Welcome to the server..."));
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
