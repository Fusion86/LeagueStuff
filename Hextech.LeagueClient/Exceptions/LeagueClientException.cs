using System;
using Hextech.LeagueClient.Models;

namespace Hextech.LeagueClient.Exceptions
{
    public class LeagueClientException : Exception
    {
        public LeagueClientError Error { get; }

        public LeagueClientException(LeagueClientError error) : base(error.Message)
        {

        }
    }
}
