using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class Message
    {
    	internal Guid IdOfSender { get; private set; }
    	internal Guid IdOfMessage { get; private set; }
    	internal string TextOfMessage { get; set; }
        private DateTime _timeOfSending;

        internal Message(Guid idOfSender, string message, DateTime timeOfSending, Guid idOfMessage)
        {
            IdOfSender = idOfSender;
            IdOfMessage = idOfMessage;
            TextOfMessage = message;
            _timeOfSending = timeOfSending;
        }

        internal void EditMessage(string newText)
        {
            TextOfMessage = newText;
        }
    }
}
