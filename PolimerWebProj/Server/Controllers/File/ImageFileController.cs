using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolimerWebProj.Shared.Dto.Image;
using PolimerWebProj.Shared.Repository.Image;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PolimerWebProj.Server.Controllers.File
{
    [Route("image_file_handler")]
    [ApiController]
    [Authorize(Roles = "Adminstrator")]
    public class ImageFileController : ControllerBase
    {
        private readonly IImageRepo _imageRepo;

        public ImageFileController(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [HttpPost]
        [Route("add_image_data_handler")]
        public async Task AddImageData(ImageDto imageDto)
        {
            await _imageRepo.AddImageAsync(imageDto);
        }

        [HttpGet]
        [Route("get_image_list_handler")]
        public async Task<List<ImageDto>> GetAllImages()
        {
            return await _imageRepo.GetAllImages();
        }
    }

}
