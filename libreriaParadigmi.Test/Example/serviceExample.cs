using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Options;
using libreriaParadigmi.Application.Services;
using libreriaParadigmi.Models.Context;
using libreriaParadigmi.Models.Entities;
using libreriaParadigmi.Models.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Options;

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
            /*
            categoriaService.AddCategoria("Action");
            categoriaService.AddCategoria("Horror");
            HashSet<Categoria> categorie = new HashSet<Categoria>();
            
            categorie.Add(categoriaRepository.GetByNome("Action"));
            libroService.AddLibro("shining","stefano re","io", DateTime.Now,categorie);
            categoriaService.RemoveCategoria("Horror");
            categoriaService.AddCategoria("horror");
            libroService.UpdateLibro(1, "Shining", "Stephen King", "Mondadori", DateTime.Now, categorie);
            */
            categoriaService.RemoveCategoria("Action");
            categoriaService.RemoveCategoria("Horror");
        }
        public void runUtente()
        {
            MyDbContext myDbContext = new MyDbContext();
            UtenteRepository utenteRepository = new UtenteRepository(myDbContext);

            // Crea un'istanza di JwtAuthenticationOption
            var jwtOptions = new JwtAuthenticationOption
            {
                Key= "Unicam.ParadigmiChiave1234567890123",
                Issuer= "https://paradigmi.unicam.it"
            };

            // Crea un mock di IOptions<JwtAuthenticationOption>
            var mockJwtOptions = new Mock<IOptions<JwtAuthenticationOption>>();
            // Configura il mock per restituire il tuo oggetto jwtOptions quando Value viene richiesto
            mockJwtOptions.Setup(ap => ap.Value).Returns(jwtOptions);

            var utenteService = new UtenteService(utenteRepository, mockJwtOptions.Object);

            utenteService.Register("gigi", "riva", "ciao", "gr@gmail.com");
            var token= utenteService.Login("gr@gmail.com", "ciao");

        }
        public void runRicerca()
        {
            MyDbContext myDbContext = new MyDbContext();
            CategoriaRepository categoriaRepository = new CategoriaRepository(myDbContext);
            LibroRepository libroRepository = new LibroRepository(myDbContext);
            var categoriaService = new CategoriaService(categoriaRepository);
            var libroService = new LibroService(libroRepository);
            int totalnum = 0;
            var ricerca=libroService.GetLibri("Action", null, null, null, 0, 10, out totalnum);
        }
    }
}
