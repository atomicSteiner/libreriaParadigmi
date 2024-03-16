using FluentValidation;
using libreriaParadigmi.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Validators
{
    public class SearchLibroRequestValidator : AbstractValidator<SearchLibroRequest>
    {
        public SearchLibroRequestValidator()
        {
           RuleFor(x => x.size)
                .GreaterThan(0)
                .WithMessage("Il campo size deve essere maggiore di 0");
           RuleFor(x => x.from)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Il campo from deve essere superiore o uguale a 0");
           RuleFor(x => x)
                .Must(x => almenoUnaNonNulla(x))
                .WithMessage("Almeno un campo deve essere non nullo");
        }
        private bool almenoUnaNonNulla(SearchLibroRequest request)
        {
            return !String.IsNullOrEmpty(request.categoria) || !String.IsNullOrEmpty(request.nome) || !String.IsNullOrEmpty(request.autore) || request.data != null;
        }
    }
}
