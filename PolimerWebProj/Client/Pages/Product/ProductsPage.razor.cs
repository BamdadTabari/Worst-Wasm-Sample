using MudBlazor;
using PolimerWebProj.Client.Shared.Helpers;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Product
{
    public partial class ProductsPage
    {

        #region props

        private MudTable<ProductDto> _table = new();
        private PagingParameters _pagingParameters = new();
        private readonly int[] _pageSizeOption = { 4, 6, 10, 20 };

        #endregion

        #region methods 
        private async Task<TableData<ProductDto>> GetServerData(TableState state)
        {
            _pagingParameters.PageSize = state.PageSize;
            _pagingParameters.PageNumber = state.Page + 1;
            state.SortDirection = SortDirection.Descending;
            _pagingParameters.OrderBy = state.SortDirection == SortDirection.Descending ?
            state.SortLabel + " desc" :
            state.SortLabel;

            var pagingResponse = await _httpRequestHandler.GetPagedProducts(_pagingParameters, "product_handler/get_paged_Product_handler");
            return new TableData<ProductDto>
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

        private void EditProduct(int id)
        {
            NavigationManager.NavigateTo($"/admin_handler_edit_product_page/{id}");
        }

        private async Task DeleteProduct(int id)
        {
            var parameters = new DialogParameters
        {
            { "Content", "Are You Sure Wanna Delete This Product ?" },
            { "ButtonColor", Color.Error },
            { "ButtonText", "Delete Product" }
        };
            var dialog = _dialogService.Show<DialogNotification>("Delete Product Warning", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _httpRequestHandler.DeleteById(id, "product_handler/delete_product_handler");
                if (response)
                {
                    _snackbar.Add("Product Deleted Successfully", Severity.Success);
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
