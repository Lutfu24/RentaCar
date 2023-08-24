using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encrypting;

public static class SignInCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
    }
}
