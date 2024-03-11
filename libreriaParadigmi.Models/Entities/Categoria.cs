using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Entities
{
    public  class Categoria
    {
        public int id { get; set; }
        public String nome { get; set; } = String.Empty;
        [JsonIgnore]
        public virtual IEnumerable<Libro> libri { get; set; } = new HashSet<Libro>();   //proprietà di navigazione necessaria per EF, non mappata nel db
    }
}
