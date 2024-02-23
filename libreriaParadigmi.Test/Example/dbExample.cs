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
    internal class dbExample
    {
        public void run()
        {
            var ctx = new MyDbContext();
            var repoUtenti= new UtenteRepository(ctx);
            var repoCategorie = new LibroRepository(ctx);
            var repoLibri = new CategoriaRepository(ctx);
            repoUtenti.Add(new Utente { nome = "Mario", cognome = "Rossi", email = "",password="io" });
            repoUtenti.GetAll().ToList().ForEach(u => Console.WriteLine(u.nome));   
            repoUtenti.Save();
            repoUtenti.GetAll().ToList().ForEach(u => Console.WriteLine(u.nome));
        }
    }
}
