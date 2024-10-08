using FluentValidation;
using pet_store.Data;

namespace pet_store.Validators;

public class DogLeashValidator : AbstractValidator<Product>
{
    public DogLeashValidator()
    {
        RuleFor(product => product.Name).NotEmpty();
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Quantity).GreaterThan(0);
        RuleFor(product => product.Description).MinimumLength(10).Unless(product => product.Description.Length ==0);
    }
}