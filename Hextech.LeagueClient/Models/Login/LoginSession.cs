namespace Hextech.LeagueClient.Models.Login
{
    public class LoginSession
    {
        public long AccountId { get; set; }
        public bool Connected { get; set; }
        public string IdToken { get; set; }
        public bool IsNewPlayer { get; set; }
        public string Puuid { get; set; }
        public LoginSessionState State { get; set; }
        public long SummonerId { get; set; }
        public string UserAuthToken { get; set; }
        public string Username { get; set; }
        public object GasToken { get; set; }
        public LoginError Error { get; set; }
        public LoginQueueStatus QueueStatus { get; set; }
    }

    public enum LoginSessionState
    {
        IN_PROGRESS,
        SUCCEEDED,
        LOGGING_OUT,
        ERROR
    }

    public class LoginError
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string MessageId { get; set; }
    }

    public class LoginQueueStatus
    {
        public long ApproximateWaitTimeSeconds { get; set; }
        public long EstimatedPositionInQueue { get; set; }
        public bool IsPositionCapped { get; set; }
    }

    public class Wallet
    {
        public long Ip { get; set; }
        public long Rp { get; set; }
    }

    public class PlatformGeneratedCredentials
    {
        public string Password { get; set; }
        public string Username { get; set; }
        public object GasToken { get; set; }
    }
}
