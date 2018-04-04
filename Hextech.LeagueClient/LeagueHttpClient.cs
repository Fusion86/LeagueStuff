using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueHttpClient
    {
        private HttpClient m_client;

        private int m_port;

        public LeagueHttpClient()
        {
            // Accept untrusted SSL certs
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            m_client = new HttpClient(handler);
        }

        public async Task<bool> Login(string password, int port)
        {
            m_port = port;

            var byteArray = Encoding.ASCII.GetBytes("riot:" + password);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            try
            {
                await GetAsync("/lol-chat/v1/me");
            }
            catch (Exception ex)
            {
                // Put a breakpoint here if something stops working and look at 'ex'
                return false;
            }

            return true;
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
