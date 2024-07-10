using JsonPost.Models;
using JsonPost.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Net.Http;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("Placeholder/api")]
    public class JsonPlaceHolderController : Controller
    {
        public IConfiguration _config;
        private readonly IJsonPosts _posts;
        private readonly IDbOperations _dbOperations;
        public ILogger<JsonPlaceHolderController> _logger;
        public JsonPlaceHolderController(IConfiguration config, IJsonPosts posts, IDbOperations dbOperations, ILogger<JsonPlaceHolderController> logger) { 
            _config = config;
            _posts = posts;
            _dbOperations = dbOperations;
            _logger = logger;

       }

        [HttpGet("fact", Name = "GetCatFact")]
        public async Task<IActionResult> GetCatFact()
        {
            var response = _posts.GetCatFacts().ToString();
            var fact = JObject.Parse(response)["fact"].ToString();
            return Ok(new { fact });
        }

        [HttpGet("posts", Name = "GetPosts")]
        public async Task<IActionResult> GetPosts() 
        {
            int sucesscount = 0;
            try
            {
                IEnumerable<Post> result = await _posts.GetAllPosts();
                //foreach (var post in result) { 
                //    bool success = _dbOperations.InsertPosts(post);
                //    if (success) { 
                //        sucesscount++;
                //    }
                //}
                

                
                    var fact =  result.FirstOrDefault().image;
                
                return Ok(new { fact });



            }
            catch (Exception ex) {
                _logger.LogError($"Exception occurred, Data could not be inserted : {ex}");
                return StatusCode(500, "Something went wrong");
                
            }
 
        }

        

    }
}
