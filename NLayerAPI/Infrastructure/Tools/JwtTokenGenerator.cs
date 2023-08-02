﻿using Entity.ModelsDtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace NLayer.API.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenDto GenerateToken(LoginDto dto)
        {
            var claims = new List<Claim>();

            //if (!string.IsNullOrEmpty(dto.Role))
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.UserName.ToString()));

            if (!string.IsNullOrEmpty(dto.UserName))
                claims.Add(new Claim("Username", dto.UserName));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));

            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: claims, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return new TokenDto(handler.WriteToken(jwtSecurityToken), expireDate);
        }
    }
}
