namespace JsonPost.Models
{
    public class Post
    {

            public int Postid { get; set; }
            public string slug { get; set; }
            public string url { get; set; }
            public string title { get; set; }
            public string content { get; set; }
            public string image { get; set; }
            public string thumbnail { get; set; }
            public string status { get; set; }
            public string category { get; set; }
            public string publishedAt { get; set; }
            public string updatedAt { get; set; }
            public int userId { get; set; }

    }
}
