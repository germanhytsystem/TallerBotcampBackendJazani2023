using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Investmenttypes.Validators
{
    public class InvestmenttyValidator : AbstractValidator<InvestmenttypeSaveDto>
    {
        public InvestmenttyValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }
    }
}
