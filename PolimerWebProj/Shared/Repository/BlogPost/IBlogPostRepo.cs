using AutoMapper;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entity.BlogPost;
using Microsoft.EntityFrameworkCore;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.BasicServices;
using PolimerWebProj.Shared.Dto.BlogPost;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Repository.BlogPost
{
    public interface IBlogPostRepo
    {
        Task<int> AddBlogPostASync(BlogPostDto blogPostDto);
        Task<BlogPostDto> GetBlogPostByIdAsync(int postId);
        Task<bool> DeleteBlogPostByIdAsync(int postId);
        Task<bool> UpdateBlogPostAsync(BlogPostDto blogPostDto);
        Task<PagedList<BlogPostDto>> GetPagedBlogPosts(PagingParameters pagingParameters);
    }

    public class BlogPostRepo : IBlogPostRepo
    {
        DataContext _dataContext;
        DbSet<BlogPostDmo> _blogPostDmos;
        private readonly IMapper _mapper;

        public BlogPostRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _blogPostDmos = _dataContext.Set<BlogPostDmo>();
            _mapper = mapper;
        }

        public async Task<int> AddBlogPostASync(BlogPostDto blogPostDto)
        {
            var dmo = _mapper.Map<BlogPostDmo>(blogPostDto);
            await _blogPostDmos.AddAsync(dmo);
            await _dataContext.SaveChangesAsync();
            return dmo.Id;
        }


        public async Task<BlogPostDto> GetBlogPostByIdAsync(int postId)
        {
            var dmo = await _blogPostDmos.FirstOrDefaultAsync(x => x.Id == postId);
            var dto = _mapper.Map<BlogPostDto>(dmo);
            return dto;
        }

        public async Task<bool> DeleteBlogPostByIdAsync(int postId)
        {
            var dmo = await _blogPostDmos.FirstOrDefaultAsync(x => x.Id == postId);
            _blogPostDmos.Remove(dmo);
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<PagedList<BlogPostDto>> GetPagedBlogPosts(PagingParameters pagingParameters)
        {
            var DmoList = await _blogPostDmos.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            var DtoList = _mapper.Map<List<BlogPostDto>>(DmoList); 
            return PagedList<BlogPostDto>.ToPagedList(DtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<bool> UpdateBlogPostAsync(BlogPostDto blogPostDto)
        {
            var dmo = _mapper.Map<BlogPostDmo>(blogPostDto);
            _blogPostDmos.Update(dmo);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
