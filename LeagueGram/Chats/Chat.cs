using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public abstract class Chat
    {
        protected List<Message> _messages;

        public void EditMessage(Message message, User user, string newString)
        {
            if (message.GetIDSender() == user.ID)
            {
                message.EditMessage(newString);
            }
        }
    }
}
