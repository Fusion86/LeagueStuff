namespace Hextech.LeagueClient.Apis
{
    public abstract class ApiBase
    {
        protected LeagueClient m_client;

        public ApiBase(LeagueClient client)
        {
            m_client = client;
        }
    }
}
