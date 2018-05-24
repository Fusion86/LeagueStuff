namespace Hextech.LeagueClient.Models
{
    public class LeagueClientError
    {
        public LeagueClientErrorCode ErrorCode { get; set; }
        public int HttpStatus { get; set; }
        public string Message { get; set; }
    }

    public enum LeagueClientErrorCode
    {
        RESOURCE_NOT_FOUND,
        RPC_ERROR,
        WRONG_METHOD,
        BAD_REQUEST,
        BAD_REQUEST_FORMAT
    }
}
