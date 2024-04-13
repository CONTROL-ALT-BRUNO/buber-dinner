using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.DateTime;
using BuberDinner.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure.Authentication;

public class JwtTokenGenerator(
    IDateTimeProviderService dateTimeProvider,
    IOptions<JwtSettings> jwtOptions) : IJwtTokenGenerator
{
    public string GenerateToken(User user)
    {
        SigningCredentials signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtOptions.Value.Secret)
            ), 
            SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString())
        };

        JwtSecurityToken securityToken = new JwtSecurityToken(
            audience: jwtOptions.Value.Audience,
            issuer: jwtOptions.Value.Issuer,
            expires: dateTimeProvider.UtcNow.AddMinutes(jwtOptions.Value.ExpiryInMinutes),
            claims: claims, 
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}