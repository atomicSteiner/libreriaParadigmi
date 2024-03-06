using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace libreriaParadigmi.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public LibroRepository(MyDbContext context) : base(context)
        {
            
        }
        public override Libro Get(object id)
        {
            return _ctx.Set<Libro>().Include(c => c.categorie).Where(x => x.id == (int)id).FirstOrDefault();
        }
        public IEnumerable<Libro> GetLibri(string? categoria, string? nome, string? autore, DateTime? dataPubblicazione, int from, int num, out int totalnum)
        {
            var query = _ctx.Set<Libro>().Include(c => c.categorie).AsQueryable();
            if (categoria != null)
            {
                query = query.Where(x => x.categorie.Any(c => c.nome.Equals(categoria)));
            }
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.nome.Contains(nome));
            }
            if (!string.IsNullOrEmpty(autore))
            {
                query = query.Where(x => x.autore.Contains(autore));
            }
            if (dataPubblicazione != null)
            {
                query = query.Where(x => x.dataPubblicazione.Date.Equals(dataPubblicazione.Value.Date));
            }
            totalnum = query.Count();
            return query.Skip(from).Take(num).ToList();
        }
    }
    
}
