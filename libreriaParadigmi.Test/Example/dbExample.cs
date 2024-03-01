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
            var repoLibri = new LibroRepository(ctx);
            var repoCategorie = new CategoriaRepository(ctx);
            /*
            repoUtenti.Add(new Utente { nome = "Luigi", cognome = "Rossi", email = "luigi@gmail.com",password="io" });
            repoUtenti.GetAll().ToList().ForEach(u => Console.WriteLine(u.nome));   
            repoUtenti.Save();
            repoUtenti.GetAll().ToList().ForEach(u => Console.WriteLine(u.nome));
            repoCategorie.Add(new Categoria { nome = "Fantasy" });  
            repoCategorie.Save();
            repoLibri.Add(new Libro { nome = "Il signore", autore = "Tolkien", editore = "Mondadori", dataPubblicazione = DateTime.Now });
            repoLibri.Save();
            repoCategorie.Add(new Categoria { nome = "Spy" });
            repoCategorie.Save();
            var libro = repoLibri.Get(1);
            libro.categorie.Add(repoCategorie.Get(2));
            repoLibri.Update(libro);
            repoLibri.Save();
             */
            var libro = repoLibri.Get(1);
            libro.categorie.ToList().ForEach(c => Console.WriteLine(c.nome));
        }
    }
}
