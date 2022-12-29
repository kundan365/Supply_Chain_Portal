using FluentValidation;
using Supply_Chain_Portal.Models.DTO;

namespace Supply_Chain_Portal.Validator
{
    public class UpdateRequestProductDetailsValidator: AbstractValidator<Models.DTO.ProductDetails>
    {
        public UpdateRequestProductDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductType).NotEmpty();
            RuleFor(x => x.PartNumber).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
