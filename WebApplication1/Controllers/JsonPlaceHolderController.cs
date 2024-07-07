using JsonPost.Models;
using JsonPost.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Placeholder/api")]
    public class JsonPlaceHolderController : Controller
    {
        public IConfiguration _config;
        private readonly IAddJsonPosts _posts;
        private readonly IDbOperations _dbOperations;
        public JsonPlaceHolderController(IConfiguration config, IAddJsonPosts posts, IDbOperations dbOperations) { 
            _config = config;
            _posts = posts;
            _dbOperations = dbOperations;

       }

        [HttpGet]
        public async Task<IActionResult> GetPosts() 
        {
            int sucesscount = 0;
            try
            {
                IEnumerable<Post> result = await _posts.GetAllPosts();
                foreach (var post in result) { 
                    bool success = _dbOperations.InsertPosts(post);
                    if (success) { 
                        sucesscount++;
                    }
                }
                return Ok();
                

            }
            catch (Exception ex) {
                return null;
            }

            
        }
    }
}
