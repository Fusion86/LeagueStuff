using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClientApi
    {
        public System System;

        public bool Initialize(string password, int port)
        {
            LeagueClient client = new LeagueClient();
            client.Initialize(password, port);

            System system = new System(client);

            if (false) // if working
            {
                System = system;
                // init rest

                return true;
            }
            
            return false;
        }
    }
}
