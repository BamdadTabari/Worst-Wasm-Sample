using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Repository.BlogPost;
using System.Threading.Tasks;

namespace PolimerWebProj.Server.Controllers.WhatUserSee
{
    [Route("user_vision_weblog")]
    [ApiController]
    public class WeblogController : ControllerBase
    {
        private readonly IBlogPostRepo _blogPostRepo;

        public WeblogController(IBlogPostRepo blogPostRepo) 
        {
            _blogPostRepo = blogPostRepo;
        }

        [HttpGet]
        [Route("get_blog_posts_paged")]
        public async Task<IActionResult> GetWeblogPosts([FromQuery] PagingParameters pagingParameters)
        {
            var result = await _blogPostRepo.GetPagedBlogPosts(pagingParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.MetaData));
            return Ok(result);
        }

        [HttpGet]
        [Route("get_blog_post_handler/{postId}")]
        public async Task<IActionResult> GetPost([FromRoute] int postId)
        {
            var result = await _blogPostRepo.GetBlogPostByIdAsync(postId);
            return Ok(result);
        }
    }
}
