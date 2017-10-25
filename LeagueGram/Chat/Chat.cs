using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public abstract class Chat
    {
        protected List<User> _users;
        protected List<User> _admins;
        protected List<User> _possibleSenders;
        protected List<Message> _messages;
        protected User _creator;

        public void SendMessage(string message, User sender)
        {
            foreach (User user in _possibleSenders)
            {
                if (user.ID == sender.ID)
                {
                    _messages.Add(new Message(sender, message));
                }
            }
        }

        public void EditMessage(Message message, User user, string newString)
        {
            if (message.GetIDSender() == user.ID)
            {
                message.EditMessage(newString);
            }
        }
    }
}
