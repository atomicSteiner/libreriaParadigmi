using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Requests
{
    public class AddLibroRequest
    {
        public string nome { get; set; }
        public string autore { get; set; }
        public string editore { get; set; }
        public DateTime dataPubblicazione { get; set; }
        public HashSet<string> categorie { get; set; }
        public AddLibroRequest(string nome, string autore, string editore, DateTime dataPubblicazione, HashSet<string> categorie)
        {
            this.nome = nome;
            this.autore = autore;
            this.editore = editore;
            this.dataPubblicazione = dataPubblicazione;
            this.categorie = categorie;
        }
    }
}
