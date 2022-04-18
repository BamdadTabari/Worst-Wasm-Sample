using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.BlogPost;
using PolimerWebProj.Shared.Repository.BlogPost;
using PolimerWebProj.Shared.Repository.Image;
using System.Threading.Tasks;

namespace PolimerWebProj.Server.Controllers.BlogPost
{
    [Route("blog_post_handler")]
    [ApiController]
    [Authorize(Roles = "Adminstrator")]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepo _blogPostRepo;
        private readonly IImageRepo _imageRepo;

        public BlogPostController(IBlogPostRepo blogPostRepo, IImageRepo imageRepo)
        {
            _blogPostRepo = blogPostRepo;
            _imageRepo = imageRepo;
        }

        [HttpPost]
        [Route("add_blog_post_handler")]
        public async Task<IActionResult> AddPost([FromBody] BlogPostDto blogPostDto)
        {
            var image = await _imageRepo.GetImageById(blogPostDto.PostImageId);
            blogPostDto.PostImageAlt = image.Alt;
            blogPostDto.PostImageAddress = image.Path;
            var result = await _blogPostRepo.AddBlogPostASync(blogPostDto);
            return Created("", result);
        }

        [HttpGet]
        [Route("get_paged_blog_post_handler")]
        public async Task<IActionResult> GetPagedPosts([FromQuery] PagingParameters pagingParameters)
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

        [HttpPut]
        [Route("update_blog_post_handler")]
        public async Task<IActionResult> UpdatePost([FromBody] BlogPostDto blogPostDto)
        {
            var result = await _blogPostRepo.UpdateBlogPostAsync(blogPostDto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete_blog_post_handler/{postId}")]
        public async Task<IActionResult> DeletePost([FromRoute] int postId)
        {
            var result = await _blogPostRepo.DeleteBlogPostByIdAsync(postId);
            return Ok(result);
        }
    }
}
