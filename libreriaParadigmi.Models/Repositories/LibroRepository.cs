using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
    }
    
}
