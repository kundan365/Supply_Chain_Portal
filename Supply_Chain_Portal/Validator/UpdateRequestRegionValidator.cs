using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class UpdateRequestRegionValidator:AbstractValidator<Models.DTO.UpdateRequestRegion>
    {
        public UpdateRequestRegionValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Area).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Population).GreaterThanOrEqualTo(0);
        }
    
    }
}
