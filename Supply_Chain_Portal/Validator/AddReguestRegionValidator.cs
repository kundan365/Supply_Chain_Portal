using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class AddReguestRegionValidator:AbstractValidator<Models.DTO.AddReguestRegion>
    {
        public AddReguestRegionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    }
}
