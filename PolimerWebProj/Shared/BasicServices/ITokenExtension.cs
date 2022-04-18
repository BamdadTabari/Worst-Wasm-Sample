using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PolimerWebProj.Shared.BasicObjects.JWT;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PolimerWebProj.Shared.BasicServices
{
    public interface ITokenExtension
    {
        SigningCredentials GetSigningCredentials();
        Task<List<Claim>> GetClaimsAsync(IdentityUser user);
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims);
    }
    public class TokenExtension : ITokenExtension
    {
        private readonly UserManager<IdentityUser> _userManager;
        public TokenExtension(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public SigningCredentials GetSigningCredentials()
        {
            var _jwtSettings = new JwtSetting();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecuritySignInKey);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        public async Task<List<Claim>> GetClaimsAsync(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var _jwtSettings = new JwtSetting();
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.ValidIssuer,
                audience: _jwtSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.ExpiryInMinutes)),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
