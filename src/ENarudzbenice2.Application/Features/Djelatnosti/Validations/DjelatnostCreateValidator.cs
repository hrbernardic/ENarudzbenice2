using ENarudzbenice2.Application.Features.Djelatnosti.Requests;
using FluentValidation;

namespace ENarudzbenice2.Application.Features.Djelatnosti.Validations
{
    public class DjelatnostCreateValidator : AbstractValidator<DjelatnostCreate.Request>
    {
        public DjelatnostCreateValidator()
        {
            RuleFor(x => x.Naziv)
                .MaximumLength(50);
        }
    }
}
