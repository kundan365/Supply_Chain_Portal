using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class AddRequestWalkValidator : AbstractValidator<Models.DTO.AddRequestWalk>
    {
        public AddRequestWalkValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
