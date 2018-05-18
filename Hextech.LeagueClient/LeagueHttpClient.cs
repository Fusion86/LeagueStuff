﻿using Hextech.LeagueClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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

        private string GetFullUrl(string path)
        {
            return "https://127.0.0.1:" + Port + path;
        }

        public async Task<HttpResponseMessage> GetAsync(string path)
        {
            return await m_client.GetAsync(GetFullUrl(path));
        }

        public async Task<T> GetAsync<T>(string path)
        {
            Contract.Requires(typeof(T) is ILeagueClientModel || typeof(T) is IList<ILeagueClientModel>);

            HttpResponseMessage res = await m_client.GetAsync(GetFullUrl(path));

            if (res.IsSuccessStatusCode)
            {
                string str = await res.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<T>(str);
                return obj;
            }
            else
            {
                return default(T);
            }
        }

        public async Task<HttpResponseMessage> PostAsync(string path, FormUrlEncodedContent content)
        {
            return await m_client.PostAsync(GetFullUrl(path), content);
        }
    }
}
