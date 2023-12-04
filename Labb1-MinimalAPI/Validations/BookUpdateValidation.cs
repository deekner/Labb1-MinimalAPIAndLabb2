using FluentValidation;
using Labb1_MinimalAPI.Models.DTOs;

namespace Labb1_MinimalAPI.Validations
{
    public class BookUpdateValidation:AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateValidation()
        {
            RuleFor(model => model.Title).MaximumLength(100);
            RuleFor(model => model.Description).MaximumLength(200);
        }
    }
}
