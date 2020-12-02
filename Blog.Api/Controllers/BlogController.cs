using System.Collections.Generic;
using Blog.Core.Dto;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IPostService _postService;

        public BlogController(ILogger<BlogController> logger, IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<PostDto>> Get()
        {
            var posts = _postService.Get();

            if (posts == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(posts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PostDto> Get(int id)
        {
            if (_postService.TryGetPost(id, out PostDto post))
            {
                return NotFound();
            }

            return Ok(post);
        }
    }
}
