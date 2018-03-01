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
    internal delegate void PlayerAcceptedDelegate(Player player);

    class Listener : IDisposable
    {
        public Socket ListiningSocket { get; set; }
        public event PlayerAcceptedDelegate onPlayerAccepted;

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
                    AcceptConnection(sck);// ewentualnie mozna uruchomic w nowym watku
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Problem with listening or accepting of client requests.\n" + ex.StackTrace);
                }
            }
        }

        private void AcceptConnection(Socket socket)
        {
            Player player = new Player(socket, socket.LocalEndPoint);
            onPlayerAccepted(player);
        }

        public void Dispose()
        {
            ListiningSocket.Close();
            ListiningSocket.Dispose();
        }
    }
}
