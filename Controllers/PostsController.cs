using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext context;

        public PostsController(BlogDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = context.Posts.ToList();
            return Ok(posts);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var post = context.Posts.Find(id);
            return Ok(post);
        }

        [HttpPost]
        public IActionResult CreatePost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = post.Id }, null);
        }

        [HttpPut("{id:int}")]
        public IActionResult EditPost(int id, [FromBody] Post post)
        {
            var postToEdit = context.Posts.Find(id);
            postToEdit.Title = post.Title;
            postToEdit.Body = post.Body;
            postToEdit.Author = post.Author;

            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePost(int id)
        {
            var post = context.Posts.Find(id);
            context.Remove(post);
            context.SaveChanges();

            return NoContent();
        }
    }
}