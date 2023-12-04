using FluentValidation;
using Labb1_MinimalAPI.Models.DTOs;

namespace Labb1_MinimalAPI.Validations
{
    public class BookCreateValidation:AbstractValidator<BookCreateDTO>
    {
        public BookCreateValidation()
        {
            RuleFor(model => model.Title).MaximumLength(100).NotEmpty();
            RuleFor(model => model.Author).NotEmpty();
            RuleFor(model => model.Description).MaximumLength(400).NotEmpty();
            RuleFor(model => model.Genre).NotEmpty();
            RuleFor(model => model.Year).NotEmpty();
        }
    }
}
