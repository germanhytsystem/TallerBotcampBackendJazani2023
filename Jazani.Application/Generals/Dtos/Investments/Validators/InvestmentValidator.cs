using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Jazani.Application.Generals.Dtos.Investments.Profiles
{
    public class InvestmentconceptValidator:AbstractValidator<InvestmentSaveDto>
    {

        public InvestmentconceptValidator() {

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();

        }

    }
}
