using LeagueGram.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class GroupChat : Chat, AddUser, DeleteMessage
    {
        public GroupChat(User creator)
        {
            _creator = creator;
            _users = new List<User>();
            _admins = new List<User>();
            _possibleSenders = new List<User>();
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            _possibleSenders.Add(user);
        }

        public void DeleteMessage(User user, Message message)
        {
            foreach (User admin in _admins)
            {
                if (user.ID == admin.ID)
                {
                    _messages.Remove(message);
                }
            }
        }

        public void ChangeRole(User userWithOldRole, User userMakingChanging, string role)
        {
            if (userMakingChanging.ID == _creator.ID)
            {
                bool IsAnotherRole = true;
                if (String.Equals(role, "Admin"))
                {
                    foreach (User admin in _admins)
                    {
                        if (admin.ID == userWithOldRole.ID)
                        {
                            IsAnotherRole = IsAnotherRole && false;
                        }
                    }

                    if (IsAnotherRole)
                    {
                        _admins.Remove(userWithOldRole);
                    }
                }
                else if (String.Equals(role, "User"))
                {
                    foreach (User user in _users)
                    {
                        if (user.ID == userWithOldRole.ID)
                        {
                            IsAnotherRole = IsAnotherRole && false;
                        }
                    }

                    if (IsAnotherRole)
                    {
                        _admins.Add(userWithOldRole);
                    }
                }
            }
        }
    }
}
