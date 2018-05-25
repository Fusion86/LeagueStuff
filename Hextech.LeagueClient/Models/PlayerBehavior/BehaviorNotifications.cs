using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.PlayerBehavior
{
    public class BanNotification
    {
        public bool DisplayReformCard { get; set; }
        public long Id { get; set; }
        public bool IsPermaBan { get; set; }
        public string Reason { get; set; }
        public PlayerBehaviorNotificationSource Source { get; set; }
        public long TimeUntilBanExpires { get; set; }
    }

    public enum PlayerBehaviorNotificationSource
    {
        Invalid,
        Login,
        ForcedShutdown,
        Message
    }

    public class RestrictionNotification
    {
        public bool DisplayReformCard { get; set; }
        public long GamesRemaining { get; set; }
        public long Id { get; set; }
        public PlayerBehaviorNotificationSource Source { get; set; }
    }
}
