using JsonPost.Models;
using System.Net.Http;

namespace JsonPost.Services
{
    public class AddJsonPosts : IAddJsonPosts
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
    }
}
