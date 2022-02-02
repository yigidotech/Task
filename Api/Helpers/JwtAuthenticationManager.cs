using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Api.Helpers
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string key;
        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        public string Authenticate(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Subject = new ClaimsIdentity(new Claim[]{
                //     new Claim(ClaimTypes.Name ,user.Name),
                //     new Claim(ClaimTypes.Surname ,user.Surname),
                //     new Claim(ClaimTypes.Role , "Admin")
                // }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
            claims.Add(new Claim(ClaimTypes.GivenName, user.Username));

            // if (user.UserRoles != null)
            // {
            //     foreach (Role role in user.UserRoles)
            //     {
            //         claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            //     }
            // }
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims.ToArray());
            tokenDescriptor.Subject = claimsIdentity;
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}