using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class UpdateRequestWalkValidator:AbstractValidator<Models.DTO.UpdateRequestWalk>
    {
        public UpdateRequestWalkValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Length).GreaterThanOrEqualTo(0);
        }
    }
}
