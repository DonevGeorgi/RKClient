using Client.Models.Request;
using FluentValidation;

namespace RKClient.Validators
{
    public class ComputerValidator : AbstractValidator<ComputerRequest>
    {
        public ComputerValidator()
        {
            RuleFor(x => x.ComputerId).GreaterThan(0);
            RuleFor(x => x.ComputerBrand).MaximumLength(25);
            RuleFor(x => x.ComputerBrand).MinimumLength(5);
        }
    }
}
