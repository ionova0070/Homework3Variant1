using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    internal class PrivateChat : Chat, IMessageManager
    {
    	private Guid _idOfCreator;
    	private Guid _idOfCompanion;
    	
        internal PrivateChat(Guid idOfCreator, Guid idOfCompanion)
        {
            _idOfCreator = idOfCreator;
            _idOfCompanion = idOfCompanion;
        }
            	
		public void SendMessage(Guid idOfSender, string textOfMessage)
		{
			if ((idOfSender == _idOfCreator) || (idOfSender == _idOfCompanion))
			{
				Guid IdOfMessage = Guid.NewGuid();
				_messages.Add(IdOfMessage, new Message(idOfSender, textOfMessage, DateTime.Now, IdOfMessage));
			}
			else
			{
				throw new NotSupportedException("Вы не можете отправить сообщение, не находясь в этом чате");
			}
			
		}
    	
		public void DeleteMessage(Guid idOfUser, Guid idOfMessage)
		{
			Guid IdOfSender = _messages[idOfMessage].IdOfSender;
			if (idOfUser == IdOfSender)
			{
				_messages.Remove(idOfMessage);
			}
			else
			{
				throw new NotSupportedException("Вы не можете удалить чужое сообщение");
			}
		}
    }
}
