using FluentValidation;
using Warehouse.ApplicationServices.API.Domain.BookCaseElements;

namespace Warehouse.ApplicationServices.API.Validators
{
    public class AddBookCaseRequestValidator : AbstractValidator<AddBookCaseRequest>
    {
        public AddBookCaseRequestValidator()
        {
            RuleFor(x => x.Number).InclusiveBetween(1, 10);
        }
    }
}
