using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();

            RuleFor(c => c.ColorId).NotEmpty();

            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MaximumLength(250);

            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(0);  //the rule can change according to company's wishes

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);

            RuleFor(c => c.Description).MaximumLength(1000);
        }
    }
}
