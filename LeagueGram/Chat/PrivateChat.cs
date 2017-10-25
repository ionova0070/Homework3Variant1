using LeagueGram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class PrivateChat : Chat, AddUser, DeleteMessage
    {
        public PrivateChat(User creator)
        {
            _creator = creator;
            _users = new List<User>();
            _possibleSenders = new List<User>();
        }

        public void AddUser(User user)
        {
            if (_users.Count < 2)
            {
                _users.Add(user);
                _possibleSenders.Add(user);
            }
            
        }

        public void DeleteMessage(User user, Message message)
        {
            if (message.GetIDSender() == user.ID)
            {
                _messages.Remove(message);
            }
        }
    }
}
