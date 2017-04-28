using System;
using System.Net.Http;
using Steeltoe.Discovery.Client;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace studentms
{
	public class Client : IClient
	{

		private DiscoveryHttpClientHandler handler;

		private const string GRAB_SERVICE_URL_BASE = "http://StudentFee/fee/";

		public Client(IDiscoveryClient client)
		{
			this.handler = new DiscoveryHttpClientHandler(client);
		}

		private HttpClient CreateHttpClient()
		{
			return new HttpClient(this.handler, false);
		}

		public async Task<string> GetFee()
		{
			string fee;
			using (HttpClient client = this.CreateHttpClient())
			{
				var result = await client.GetStringAsync(GRAB_SERVICE_URL_BASE);
				List<Dictionary<string, string>> history = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(result);
				fee = (history[0]["at"]);
			}
			return fee;
		}
	}
}

