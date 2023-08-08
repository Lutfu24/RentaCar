using FluentValidation;
using RentaCar.Entities.Dto.Cars;

namespace RentaCar.BusinessLogic.Utilities.Validators.Cars;

public class CarCreateDtoValidator:AbstractValidator<CarCreateDto>
{
	public CarCreateDtoValidator()
	{
		RuleFor(c => c.DailyPrice).NotEmpty()
			.NotNull()
			.Must(CheckPrice).WithMessage("Price 10000$ dan cox olmalidir")
			.LessThanOrEqualTo(100000);
	}

	public bool CheckPrice(int price)
	{
		return price > 10000;
	}
}
