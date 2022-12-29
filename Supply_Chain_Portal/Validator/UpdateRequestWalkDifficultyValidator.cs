using FluentValidation;

namespace Supply_Chain_Portal.Validator
{
    public class UpdateRequestWalkDifficultyValidator: AbstractValidator<Models.DTO.UpdateRequestWalkDifficulty>
    {
        public UpdateRequestWalkDifficultyValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
