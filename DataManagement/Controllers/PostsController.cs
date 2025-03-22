using Microsoft.AspNetCore.Mvc;
using DataManagement.Models;
using DataManagement.Repositories.Interface;

namespace DataManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPostsAsync([FromQuery] int? userId, [FromQuery] string title)
        {
            var posts = await _postRepository.GetPostsAsync(userId, title);
            if (posts == null)
                return NotFound();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPostByIdAsync([FromRoute] int id)
        {
            var post = await _postRepository.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostByIdAsync([FromRoute] int id)
        {
            if (await _postRepository.GetPostByIdAsync(id) is null)
                return NotFound();

            var result = await _postRepository.DeletePostByIdAsync(id);

            if (result)
                return NoContent();

            return NotFound();

        }
    }
}
