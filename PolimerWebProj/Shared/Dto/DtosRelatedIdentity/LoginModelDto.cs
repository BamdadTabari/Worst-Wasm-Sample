using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.Dto.DtosRelatedIdentity
{
    public class LoginModelDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
