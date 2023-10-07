using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Liabilities.Validators
{
    public class LiabilitieValidator:AbstractValidator<LiabilitieSaveDto>
    {
        public LiabilitieValidator()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }
    }
}
