using System.Collections.Generic;

namespace Hextech.LeagueClient.Models.Matchmaking
{
    public class SearchResource
    {
        public DodgeData DodgeData { get; set; }
        public List<SearchError> Errors { get; set; }
        public float EstimatedQueueTime { get; set; }
        public bool IsCurrentlyInQueue { get; set; }
        public string LobbyId { get; set; }
        public LowPriorityData LowPriorityData { get; set; }
        public long QueueId { get; set; }
        public ReadyCheck ReadyCheck { get; set; }
        public SearchState SearchState { get; set; }
        public float TimeInQueue { get; set; }
    }

    public enum SearchState
    {
        Invalid,
        AbandonedLowPriorityQueue,
        Canceled,
        Searching,
        Found,
        Error,
        ServiceError,
        ServiceShutdown
    }
}
