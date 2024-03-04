using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Services;
using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Entities;
using libreriaParadigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Test.Example
{
    public class serviceExample
    {
        public void run()
        {
            MyDbContext myDbContext = new MyDbContext();
            CategoriaRepository categoriaRepository = new CategoriaRepository(myDbContext);
            LibroRepository libroRepository = new LibroRepository(myDbContext);
            var categoriaService = new CategoriaService(categoriaRepository);
            var libroService = new LibroService(libroRepository);
            
            categoriaService.AddCategoria("Action");
            categoriaService.AddCategoria("Horror");
            HashSet<Categoria> categorie = new HashSet<Categoria>();
            
            categorie.Add(categoriaRepository.GetByNome("Action"));
            libroService.AddLibro("shining","stefano re","io", DateTime.Now,categorie);
            categoriaService.RemoveCategoria("Horror");
            categoriaService.AddCategoria("horror");
            libroService.UpdateLibro(1, "Shining", "Stephen King", "Mondadori", DateTime.Now, categorie);
        }
    }
}
