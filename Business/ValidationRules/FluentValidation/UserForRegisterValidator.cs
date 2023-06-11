using Entities.Concrete;
using Entities.DTOs.Authorization;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MaximumLength(50);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MaximumLength(50);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Email).MaximumLength(50);

            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(6);
            RuleFor(u => u.Password).MaximumLength(50);
        }
    }
}
