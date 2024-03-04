using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext context) : base(context)
        {
            
        }
        public Categoria GetByNome(string nome)
        {
            return _ctx.Set<Categoria>().Where(x => x.nome == nome).FirstOrDefault();
        }
    }
    
}
