using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyCmsWebApi2.Domain.Entities;
using MyCmsWebApi2.Persistences.EF;
using MyCmsWebApi2.Presentations.Dtos.AuthenticationDto;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyCmsWebApi2.Infrastructure.Extensions
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CmsDbContext _context;

        public JwtTokenGenerator(IConfiguration configuration, UserManager<ApplicationUser> userManager, CmsDbContext dbContext)
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = dbContext;
        }

        public async Task<AuthResult> GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!.ToString());
            var userRole = _userManager.GetRolesAsync(user);
            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Email,  user.Email),
                new Claim(ClaimTypes.Role, userRole.ToString()), // Add role claim
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString())
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.Add(TimeSpan.Parse(_configuration["Jwt:ExpiryTimeFrame"])),
                Audience = "FaghatKhooba", // specify the audience here
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken =  tokenHandler.WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id.ToString(),
                Token = RandomStringGenerator.RandomString(22),// refresh token should be here 
                Created =DateTime.UtcNow,
                Expires=DateTime.UtcNow.AddMonths(6),
                IsRevoked = false,
                IsUsed = false,
                UserId = user.Id,

            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            var result = new AuthResult()
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                Result = true

            };
            return result;
        }
    }
}
