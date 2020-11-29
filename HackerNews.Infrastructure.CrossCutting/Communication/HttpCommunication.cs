using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HackerNews.Infrastructure.CrossCutting.Communication
{
    public static class HttpCommunication
    {
        public static async Task<T> GetAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var json = string.Empty;
                try
                {
                    var request = await client.GetAsync(url);
                    request.EnsureSuccessStatusCode();

                    json = await request.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
