using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Dto.BlogPost
{
    public class BlogPostDto: BaseDto
    {
        [Required (ErrorMessage ="please fill name field")]
        public string PostName { get; set; }
        [Required(ErrorMessage = "please fill post Author field")]
        public string PostAuthorName { get; set; }
        [Required(ErrorMessage = "please fill post text field")]
        public string PostText { get; set; }
        public string PostImageAddress { get; set; }
        public string PostImageAlt { get; set; }
        public int PostImageId { get; set; }
    }
}
