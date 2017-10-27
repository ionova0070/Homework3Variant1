using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    internal class Channel : OpenedChat, IMessageManager
    {
    	internal Channel(Guid idOfCreator) : base(idOfCreator)
        {
        }
    	
		public void SendMessage(Guid idOfUser, string textOfMessage)
		{
			Guid IdOfMessage = Guid.NewGuid();
			if (IsUserAdmin(idOfUser))
			{
				_messages.Add(IdOfMessage, new Message(idOfUser, textOfMessage, DateTime.Now, IdOfMessage));
			}
			else
			{
				throw new NotSupportedException("Вы не можете отправить сообщение на канал, не являясь администратором");
			}
		}
    	
		public void DeleteMessage(Guid idOfUser, Guid idOfMessage)
		{
			if (IsUserAdmin(idOfUser))
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
