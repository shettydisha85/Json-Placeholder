using JsonPost.Models;
using System.Net.Http;

namespace JsonPost.Services
{
    public class JsonPosts : IJsonPosts
    {
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url = "https://jsonplaceholder.org/posts";


                    HttpResponseMessage response = await client.GetAsync(url);


                    response.EnsureSuccessStatusCode();


                    IEnumerable<Post> responseData = await response.Content.ReadFromJsonAsync<IEnumerable<Post>>();

                    return responseData;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        public async Task<string> GetCatFacts()
        {
            using HttpClient client = new HttpClient();
            {
                HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            
        }
    }
}
