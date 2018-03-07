using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Interface
{
    enum MessageTypes
    {
        AcquirePlayersList,
        SendMessageToPlayer,
        ProposeGameToPlayer,
        AcceptGameFromPlayer,
        SendGameInfo,
        EndGame,
        EndConnection,
    }
    interface IMessage
    {
        MessageTypes Type { get; }
        string Sender { get; }
        string Receiver { get; }
        string Content { get; }
    }
}
