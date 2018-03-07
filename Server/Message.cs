using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Interface;
using System.Text.RegularExpressions;

namespace Server
{
    class Message : IMessage
    {

        #region IMessage implementatnio
        public MessageTypes Type { get; private set; }

        public string Sender { get; private set; }

        public string Receiver { get; private set; }

        public string Content { get; private set; }
        #endregion

        private Regex exMessage = new Regex(@"\<t\>(?<type>\w+)\<t\>\<r\>(?<rciver>[\d.:]+)\<r\>\<c\>(?<content>\w+)\<c\>", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public Message(MessageTypes type, string sender, string receiver, string content)
        {
            Type = type;
            Sender = sender;
            Receiver = receiver;
            Content = content;
        }

        public Message(string rawMessage, string sender)
        {
            Match match = exMessage.Match(rawMessage);
            if (!match.Success)
                throw new Exception("Message is in wrong format.");

            MessageTypes type = GetMessageType(match.Groups["type"].Value);

            Type = type;
            Sender = sender;
            Receiver = match.Groups["rciver"].Value;
            Content = match.Groups["content"].Value;
        }

        public override string ToString()
        {
            return "<t>" + Type.ToString() + "<t><r>" + Receiver + "<r><c>" + Content.Trim() + "<c>";
        }

        private MessageTypes GetMessageType(string value)
        {
            MessageTypes type;

            switch (value.Trim())
            {
                case "AcquirePlayersList":
                    type = MessageTypes.AcquirePlayersList;
                    break;
                case "SendMessageToPlayer":
                    type = MessageTypes.SendMessageToPlayer;
                    break;
                case "ProposeGameToPlayer":
                    type = MessageTypes.ProposeGameToPlayer;
                    break;
                case "AcceptGameFromPlayer":
                    type = MessageTypes.AcceptGameFromPlayer;
                    break;
                case "SendGameInfo":
                    type = MessageTypes.SendGameInfo;
                    break;
                case "EndGame":
                    type = MessageTypes.EndGame;
                    break;
                case "EndConnection":
                    type = MessageTypes.EndConnection;
                    break;
                default:
                    throw new Exception("Message type unrecognized.");
            }

            return type;
        }

    }
}
