using Hextech.LeagueClient.Exceptions;
using Hextech.LeagueClient.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hextech.LeagueClient
{
    public class LeagueHttpClient
    {
        private HttpClient m_client;

        public string Password { get; private set; }
        public int Port { get; private set; }

        public LeagueHttpClient()
        {
            // Accept untrusted SSL certs
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            m_client = new HttpClient(handler);
        }

        public async Task<bool> Login(string password, int port)
        {
            Password = password;
            Port = port;

            var byteArray = Encoding.ASCII.GetBytes("riot:" + password);
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            try
            {
                await GetAsync("/system/v1/builds"); // Uses a path that should always be available, even if the player is not logged in
            }
            catch (Exception ex)
            {
                // Probably wrong username or port, but could be something else
                Debug.WriteLine(ex.Message);

                // Reset password and port
                Password = null;
                Port = 0;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Prefix an url with 'https://127.0.0.1:1234' where 1234 is the port where the LeagueClient is listening on
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFullUrl(string path = "")
        {
            return "https://127.0.0.1:" + Port + path;
        }

        /// <summary>
        /// Request a resource (not necessarily a JSON resource)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            var res = await m_client.GetAsync(GetFullUrl(path));

            if (res.IsSuccessStatusCode) return res;
            else
            {
                string str = await res.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<LeagueClientError>(str);
                throw new LeagueClientException(obj);
            }
        }

        /// <summary>
        /// Request and deserialize a JSON resource
        /// </summary>
        /// <typeparam name="T">Hextech.LeagueClient.Model</typeparam>
        /// <param name="path">Endpoint</param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string path)
        {
            HttpResponseMessage res = await m_client.GetAsync(GetFullUrl(path));
            string str = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode) return JsonConvert.DeserializeObject<T>(str);
            else
            {
                var obj = JsonConvert.DeserializeObject<LeagueClientError>(str);
                throw new LeagueClientException(obj);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string path, HttpContent content = null)
        {
            // Set Content-Type to 'application/json'
            if (content != null)
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var res = await m_client.PostAsync(GetFullUrl(path), content);

            if (res.IsSuccessStatusCode) return res;
            else
            {
                string str = await res.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<LeagueClientError>(str);
                throw new LeagueClientException(obj);
            }
        }

        public async Task<HttpResponseMessage> PutAsync(string path, HttpContent content = null)
        {
            // Set Content-Type to 'application/json'
            if (content != null)
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var res = await m_client.PutAsync(GetFullUrl(path), content);

            if (res.IsSuccessStatusCode) return res;
            else
            {
                string str = await res.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<LeagueClientError>(str);
                throw new LeagueClientException(obj);
            }
        }
    }
}
