using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class LeagueGramFacade
    {
        public void CreatePrivateChat(User creator)
        {
            PrivateChat PrivateChat = new PrivateChat(creator);            
        }

        public void CreateGroupChat(User creator)
        {
            GroupChat GroupChat = new GroupChat(creator);
        }
   
        public void CreateChannel(User creator)
        {
            Channel Channel = new Channel(creator);
        }



        public void InviteUser(User user, GroupChat groupeChat)
        {
            groupeChat.AddUser(user);
        }
        public void InviteUser(User user, PrivateChat privateChat)
        {
            privateChat.AddUser(user);
        }
        public void InviteUser(User user, Channel channel)
        {
            channel.AddUser(user);
        }



        public void SendMessage(string messageText, User sender, GroupChat groupChat)
        {
            groupChat.SendMessage(messageText, sender);
        }
        public void SendMessage(string messageText, User sender, PrivateChat privateChat)
        {
            privateChat.SendMessage(messageText, sender);
        }
        public void SendMessage(string messageText, User sender, Channel channel)
        {
            channel.SendMessage(messageText, sender);
        }



        public void EditMessage(User user, Message message, string newTextOfMessage, GroupChat groupChat)
        {
            groupChat.EditMessage(message, user, newTextOfMessage);
        }
        public void EditMessage(User user, Message message, string newTextOfMessage, PrivateChat privateChat)
        {
            privateChat.EditMessage(message, user, newTextOfMessage);
        }
        public void EditMessage(User user, Message message, string newTextOfMessage, Channel channel)
        {
            channel.EditMessage(message, user, newTextOfMessage);
        }



        public void DeleteMessage(User user, Message message, GroupChat groupChat)
        {
            groupChat.DeleteMessage(user, message);
        }
        public void DeleteMessage(User user, Message message, PrivateChat privateChat)
        {
            privateChat.DeleteMessage(user, message);
        }
        public void DeleteMessage(User user, Message message, Channel channel)
        {
            channel.DeleteMessage(user, message);
        }



        public void ChangeFromUserToAdmin(User userMakingChanging, User userWithOldRole, GroupChat groupChat)
        {
            groupChat.ChangeRole(userWithOldRole, userMakingChanging, "Admin");
        }
        public void ChangeFromAdminToUser(User userMakingChanging, User userWithOldRole, Channel channel)
        {
            channel.ChangeRole(userWithOldRole, userMakingChanging, "User");
        }



        public void ChangeFromUserToAdmin(User userMakingChanging, User userWithOldRole, GroupChat groupChat)
        {
            groupChat.ChangeRole(userWithOldRole, userMakingChanging, "Admin");
        }
        public void ChangeFromAdminToUser(User userMakingChanging, User userWithOldRole, Channel channel)
        {
            channel.ChangeRole(userWithOldRole, userMakingChanging, "User");
        }
    }
}
