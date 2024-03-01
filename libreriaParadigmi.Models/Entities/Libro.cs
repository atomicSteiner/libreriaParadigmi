using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Entities
{
    public class Libro
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string autore { get; set; } = string.Empty;
        public string editore { get; set; } = string.Empty;
        public DateTime dataPubblicazione { get; set; }
        public virtual ICollection<Categoria> categorie { get; set; } = new HashSet<Categoria>();
        
    }
}
