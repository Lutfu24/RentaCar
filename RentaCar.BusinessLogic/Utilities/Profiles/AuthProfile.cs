using AutoMapper;
using Core.Entities.Concrete.Auth;

namespace RentaCar.BusinessLogic.Utilities.Profiles;

public class AuthProfile:Profile
{
	public AuthProfile()
	{
		CreateMap<RegisterDto, AppUser>();
	}
}
