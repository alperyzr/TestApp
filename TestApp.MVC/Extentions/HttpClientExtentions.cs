using Newtonsoft.Json;
using System.IO;
using System.Net.Mime;
using System.Text;

namespace TestApp.MVC.Extentions;

public static class HttpClientExtensions
{
	public static async Task<T?> CustomPostAsync<T>(this HttpClient client, string url, object request)
	{
		var httpRequest = new HttpRequestMessage
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(url),
			Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
		};

		var response = await client.SendAsync(httpRequest);

		var stringContent = await response.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(stringContent);
	}

	public static async Task<T?> CustomGetAsync<T>(this HttpClient client, string url, object request)
	{
		var httpRequest = new HttpRequestMessage
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(url),
			Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
		};

		var response = await client.SendAsync(httpRequest);

		var stringContent = await response.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(stringContent);
	}

	public static async Task<T?> CustomPutAsync<T>(this HttpClient client, string url, object request)
	{
		var httpRequest = new HttpRequestMessage
		{
			Method = HttpMethod.Put,
			RequestUri = new Uri(url),
			Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
		};

		var response = await client.SendAsync(httpRequest);

		var stringContent = await response.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(stringContent);
	}

	public static async Task<T?> CustomDeleteAsync<T>(this HttpClient client, string url, object request)
	{
		var httpRequest = new HttpRequestMessage
		{
			Method = HttpMethod.Delete,
			RequestUri = new Uri(url),
			Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")
		};

		var response = await client.SendAsync(httpRequest);

		var stringContent = await response.Content.ReadAsStringAsync();

		return JsonConvert.DeserializeObject<T>(stringContent);
	}
}
