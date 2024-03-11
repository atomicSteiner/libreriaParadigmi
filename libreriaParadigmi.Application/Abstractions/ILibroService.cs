using libreriaParadigmi.Application.Models.DTO;
using libreriaParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Abstractions
{
    public interface ILibroService
    {
        public bool AddLibro(string nome, string autore, string editore, DateTime data, HashSet<string> categorie);
        public bool RemoveLibro(int id);
        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<string> categorie);
        public IEnumerable<Libro> GetLibri(string? categoria, string? nome, string? autore, DateTime? dataPubblicazione, int from, int num, out int totalnum);
    }
}
