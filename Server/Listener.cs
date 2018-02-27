using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Listener
    {
        public Socket ListiningSocket { get; set; }

        public Listener()
        {
            ListiningSocket = Socket();
            IPEndPoint endPoint = new IPEndPoint(0, 1994);
            ListiningSocket.Bind(endPoint);
        }

        Socket Socket()
        {
            return new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void StartListening()
        {
            while (true)
            {
                try
                {
                    ListiningSocket.Listen(0);
                    Socket sck = ListiningSocket.Accept();
                    new Thread(AcceptConnection).Start(sck);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Problem with listening or accepting of client requests.\n" + ex.StackTrace);
                }
            }
        }

        private void AcceptConnection(object socket)
        {
            byte[] buffer = new byte[1024];
            try
            {
                Socket sck = (Socket)socket;
                EndPoint clientEndPoint = sck.RemoteEndPoint;
                string endpoint = clientEndPoint.ToString();
                string str = string.Empty;
                while (true)
                { 
                    int a = sck.Receive(buffer, 0, buffer.Length, 0);
                    Console.WriteLine("Połączony!");
                    str = Encoding.ASCII.GetString(buffer, 0, a);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem with reciving data from client.\n" + ex.StackTrace);
            }
        }
    }
}
