using FluentValidation;
using SurveyBasket.API.DTOs.Requist;

namespace SurveyBasket.API.DTOs.Validation
{
    public class PollRequistValidation:AbstractValidator<pollRequist>
    {


        public PollRequistValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required").MinimumLength(5).WithMessage("Title must be at least 5 characters")
                .MaximumLength(100).WithMessage("Title must be less than 100 characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must be less than 500 characters");

            RuleFor(x => x.CreatedAt).NotEmpty().WithMessage("CreatedAt is required")
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("CreatedAt must be today or in the future");

            RuleFor(x => x.EndedAt).NotEmpty().WithMessage("EndedAt is required")
               .GreaterThanOrEqualTo(x => x.CreatedAt).WithMessage("EndedAt must be after CreatedAt");

        }
    }
}
