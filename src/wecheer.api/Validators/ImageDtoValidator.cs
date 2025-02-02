using FluentValidation;
using Wecheer.Core.Models;

namespace Wecheer.Api.Validators
{
    public class CreateImageDtoValidator : AbstractValidator<CreateImageDto>
    {
        public CreateImageDtoValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("Image URL is required")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Invalid URL format");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description cannot exceed 500 characters");
        }
    }
}
