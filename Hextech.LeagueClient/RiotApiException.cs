using System;

namespace Hextech.LeagueClient
{
    public class RiotApiException : Exception
    {
        public RiotApiException(string msg) : base(msg)
        {

        }
    }
}
