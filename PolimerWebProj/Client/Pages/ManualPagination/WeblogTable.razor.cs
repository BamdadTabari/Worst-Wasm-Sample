using Microsoft.AspNetCore.Components;
using PolimerWebProj.Shared.Dto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.ManualPagination
{
    public partial class WeblogTable
    {
        [Parameter]
        public List<BlogPostDto> BlogPostDtos { get; set; }

        public async Task GetPostDetail(int Id)
        {
            NavigationManager.NavigateTo($"blog_post_detail/{Id}");
        }
    }
}
