using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Interface
{
    //enum reprezentujacy stany w jakich moze znajdowac sie user
    public enum UserStates
    {
        Connected,
        Playing
    }

    internal interface IUser
    {
        // nazwa uzytkownika
        string Name { get; set; }
        // IPaddres uzytkownika 
        EndPoint IPAdress { get; set; }
        //event wywolywany w przypadku otrzymania wiadomosci od uzytkownika
        event RecivedDataDelegate onRecivedData;
        //event wywolywany w przypadku Rozłączenia z uzytkownikiem
        event DisconectedDelegate onDisconected;
        //watek w kturym wykonywana jest odbieranie informacji od gracza
        Thread PlayerThread { get; }
        //funkcja wysylajaca dane do gracza
        void SendDataToPlayer(string dataToSend);
    }
}
