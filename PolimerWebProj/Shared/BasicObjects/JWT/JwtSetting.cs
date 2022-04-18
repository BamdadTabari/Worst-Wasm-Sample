using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.BasicObjects.JWT
{
    public class JwtSetting
    {
        public bool ValidateIssuerSigningKey { get; set; } = true;
        public bool ValidateLifetime { get; set; } = true;
        public bool ValidateAudience { get; set; } = true;
        public bool ValidateIssuer { get; set; } = true;
        public string ValidIssuer { get; set; } = "https://localhost";
        public string ValidAudience { get; set; } = "https://localhost";
        public string SecuritySignInKey { get; set; } = "WQ7+dPhLEHdhdaKNzu!ck-fg86TPhUfd#E&&Qq+=vUtfxJ!@sDfe#u^prXW2&Qhmy33u!@e?5-xb*";
        public int ExpiryInMinutes { get; set; } = 1024;
    }
}
