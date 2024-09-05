using FluentValidation;

namespace pet_store.Validators;

public class DogLeashValidator : AbstractValidator<DogLeash>
{
    public DogLeashValidator()
    {
        RuleFor(dogleash => dogleash.Name).NotEmpty();
        RuleFor(dogleash => dogleash.Price).GreaterThan(0);
        RuleFor(dogleash => dogleash.Quantity).GreaterThan(0);
        RuleFor(dogleash => dogleash.Description).MinimumLength(10).Unless(dogleash => dogleash.Description.Length ==0);
    }
}