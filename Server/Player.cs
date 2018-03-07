using Server.Interface;
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
    internal delegate void RecivedDataDelegate(Player player,string data);
    internal delegate void DisconectedDelegate(Player player);

    class Player : IUser, IDisposable
    {
        public string Name { get; set; }
        public EndPoint IPAdress { get; set; }
        public Thread PlayerThread { get; private set; }
        public event RecivedDataDelegate onRecivedData;
        public event DisconectedDelegate onDisconected;
        public UserStates state { get; private set; }

        private Socket socket;

        public Player(Socket sck, EndPoint IP, string name = null)
        {
            socket = sck;
            IPAdress = IP;
            if (name == null)
                Name = IPAdress.ToString();
            else
                Name = name;

            PlayerThread = new Thread(ReciveDateFromPlayer);
            PlayerThread.Start();
            state = UserStates.Connected;
        }

        public void SendDataToPlayer(string dataToSend)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(dataToSend);
            socket.Send(buffer, 0, buffer.Length, 0);
        }

        public override string ToString()
        {
            return Name + " : " +  state.ToString();
        }

        public void Dispose()
        {
            socket.Close();
            socket.Dispose();
        }

        private void ReciveDateFromPlayer()
        {
            byte[] buffer = new byte[1024];
            int dataRecivedLength = 0;
            string recivetData = string.Empty;

            while (true)
            {
                do
                {
                    try
                    {
                        dataRecivedLength = socket.Receive(buffer, 0, buffer.Length, 0);
                        recivetData += Encoding.ASCII.GetString(buffer, 0, dataRecivedLength);
                    }
                    catch (SocketException ex)
                    {
                        Console.WriteLine("Unexpected Disconection with user. StacTrace:\n" + ex.StackTrace);
                        onDisconected(this);
                        return;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error while reciving data from user. StacTrace:\n" + ex.StackTrace);
                    }
                } while (dataRecivedLength == buffer.Length);

                onRecivedData(this, recivetData);
            }
        }
    }
}
