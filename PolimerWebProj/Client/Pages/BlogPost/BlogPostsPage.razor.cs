using MudBlazor;
using PolimerWebProj.Client.Shared.Helpers;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.BlogPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.BlogPost
{
    public partial class BlogPostsPage
    {
        
        #region props

        private MudTable<BlogPostDto> _table = new();
        private PagingParameters _pagingParameters = new();
        private readonly int[] _pageSizeOption = { 4, 6, 10, 20 };

        #endregion

        #region methods 
        private async Task<TableData<BlogPostDto>> GetServerData(TableState state)
        {
            _pagingParameters.PageSize = state.PageSize;
            _pagingParameters.PageNumber = state.Page + 1;
            state.SortDirection = SortDirection.Descending;
            _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
            state.SortLabel + " desc" :
            state.SortLabel;

            var pagingResponse = await _httpRequestHandler.GetPagedPosts(_pagingParameters, "blog_post_handler/get_paged_blog_post_handler");
            return new TableData<BlogPostDto>
            {
                Items = pagingResponse.Items,
                TotalItems = pagingResponse.MetaData.TotalCount
            };
        }

        private void OnSearch(string searchTerm)
        {
            _pagingParameters.SearchTerm = searchTerm;
            _table.ReloadServerData();
        }

        private void EditPost(int id)
        {
            NavigationManager.NavigateTo($"/admin_handler_edit_post_page/{id}");
        }

        private async Task DeletePost(int id)
        {
            var parameters = new DialogParameters
        {
            { "Content", "Are You Sure Wanna Delete This Post ?" },
            { "ButtonColor", Color.Error },
            { "ButtonText", "Delete Post" }
        };
            var dialog = _dialogService.Show<DialogNotification>("Delete Post Warning", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _httpRequestHandler.DeleteById(id, "blog_post_handler/delete_blog_post_handler");
                if (response)
                {
                    _snackbar.Add("Post Deleted Successfully", Severity.Success);
                    await _table.ReloadServerData();
                }
                else
                {
                    _snackbar.Add("Deleted Faild", Severity.Error);
                }

            }
            else
            {
                _snackbar.Add("Deleted Canceled", Severity.Info);
            }

        }
        #endregion
    }
}
