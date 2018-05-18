namespace Hextech.LeagueClient.Models.Matchmaking
{
    public class SearchError
    {
        public string ErrorType { get; set; }
        public int Id { get; set; }
        public string Message { get; set; }
        public long PenalizedSummonerId { get; set; }
        public double PenaltyTimeRemaining { get; set; }
    }
}
