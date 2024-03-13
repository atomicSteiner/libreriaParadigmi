using FluentValidation;
using libreriaParadigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Validators
{
    public class DeleteLibroRequestValidator : AbstractValidator<DeleteLibroRequest>
    {
        public DeleteLibroRequestValidator()
        {
            RuleFor(x => x.id)
                .NotEmpty()
                .WithMessage("Il campo id è obbligatorio")
                .GreaterThan(0);
        }
    }
}
