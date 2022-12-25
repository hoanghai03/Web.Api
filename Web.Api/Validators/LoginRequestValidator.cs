using FluentValidation;
using Web.Api.Models.DTO;

namespace Web.Api.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() {
            RuleFor(x=>x.Username).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
