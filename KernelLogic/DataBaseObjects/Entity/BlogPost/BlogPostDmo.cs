using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernelLogic.DataBaseObjects.Entity.BlogPost
{
    public class BlogPostDmo:BaseEntity
    {
        public string PostName { get; set; }
        public string PostAuthorName { get; set; }
        public string PostText { get; set; }
        public string PostImageAddress { get; set; }
        public string PostImageAlt { get; set; }
        public int PostImageId { get; set; }
    }

    public class BlogPostDmoConfiguration : IEntityTypeConfiguration<BlogPostDmo>
    {
        public void Configure(EntityTypeBuilder<BlogPostDmo> builder)
        {
            builder.Property(x => x.PostName).IsRequired();
            builder.Property(x => x.PostText).IsRequired();
            builder.Property(x => x.PostAuthorName).IsRequired();
            builder.Property(x => x.PostImageAddress).IsRequired();
            builder.Property(x => x.PostImageAlt).IsRequired();
            builder.Property(x => x.PostImageId).IsRequired();
        }
    }
}
