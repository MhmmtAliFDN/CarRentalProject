using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(b => b.ColorName).NotEmpty();
            RuleFor(b => b.ColorName).MaximumLength(50);
        }
    }
}
