using Core.Utilities.Security.Encrypting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT;

public class JWTHelper : ITokenHelper
{
    private readonly IConfiguration _configuration;
    private readonly TokenOption _option;
    private DateTime _accessTokenExpiration;

    public JWTHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _option = configuration.GetSection("TokenOptions").Get<TokenOption>();
        _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_option.AccessTokenExpiration);
    }

    public AccessToken CreateToken(List<Claim> claims)
    {
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_option.SecurityKey);
        SigningCredentials signingCredentials = SignInCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtHeader header = new JwtHeader(signingCredentials);

        JwtPayload payload = new JwtPayload(
            issuer: _option.Issuer,
            audience: _option.Audience,
            claims: claims,
            notBefore:DateTime.UtcNow,
            expires: _accessTokenExpiration
            );

        JwtSecurityToken jwtsecuritytoken = new JwtSecurityToken(header, payload);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        string token = jwtSecurityTokenHandler.WriteToken(jwtsecuritytoken);

        return new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
    }
}
