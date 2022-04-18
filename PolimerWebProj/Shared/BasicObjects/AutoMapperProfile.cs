using AutoMapper;
using KernelLogic.DataBaseObjects.Entity.BlogPost;
using KernelLogic.DataBaseObjects.Entity.Image;
using KernelLogic.DataBaseObjects.Entity.Product;
using PolimerWebProj.Shared.Dto.BlogPost;
using PolimerWebProj.Shared.Dto.Image;
using PolimerWebProj.Shared.Dto.Produt;

namespace PolimerWebProj.Shared.BasicObjects
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BlogPostDmo, BlogPostDto>().ReverseMap();
            CreateMap<ProductDmo, ProductDto>().ReverseMap();
            CreateMap<ImageDmo, ImageDto>().ReverseMap();
        }
    }
}
