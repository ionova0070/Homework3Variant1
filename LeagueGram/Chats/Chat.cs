using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public abstract class Chat 
    {
        protected Dictionary<Guid, Message> _messages;
        
        public Chat()
        {
        	_messages = new Dictionary<Guid, Message>();
        }

        internal void EditMessage(Guid idOfMessage, Guid idOfUser, string newText)
        {
        	Guid IdOfSender = _messages[idOfMessage].IdOfSender;
            
        	if (IdOfSender == idOfUser)
            {
            	_messages[idOfMessage].EditMessage(newText);
            	_messages = new Dictionary<Guid, Message>();
            }
        }
        
        internal bool IsHistoryEmpty()
        {
        	if (_messages.Count == 0)
        	{
        		return true;
        	}
        	else
        	{
        		return false;
        	}
        }
    }
}
