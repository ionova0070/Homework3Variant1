using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class PrivateChat : Chat
    {
    	User _creator;
    	User _companion;
    	
        public PrivateChat(User creator, User companion)
        {
            _creator = creator;
            _companion = companion;
        }
    }
}
