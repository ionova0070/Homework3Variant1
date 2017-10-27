using System;

namespace LeagueGram
{
	internal interface IMessageManager
	{
		void SendMessage(Guid idOfSender, string textOfMessage);
		void DeleteMessage(Guid idOfUser, Guid idOfMessage);
	}
}
