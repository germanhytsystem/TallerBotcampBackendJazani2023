using FluentValidation;
using Jazani.Application.Generals.Dtos.Periodtypes;

namespace Jazani.Application.Generals.Dtos.Miningconcessions.Profiles
{
    public class MiningconcessionsValidator : AbstractValidator<MiningconcessionSaveDto>
    {

        public MiningconcessionsValidator() {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }

    }
}
