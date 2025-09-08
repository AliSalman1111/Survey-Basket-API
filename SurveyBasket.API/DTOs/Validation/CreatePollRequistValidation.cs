using FluentValidation;
using SurveyBasket.API.DTOs.Requist;

namespace SurveyBasket.API.DTOs.Validation
{
    public class CreatePollRequistValidation:AbstractValidator<pollRequist>
    {


        public CreatePollRequistValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MinimumLength(5).WithMessage("Title must be at least 5 characters")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must be less than 500 characters");


        }
    }
}
