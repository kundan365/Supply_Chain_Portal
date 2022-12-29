using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class AddRequestWalkDifficultyValidator : AbstractValidator<Models.DTO.AddRequestWalkDifficulty>
    {
        public AddRequestWalkDifficultyValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
