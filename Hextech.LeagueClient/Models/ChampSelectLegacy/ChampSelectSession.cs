using System;
using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.ChampSelectLegacy
{
    public class ChampSelectSession
    {
        public List<List<Action>> Actions { get; set; }
        public bool AllowBattleBoost { get; set; }
        public bool AllowDuplicatePicks { get; set; }
        public bool AllowRerolling { get; set; }
        public bool AllowSkinSelection { get; set; }
        public BannedChampions Bans { get; set; }
        public List<Int32> BenchChampionIds { get; set; }
        public bool BenchEnabled { get; set; }
        public long BoostableSkinCount { get; set; }
        public ChatRoomDetails ChatDetails { get; set; }
        public long Counter { get; set; }
        public bool IsSpectating { get; set; }
        public long LocalPlayerCellId { get; set; }
        public List<PlayerSelection> MyTeam { get; set; }
        public long RerollsRemaining { get; set; }
        public List<PlayerSelection> TheirTeam { get; set; }
        public ChampSelectTimer Timer { get; set; }
        public List<TradeContract> Trades { get; set; }
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

    public class BannedChampions
    {
        public List<Int32> MyTeamBans { get; set; }
        public long NumBans { get; set; }
        public List<Int32> TheirTeamBans { get; set; }
    }

    public class ChatRoomDetails
    {
        public string ChatRoomName { get; set; }
        public string ChatRoomPassword { get; set; }
    }

    public class PlayerSelection
    {
        public string AssignedPosition { get; set; }
        public long CellId { get; set; }
        public long ChampionId { get; set; }
        public long ChampionPickIntent { get; set; }
        public string PlayerType { get; set; }
        public long SelectedSkinId { get; set; }
        public long Spell1Id { get; set; }
        public long Spell2Id { get; set; }
        public long SummonerId { get; set; }
        public long Team { get; set; }
        public long WardSkinId { get; set; }
    }

    public class ChampSelectTimer
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

    public class TradeContract
    {
        public long CellId { get; set; }
        public long Id { get; set; }
        public string State { get; set; }
    }
}
