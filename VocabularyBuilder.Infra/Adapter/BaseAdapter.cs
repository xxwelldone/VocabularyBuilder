using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VocabularyBuilder.Domain.Interface.Adapter;

namespace VocabularyBuilder.Infra.Adapter
{
    public abstract class BaseAdapter : IBaseAdapter
    {

        protected ILogger<BaseAdapter> _logger;
        protected string _baseUrl;
        protected IConfiguration _configuration;

        protected BaseAdapter(ILogger<BaseAdapter> logger, IConfiguration configuration)
        {

            _logger = logger;
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage?> CallAPI(string url, HttpMethod method, string? body, string? token)
        {
            using (HttpClient client = new HttpClient())
            {
                if (token != null) { client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token); }
                HttpResponseMessage response;

                switch (method.Method)
                {
                    case "GET":
                        response = await client.GetAsync(url);
                        break;
                    case "POST":
                        response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/json"));
                        break;
                    default:
                        throw new ArgumentException("Unsupported HTTP method.");
                }

                return response;
            }
        }

        public async Task<HttpStatusCode> ObterStatusAPI(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                return response.StatusCode;
            }
        }


    }
}

