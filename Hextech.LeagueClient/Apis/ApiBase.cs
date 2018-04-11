namespace Hextech.LeagueClient.Apis
{
    public abstract class ApiBase
    {
        public abstract string Name { get; }

        protected LeagueHttpClient m_client;

        public ApiBase(LeagueHttpClient client)
        {
            m_client = client;
        }

        /// <summary>
        /// Prefix plugin name before path
        /// </summary>
        /// <param name="path">With forward slash. E.g. /v1/config</param>
        /// <returns>E.g. /lol-chat/v1/config</returns>
        protected string GetUrl(string path) => "/" + Name + path;
    }
}
