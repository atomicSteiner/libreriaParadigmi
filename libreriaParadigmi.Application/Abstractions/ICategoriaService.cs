using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Abstractions
{
    public interface ICategoriaService
    {
        public bool AddCategoria(string nome);
        public bool RemoveCategoria(string nome);
    }
}
