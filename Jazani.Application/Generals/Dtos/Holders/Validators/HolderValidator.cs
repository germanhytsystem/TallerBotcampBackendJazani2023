using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Holders.Validators
{
    public class HolderValidator:AbstractValidator<HolderSaveDto>
    {
        public HolderValidator() {

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

        }
    }
}
