using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Models.Enums;
using Models.Queries;
using PersistentData.ParameterDefinitionsConfiguration;
using Serilog;

namespace Services.ServerList
{
    public class NordVpnServerList : IServerList
    {
        private const string BASE_API_URL = "https://api.nordvpn.com/v1/servers";

        private readonly HttpClient client;

        public NordVpnServerList(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<string> Get(VpnServerQuery query) => await Query(BuildLinkFromQuery(query));

        private string BuildLinkFromQuery(VpnServerQuery query) => query.parameters.Aggregate("",
            (acc, x) => acc + (acc.Length > 0 ? "&filters" : "?filters") + string.Format(HtmlParametersDefinitions.Instance[x.Type], x.Id));

        private async Task<string> Query(string parameters)
        {
            try
            {
                Log.Information("Getting servers from API");
                var request = new HttpRequestMessage(HttpMethod.Get, BASE_API_URL + parameters);
                var response = await client.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception  ex) 
            {
                Log.Error($"Error getting server list: {ex}");
                return null;
            }
        }
    }
}