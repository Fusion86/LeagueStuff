using Hextech.LeagueClient.Models;
using System;

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
