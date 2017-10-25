using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueGram.Interfaces
{
    public interface DeleteMessage
    {
        public void DeleteMessage(User user, Message message);
    }
}
