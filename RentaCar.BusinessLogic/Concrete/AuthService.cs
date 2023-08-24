using AutoMapper;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Identity;
using RentaCar.BusinessLogic.Abstract;

namespace RentaCar.BusinessLogic.Concrete;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHelper _tokenHelper;
    private readonly IMapper _mapper;

    public AuthService(UserManager<AppUser> userManager, ITokenHelper tokenHelper, IMapper mapper)
    {
        _userManager = userManager;
        _tokenHelper = tokenHelper;
        _mapper = mapper;
    }

    public Task<IDataResult<AccessToken>> CreateToken(AppUser appUser)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<AppUser>> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    public Task<IDataResult<AppUser>> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }
}
