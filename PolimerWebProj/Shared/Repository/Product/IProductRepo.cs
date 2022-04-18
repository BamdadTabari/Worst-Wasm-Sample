using AutoMapper;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entity.Product;
using Microsoft.EntityFrameworkCore;
using PolimerWebProj.Shared.BasicObjects.Paging;
using PolimerWebProj.Shared.BasicServices;
using PolimerWebProj.Shared.Dto.Produt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Repository.Product
{
    public interface IProductRepo
    {
        Task<int> AddProductAsync(ProductDto productDto);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task<bool> DeleteProductByIdAsync(int productId);
        Task<bool> UpdateProductAsync(ProductDto productDto);
        Task<PagedList<ProductDto>> GetPagedProducts(PagingParameters pagingParameters);
    }

    public class ProductRepo:IProductRepo
    {
        DataContext _dataContext;
        DbSet<ProductDmo> _productDmos;
        private readonly IMapper _mapper;

        public ProductRepo(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _productDmos = _dataContext.Set<ProductDmo>();
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(ProductDto productDto)
        {
            var dmo = _mapper.Map<ProductDmo>(productDto);
            await _productDmos.AddAsync(dmo);
            await _dataContext.SaveChangesAsync();
            return dmo.Id;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var dmo = await _productDmos.FirstOrDefaultAsync(x => x.Id == productId);
            var dto = _mapper.Map<ProductDto>(dmo);
            return dto;
        }

        public async Task<bool> DeleteProductByIdAsync(int productId)
        {
            var dmo = await _productDmos.FirstOrDefaultAsync(x => x.Id == productId);
            _productDmos.Remove(dmo);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductAsync(ProductDto productDto)
        {
            var dmo = _mapper.Map<ProductDmo>(productDto);
            _productDmos.Update(dmo);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<PagedList<ProductDto>> GetPagedProducts(PagingParameters pagingParameters)
        {
            var DmoList = await _productDmos.Search(pagingParameters.SearchTerm).Sort(pagingParameters.OrderBy).ToListAsync();
            var DtoList = _mapper.Map<List<ProductDto>>(DmoList);
            return PagedList<ProductDto>.ToPagedList(DtoList, pagingParameters.PageNumber, pagingParameters.PageSize);
        }
    }
}
