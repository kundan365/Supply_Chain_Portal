using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class ProductDetailsValidator:AbstractValidator<Models.DTO.ProductDetails>
    {
        public ProductDetailsValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductType).NotEmpty();
            RuleFor(x => x.PartNumber).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
