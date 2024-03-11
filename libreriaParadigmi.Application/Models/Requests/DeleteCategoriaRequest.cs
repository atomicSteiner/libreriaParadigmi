using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Requests
{
    public class DeleteCategoriaRequest
    {
        public string nome { get; set; }
        public DeleteCategoriaRequest(string nome)
        {
            this.nome = nome;
        }
    }
}
