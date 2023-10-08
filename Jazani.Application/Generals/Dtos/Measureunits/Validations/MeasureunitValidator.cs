using FluentValidation;
using Jazani.Application.Generals.Dtos.Miningconcessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Measureunits.Profiles
{
    public class MeasureunitValidator:AbstractValidator<MiningconcessionSaveDto>
    {
        public MeasureunitValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }
    }
}
