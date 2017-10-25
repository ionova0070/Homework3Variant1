using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class Message
    {
        User _user;
        string _message;
        DateTime _timeOfSending;

        public Message(User creatorOfMessage, string message)
        {
            _user = creatorOfMessage;
            _message = message;
            _timeOfSending = DateTime.Now;
        }

        public void EditMessage(string newText)
        {
            _message = newText;
        }

        public Guid GetIDSender()
        {
            return _user.ID;
        }
    }
}
