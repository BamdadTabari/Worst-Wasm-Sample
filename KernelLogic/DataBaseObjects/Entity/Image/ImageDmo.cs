using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects.Entity.Image
{
    public class ImageDmo : BaseEntity
    {
        public string Path { get; set; }
        public string Alt { get; set; }
    }
    public class ImageDmoConfiguration : IEntityTypeConfiguration<ImageDmo>
    {
        public void Configure(EntityTypeBuilder<ImageDmo> builder)
        {
            builder.Property(x => x.Path).IsRequired();
            builder.Property(x => x.Alt).IsRequired();
        }
    }
}
