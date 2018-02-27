using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    class Listener
    {
        Socket sck;
        IPEndPoint endPoint;

        public Listener(string iPAdress, int portnumber)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IPAddress.Parse("iPAdress"), portnumber);
#if DEBUG
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994);
#endif
        }

        public void Connect()
        {
            try
            {
                sck.Connect(endPoint);
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to Connect.\n" + e.StackTrace);
            }
        }
    }
}
