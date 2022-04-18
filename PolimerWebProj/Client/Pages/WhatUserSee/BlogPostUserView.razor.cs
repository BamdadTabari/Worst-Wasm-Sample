using Microsoft.AspNetCore.Components;
using PolimerWebProj.Shared.Dto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.WhatUserSee
{
    public partial class BlogPostUserView
    {
        [Parameter]
        public int postId { get; set; }

        public BlogPostDto BlogPostDto = new();

        protected override async Task OnParametersSetAsync()
        {
            BlogPostDto =await _httpRequestHandler.GetById<BlogPostDto>(postId, "user_vision_weblog/get_blog_post_handler");
        }
    }
}
