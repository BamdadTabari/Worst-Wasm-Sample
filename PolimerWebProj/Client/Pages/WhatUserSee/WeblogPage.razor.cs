using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.WhatUserSee
{
    public partial class WeblogPage
    {
        public List<BlogPostDto> blogPosts { get; set; } = new();
        public MetaData MetaData  = new();
        private PagingParameters _pagingParameters = new();
        
        protected async override Task OnInitializedAsync()
        {
            await GetPosts();
        }

        private async Task SelectedPage(int page)
        {
            _pagingParameters.PageNumber = page;
            await GetPosts();
        }

        public async Task GetPosts()
        {
            var pagingResponse = await _httpRequestHandler.GetPagedPosts(_pagingParameters, "user_vision_weblog/get_blog_posts_paged");
            blogPosts = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
        }
    }
}
