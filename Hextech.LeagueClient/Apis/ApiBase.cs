namespace Hextech.LeagueClient.Apis
{
    public abstract class ApiBase
    {
        protected LeagueHttpClient m_client;

        public ApiBase(LeagueHttpClient client)
        {
            m_client = client;
        }
    }
}
