using AutoMapper;
using KernelLogic.DataBaseObjects;
using KernelLogic.DataBaseObjects.Entity.Image;
using Microsoft.EntityFrameworkCore;
using PolimerWebProj.Shared.Dto.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Repository.Image
{

    public interface IImageRepo
    {
        Task<int> AddImageAsync(ImageDto imageDto);
        Task<bool> IsImagePathExist(string imagePath);
        Task<List<ImageDto>> GetAllImages();
        Task<ImageDto> GetImageById(int id);
    }

    public class ImageRepo : IImageRepo
    {
        private DataContext _dataContext;
        private DbSet<ImageDmo> _imageDmo;
        private readonly IMapper _mapper;

        public ImageRepo(DataContext dataContext, IMapper mapper) : base()
        {
            _dataContext = dataContext;
            _imageDmo = _dataContext.Set<ImageDmo>();
            _mapper = mapper;
        }

        public async Task<int> AddImageAsync(ImageDto imageDto)
        {
            var isImagePathExist = await IsImagePathExist(imageDto.Path);
            if (!isImagePathExist)
            {
                var entity = _mapper.Map<ImageDmo>(imageDto);
                await _imageDmo.AddAsync(entity);
                await _dataContext.SaveChangesAsync();
                return entity.Id;
            }
            else
            {
                throw new Exception("Image Path Exist");
            }
        }

        public async Task<List<ImageDto>> GetAllImages()
        {
            var imageDmoList = await _imageDmo.ToListAsync();
            var imageDtoList = _mapper.Map<List<ImageDto>>(imageDmoList);
            return imageDtoList;
        }

        public async Task<bool> IsImagePathExist(string imagePath)
        {
            var image = await _imageDmo.FirstOrDefaultAsync(x => x.Path == imagePath);
            if (image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<ImageDto> GetImageById(int id)
        {
            var imageDmo = await _imageDmo
                .FirstOrDefaultAsync(x => x.Id == id);
            var imageDto = _mapper.Map<ImageDto>(imageDmo);
            return imageDto;
        }
    }
}
