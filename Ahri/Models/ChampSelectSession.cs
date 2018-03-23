using System.Collections.Generic;

namespace Ahri.Models
{
    public class ChampSelectSession
    {
        public List<List<Action>> Actions { get; set; }
        public bool AllowBattleBoost { get; set; }
        public bool AllowRerolling { get; set; }
        public bool AllowSkinSelection { get; set; }
        public Bans Bans { get; set; }
        public ChatDetails ChatDetails { get; set; }
        public bool IsSpectating { get; set; }
        public long LocalPlayerCellId { get; set; }
        public List<Team> MyTeam { get; set; }
        public long RerollsRemaining { get; set; }
        public List<Team> TheirTeam { get; set; }
        public Timer Timer { get; set; }
        public List<Trade> Trades { get; set; }
    }

    public class Action
    {
        public long ActorCellId { get; set; }
        public long ChampionId { get; set; }
        public bool Completed { get; set; }
        public long Id { get; set; }
        public long PickTurn { get; set; }
        public string Type { get; set; }
    }

    public class Bans
    {
        public List<int> MyTeamBans { get; set; }
        public long NumBans { get; set; }
        public List<int> TheirTeamBans { get; set; }
    }

    public class ChatDetails
    {
        public string ChatRoomName { get; set; }
        public string ChatRoomPassword { get; set; }
    }

    public class Team
    {
        public AssignedPosition AssignedPosition { get; set; }
        public long CellId { get; set; }
        public long ChampionId { get; set; }
        public long ChampionPickIntent { get; set; }
        public string DisplayName { get; set; }
        public PlayerType PlayerType { get; set; }
        public long SelectedSkinId { get; set; }
        public long Spell1Id { get; set; }
        public long Spell2Id { get; set; }
        public long SummonerId { get; set; }
        public long TeamTeam { get; set; }
        public long WardSkinId { get; set; }
    }

    public class Timer
    {
        public long AdjustedTimeLeftInPhase { get; set; }
        public long AdjustedTimeLeftInPhaseInSec { get; set; }
        public long InternalNowInEpochMs { get; set; }
        public bool IsInfinite { get; set; }
        public string Phase { get; set; }
        public long TimeLeftInPhase { get; set; }
        public long TimeLeftInPhaseInSec { get; set; }
        public long TotalTimeInPhase { get; set; }
    }

    public class Trade
    {
        public long CellId { get; set; }
        public long Id { get; set; }
        public string State { get; set; }
    }

    public enum AssignedPosition { Empty };

    public enum PlayerType { Bot, Player };

}