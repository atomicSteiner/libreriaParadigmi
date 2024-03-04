using libreriaParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.DTO
{
    public class LibroDTO
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string autore { get; set; } = string.Empty;
        public string editore { get; set; } = string.Empty;
        public DateTime dataPubblicazione { get; set; }
        public ICollection<Categoria> categorie { get; set; } = new HashSet<Categoria>();
        public LibroDTO(Libro l) 
        {
            id = l.id;
            nome = l.nome;
            autore = l.autore;
            editore = l.editore;
            dataPubblicazione = l.dataPubblicazione;
            categorie = l.categorie;
        }
    }
}
