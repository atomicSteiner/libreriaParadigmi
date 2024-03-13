using FluentValidation;
using FluentValidation.AspNetCore;
using libreriaParadigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Validators
{
    public class AddCategoriaRequestValidator: AbstractValidator<AddCategoriaRequest>
    {
        public AddCategoriaRequestValidator()
        {
           RuleFor(x => x.nome)
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio");
        }
    }
}
