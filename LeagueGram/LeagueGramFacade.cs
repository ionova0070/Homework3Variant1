using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class LeagueGramFacade
    {
    	private Dictionary<Guid, User> _users;
    	private Dictionary<Guid, GroupChat> _groups;
    	private Dictionary<Guid, Channel> _channels;
    	private Dictionary<Guid, PrivateChat> _privateChats;
    	
    	public LeagueGramFacade()
    	{
    		_users = new Dictionary<Guid, User>();
    		_groups = new Dictionary<Guid, GroupChat>();
    		_channels = new Dictionary<Guid, Channel>();
    		_privateChats = new Dictionary<Guid, PrivateChat>();
    	}
    	
    	public void CheckInNewUser(string nickname)
    	{
    		Guid ID = Guid.NewGuid();
    		User user = new User(nickname, ID);
    		_users.Add(ID, user);
    	}
    	
    	public void CreatePrivateChat(Guid idOfCreator, Guid idOfCompanion)
    	{
    		_privateChats.Add(Guid.NewGuid(), new PrivateChat(idOfCreator, idOfCompanion));
    	}
    	
    	public void CreateGroupChat(Guid idOfCreator)
    	{
    		_groups.Add(Guid.NewGuid(), new GroupChat(idOfCreator));
    	}
    	
    	public void CreateChannel(Guid idOfCreator)
    	{
    		_channels.Add(Guid.NewGuid(), new Channel(idOfCreator));
    	}
    	
    	public void SendMessage(Guid idOfChat, Guid idOfSender, string textOfMessage)
    	{
    		if (_groups.ContainsKey(idOfChat))
    		{
    			_groups[idOfChat].SendMessage(idOfSender, textOfMessage);
    		}
    		else if (_privateChats.ContainsKey(idOfChat))
    		{
    			_privateChats[idOfChat].SendMessage(idOfSender, textOfMessage);
    		}
    		else if (_channels.ContainsKey(idOfChat))
    		{
    			_channels[idOfChat].SendMessage(idOfSender, textOfMessage);
    		}
    		else
    		{
    			throw new NotSupportedException("Такого чата не существует");
    		}
    	}
    	
    	public void EditMessage(Guid idOfChat, Guid idOfUser, Guid idOfMessage, string newText)
    	{
    		if (_groups.ContainsKey(idOfChat))
    		{
    			_groups[idOfChat].EditMessage(idOfMessage, idOfUser, newText);
    		}
    		else if (_privateChats.ContainsKey(idOfChat))
    		{
    			_privateChats[idOfChat].EditMessage(idOfMessage, idOfUser, newText);
    		}
    		else if (_channels.ContainsKey(idOfChat))
    		{
    			_channels[idOfChat].EditMessage(idOfMessage, idOfUser, newText);
    		}
    		else
    		{
    			throw new NotSupportedException("Такого чата не существует");
    		}
    	}
    	
    	public void DeleteMessage(Guid idOfChat, Guid idOfUser, Guid idOfMessage)
    	{
    		if (_groups.ContainsKey(idOfChat))
    		{
    			_groups[idOfChat].DeleteMessage(idOfUser, idOfMessage);
    		}
    		else if (_privateChats.ContainsKey(idOfChat))
    		{
    			_privateChats[idOfChat].DeleteMessage(idOfUser, idOfMessage);
    		}
    		else if (_channels.ContainsKey(idOfChat))
    		{
    			_channels[idOfChat].DeleteMessage(idOfUser, idOfMessage);
    		}
    		else
    		{
    			throw new NotSupportedException("Такого чата не существует");
    		}
    	}
    	
    	public void ChangeRole(Guid idOfChat, Guid idOfTarget, Guid idOfSource)
    	{
    		if (_groups.ContainsKey(idOfChat))
    		{
    			_groups[idOfChat].ChangeRole(idOfSource, idOfTarget);
    		}
    		else if (_channels.ContainsKey(idOfChat))
    		{
    			_channels[idOfChat].ChangeRole(idOfSource, idOfTarget);
    		}
    		else
    		{
    			throw new NotSupportedException("Такого чата не существует");
    		}
    	}
    	
    	public void AddUser(Guid idOfChat, Guid idOfUser)
    	{
    		if (_groups.ContainsKey(idOfChat))
    		{
    			_groups[idOfChat].AddUser(idOfUser);
    		}
    		else if (_channels.ContainsKey(idOfChat))
    		{
    			_channels[idOfChat].AddUser(idOfUser);
    		}
    		else
    		{
    			throw new NotSupportedException("Такого чата не существует");
    		}
    	}
    }
}