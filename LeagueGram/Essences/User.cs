using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram
{
    public struct User
    {
        public string NickName { get; private set; }
        public Guid ID { get; private set; }
        public User(string nickName)
        {
            NickName = nickName;
            ID = Guid.NewGuid();
        }
    }
}
