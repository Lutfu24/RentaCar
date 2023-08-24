using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.JWT;

namespace RentaCar.BusinessLogic.Abstract;

public interface IAuthService
{
    Task<IDataResult<AppUser>> RegisterAsync(RegisterDto registerDto);
    Task<IDataResult<AppUser>> LoginAsync(LoginDto loginDto);
    Task<IDataResult<AccessToken>> CreateToken(AppUser appUser);
}
