using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Dto.Produt
{
    public class ProductDto: BaseDto
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int CountInStore { get; set; }

        public string Description { get; set; }

        public string ProductImageAddress { get; set; }
        public string ProductImageAlt { get; set; }
        public int ProductImageId { get; set; }
    }
}
