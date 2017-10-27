using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public class User
    {
        internal string NickName { get; private set; }
        internal Guid ID { get; private set; }
        
        internal User(string nickName, Guid id)
        {
            NickName = nickName;
            ID = id;
        }
    }
}
