using System;
using System.Collections.Generic;

namespace LeagueGram
{
	internal abstract class OpenedChat : Chat
	{
		protected List<Guid> _admins;
	    protected List<Guid> _users;
	    protected Guid  _idOfCreator;
	    
		internal OpenedChat(Guid idOfCreator)
		{
			_admins = new List<Guid>();
			_users = new List<Guid>();
			_idOfCreator = idOfCreator;
			_admins.Add(idOfCreator);
			_messages = new Dictionary<Guid, Message>();
		}
		
		internal void AddUser(Guid idOfUser)
		{
			_users.Add(idOfUser);
		}
		
		internal void ChangeRole(Guid idOfSource, Guid idOfTarget)
		{
			bool IsUserRole;
			
			if (_users.Contains(idOfTarget))
			{
				IsUserRole = true;
			}
			else
			{
				IsUserRole = false;
			}
			
			if (IsUserAdmin(idOfSource)&&IsUserFromThisChat(idOfTarget)&&IsUserRole)
			{
				_admins.Add(idOfTarget);
			}
			else if (IsUserAdmin(idOfSource) && IsUserFromThisChat(idOfTarget) && !IsUserRole)
			{
				_admins.Remove(idOfTarget);
			}
			else
			{
				throw new NotSupportedException();
			}
		}
		
		protected bool IsUserFromThisChat(Guid idOfPossibleUser)
		{
			if (_users.Contains(idOfPossibleUser))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		protected bool IsUserAdmin(Guid idOfPossibleAdmin)
		{
			if (_admins.Contains(idOfPossibleAdmin))
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
