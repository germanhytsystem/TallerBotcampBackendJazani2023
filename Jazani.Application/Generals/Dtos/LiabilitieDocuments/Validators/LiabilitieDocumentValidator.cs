using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Jazani.Application.Generals.Dtos.LiabilitieDocuments.Validators
{
    public class LiabilitieDocumentValidator:AbstractValidator<LiabilitieDocumentSaveDto>
    {

        public LiabilitieDocumentValidator() {

            RuleFor(x => x.liabilitiesid)
                .NotNull()
                .NotEmpty();

        }

    }
}
