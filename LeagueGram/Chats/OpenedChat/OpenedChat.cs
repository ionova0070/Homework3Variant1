using System;
using System.Collections.Generic;

namespace LeagueGram
{
	public abstract class OpenedChat : Chat
	{
		protected List<User> _admins;
	    protected List<User> _users;
	    protected User _creator;
	    
		public OpenedChat(User creator)
		{
			_admins = new List<User>();
			_users = new List<User>();
			_creator = creator;
			_admins.Add(creator);
		}
		
		public void AddUser(User user)
		{
			_users.Add(user);
		}
		
		public void ChangeRole(User source, User target)
		{
			bool IsUserFromThisChat = false;
			bool IsTargetAdmin = false;
			bool IsUserRole = false;
			
			foreach (User user in _users)
			{
				if (source.ID == user.ID)
				{
					IsUserFromThisChat = IsUserFromThisChat || true;
					IsUserRole = IsUserRole || true;
				}
				else
				{
					IsUserFromThisChat = IsUserFromThisChat || false;
					IsUserRole = IsUserRole || false;
				}
			}
			
			foreach (User admin in _admins)
			{
				if (source.ID == admin.ID)
				{
					IsTargetAdmin = IsTargetAdmin || true;
				}
				else
				{
					IsTargetAdmin = IsTargetAdmin || false;
				}
			}
			
			if (IsTargetAdmin && IsUserFromThisChat && IsUserRole)
			{
				_admins.Add(target);
			}
			else if (IsTargetAdmin && IsUserFromThisChat && !IsUserRole)
			{
				_admins.Remove(target);
			}
			else
			{
				
			}
		}
	}
}
