using libreriaParadigmi.Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Responses
{
    public class SearchLibroResponse
    {
        public List <LibroDTO> Libri { get; set; }
        public int NumeroPagine { get; set; }
        public SearchLibroResponse(List<LibroDTO> Libri, int numeroPagine)
        {
            this.Libri = Libri;
            this.NumeroPagine = numeroPagine;
        }
        public SearchLibroResponse()
        {
            this.Libri = new List<LibroDTO>();
            this.NumeroPagine = 0;
        }
    }
}
