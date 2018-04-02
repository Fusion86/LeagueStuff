using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueClient
    {
        private HttpClient m_client;

        private int m_port;

        public void Initialize(string password, int port)
        {
            m_port = port;

            NetworkCredential credentials = new NetworkCredential("riot", password);
            HttpClientHandler handler = new HttpClientHandler { Credentials = credentials };
            m_client = new HttpClient(handler);
        }

        public string GetUrl(string path)
        {
            return "https://127.0.0.1:" + m_port + path;
        }

        public async Task<string> GetAsync(string path)
        {
            HttpResponseMessage res = await m_client.GetAsync(GetUrl(path));
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string path, FormUrlEncodedContent content)
        {
            HttpResponseMessage res = await m_client.PostAsync(GetUrl(path), content);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
