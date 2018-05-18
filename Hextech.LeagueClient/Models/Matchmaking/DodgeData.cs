namespace Hextech.LeagueClient.Models.Matchmaking
{
    public class DodgeData
    {
        public long DodgerId { get; set; }
        public DodgeState State { get; set; }
    }

    public enum DodgeState
    {
        Invalid,
        PartyDodged,
        StrangerDodged,
        TournamentDodged
    }

    public enum DodgeWarning
    {
        None,
        Warning,
        Penalty
    }
}
