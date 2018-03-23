using Ahri.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;
using Ahri.Apis;

namespace Ahri
{
    public class LeagueClientApi
    {
        public readonly RiotClient RiotClient;
        public readonly ChampSelect ChampSelect;

        private readonly string _username;
        private readonly string _password;
        private readonly int _port;

        private readonly RestClient _client;

        public LeagueClientApi(string password, int port)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            _username = "riot";
            _password = password;
            _port = port;

            _client = new RestClient("https://127.0.0.1:" + _port);
            _client.Authenticator = new HttpBasicAuthenticator(_username, _password);

            RiotClient = new RiotClient(this);
            ChampSelect = new ChampSelect(this);
        }

        /// <summary>
        /// For endpoints that return a plain string
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Execute(RestRequest request)
        {
            var response = _client.Execute(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Content.Substring(1, response.Content.Length - 2); // Remove first and last "
        }

        /// <summary>
        /// For endpoints that return an object/model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }

        #region v1

        public ApiDocs GetApiDocs()
        {
            RestRequest request = new RestRequest();
            request.Resource = "/v1/api-docs";
            return Execute<ApiDocs>(request);
        }

        #endregion

    }
}
