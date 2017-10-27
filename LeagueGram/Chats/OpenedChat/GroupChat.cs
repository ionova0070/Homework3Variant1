using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    internal class GroupChat : OpenedChat, IMessageManager
    {
    	internal GroupChat(Guid idOfCreator) : base(idOfCreator)
        {
    		_idOfCreator = idOfCreator;
    		_users.Add(idOfCreator);
        }
    	
		public void SendMessage(Guid idOfSender, string textOfMessage)
		{
			Guid IdOfMessage = Guid.NewGuid();
			if (IsUserFromThisChat(idOfSender))
			{
				_messages.Add(IdOfMessage, new Message(idOfSender, textOfMessage, DateTime.Now, IdOfMessage));
			}
			else
			{
				throw new NotSupportedException("Вы не можете отправить сообщение, не находясь в этой группе");
			}
		}
    	
		public void DeleteMessage(Guid idOfUser, Guid idOfMessage)
		{
			Guid IdOfSender = _messages[idOfMessage].IdOfSender;
			
			if (IsUserAdmin(idOfUser) || (IdOfSender == idOfUser))
			{
				_messages.Remove(idOfMessage);
			}
			else
			{
				throw new NotSupportedException("Вы не можете удалить чужое сообщение, не являясь администратором");
			}
		}
    }
}
