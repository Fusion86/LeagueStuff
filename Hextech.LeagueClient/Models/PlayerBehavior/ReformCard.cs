using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.PlayerBehavior
{
    public class ReformCard
    {
        public List<string> ChatLogs { get; set; }
        public List<long> GameIds { get; set; }
        public long Id { get; set; }
        public string PlayerFacingMessage { get; set; }
        public long PunishmentLengthGames { get; set; }
        public long PunishmentLengthTime { get; set; }
        public string PunishmentType { get; set; }
        public string Reason { get; set; }
        public long RestrictedChatGamesRemaining { get; set; }
        public long TimeWhenPunishmentExpires { get; set; }
    }
}
