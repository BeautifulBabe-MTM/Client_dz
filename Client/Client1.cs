using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Client1
    {
        public string ipAddr;
        public int port;
        public IPEndPoint iPEndPoint;
        public StringBuilder stringBuilder;
        public Socket socket;
        public int bytes;
        public byte[] data;

        public Client1()
        {
            this.ipAddr = "127.0.0.1";
            this.port = 8000;

            this.iPEndPoint = new IPEndPoint(IPAddress.Parse(ipAddr), port);
            this.stringBuilder = new StringBuilder();
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
          

        }
        public void connectToServer()
        {
            this.socket.Connect(iPEndPoint);
        }
        public void sendMsg(string sms)
        {
            this.data = Encoding.Unicode.GetBytes(sms);
            this.socket.Send(data);
        }
        public void getMsg()
        {
            int bytes = 0;
            byte[] data = new byte[256];
            do
            {
                bytes = socket.Receive(data);
                this.stringBuilder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (socket.Available > 0);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}