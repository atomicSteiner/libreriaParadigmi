using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Requests
{
    public class SearchLibroRequest
    {
        public string? categoria { get; set; }
        public string? nome { get; set; }
        public string? autore { get; set; }
        public DateTime? data { get; set; }
        public int from { get; set; }
        public int size { get; set; }
        public SearchLibroRequest(string? categoria, string? nome, string? autore, DateTime? data, int from, int size)
        {
            this.categoria = categoria;
            this.nome = nome;
            this.autore = autore;
            this.data = data;
            this.from = from;
            this.size = size;
        }
    }
}
