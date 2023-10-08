using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Jazani.Application.Generals.Dtos.Investmentconcepts;

namespace Jazani.Application.Generals.Dtos.Investmentconcepts.Profiles
{
    public class InvestmentconceptValidator:AbstractValidator<InvestmentconceptSaveDto>
    {

        public InvestmentconceptValidator() {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }

    }
}
