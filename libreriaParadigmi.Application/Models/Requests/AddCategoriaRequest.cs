using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Requests
{
    public class AddCategoriaRequest
    {
        public string nome { get; set; }
        public AddCategoriaRequest(string nome)
        {
            this.nome = nome;
        }
    }
}
