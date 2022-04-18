using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects.Entity.Product
{
    public class ProductDmo:BaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int CountInStore { get; set; }

        public string Description { get; set; }

        public string ProductImageAddress { get; set; }
        public string ProductImageAlt { get; set; }
        public int ProductImageId { get; set; }
    }
    public class BlogPostDmoConfiguration : IEntityTypeConfiguration<ProductDmo>
    {
        public void Configure(EntityTypeBuilder<ProductDmo> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CountInStore).IsRequired();
            
        }
    }
}
