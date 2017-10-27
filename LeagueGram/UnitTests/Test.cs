using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeagueGram
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void SendMessageToPrivateChatReturnTrue()
		{
			bool Expected = true;
			Guid IdOfCreator = Guid.NewGuid();
			Guid IdOfCompanion = Guid.NewGuid();
			PrivateChat TestingChat = new PrivateChat(IdOfCreator, IdOfCompanion);
			
			bool Actual;
			TestingChat.SendMessage(IdOfCreator, "Test");
			if (TestingChat.IsHistoryEmpty())
			{
				Actual = false;
			}
			else
			{
				Actual = true;
			}
			
			Assert.AreEqual(Expected, Actual);
		}
		
		[ExpectedException(typeof(NotSupportedException)), Test]
		public void SendMessageToPrivateChatByUserNotFromThisChat()
		{
			Guid IdOfCreator = Guid.NewGuid();
			Guid IdOfCompanion = Guid.NewGuid();
			PrivateChat TestingChat = new PrivateChat(IdOfCreator, IdOfCompanion);
			
			TestingChat.SendMessage(Guid.NewGuid(), "Test");
			
		}
		
		[Test]
		public void SendMessageAdminToGroupReturnTrue()
		{
			bool Expected = true;
			Guid IdOfCreator = Guid.NewGuid();
			GroupChat TestingChat = new GroupChat(IdOfCreator);
			
			bool Actual;
			TestingChat.SendMessage(IdOfCreator, "Test");
			if (TestingChat.IsHistoryEmpty())
			{
				Actual = false;
			}
			else
			{
				Actual = true;
			}
			
			Assert.AreEqual(Expected, Actual);
		}
		
		[ExpectedException(typeof(NotSupportedException)), Test]
		public void SendMessageToGroupChatByUserNotFromThisChat()
		{
			Guid IdOfCreator = Guid.NewGuid();
			GroupChat TestingChat = new GroupChat(IdOfCreator);
			
			TestingChat.SendMessage(Guid.NewGuid(), "Test");
			
		}
		
		[Test]
		public void SendMessageAdminToChannelReturnTrue()
		{
			bool Expected = true;
			Guid IdOfCreator = Guid.NewGuid();
			Channel TestingChat = new Channel(IdOfCreator);
			
			bool Actual;
			TestingChat.SendMessage(IdOfCreator, "Test");
			if (TestingChat.IsHistoryEmpty())
			{
				Actual = false;
			}
			else
			{
				Actual = true;
			}
			
			Assert.AreEqual(Expected, Actual);
		}
		
		[ExpectedException(typeof(NotSupportedException)), Test]
		public void SendMessageNotAdminToChannelReturnTrue()
		{
			Guid IdOfCreator = Guid.NewGuid();
			Channel TestingChat = new Channel(IdOfCreator);
			
			TestingChat.SendMessage(Guid.NewGuid(), "Test");
		}
	}
}
