using FluentValidation;
using Jazani.Application.Generals.Dtos.Miningconcessions;

namespace Jazani.Application.Generals.Dtos.Periodtypes.Profiles
{
    public class PeriodtypeValidator : AbstractValidator<MiningconcessionSaveDto>
    {

        public PeriodtypeValidator() {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }

    }
}
