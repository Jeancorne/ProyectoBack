using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoBack.Core.Entities.v1;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBack.Application.Helpers
{
    public class JWT
    {
        private readonly byte[] secret;
        public JWT(string secretKey)
        {
            this.secret = Encoding.ASCII.GetBytes(secretKey);
        }

        public string crearToken(string usuario, List<string> claimsList)
        {
            var claims = new ClaimsIdentity();            
            claims.AddClaim(new Claim("Token", usuario));
            foreach (var item in claimsList)
            {
                if (item != null)
                {
                    claims.AddClaim(new Claim("Token", item));
                }
                
            }            
            var tokenDescripcion = new SecurityTokenDescriptor()
            {
                Subject = claims,                
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = new JwtSecurityTokenHandler();
            var createdToken = token.CreateToken(tokenDescripcion);
            return token.WriteToken(createdToken);
        }
    }
}
