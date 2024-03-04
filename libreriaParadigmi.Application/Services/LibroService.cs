using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Application.Models.DTO;
using libreriaParadigmi.Models.Entities;
using libreriaParadigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;
        public LibroService(LibroRepository libroRepository) 
        {
            _libroRepository = libroRepository;
        }
        public void AddLibro(string nome, string autore, string editore, DateTime data, HashSet<Categoria>categorie)
        {
            Libro libro = new Libro(nome, autore, editore, data, categorie);
            _libroRepository.Add(libro);
            _libroRepository.Save();
        }

        public IEnumerable<Libro> GetLibri(string categoria, string nome, string autore, DateOnly dataPubblicazione)
        {
            //TODO : ricordarsi di fare la paginazione!!!
            throw new NotImplementedException();
        }

        public bool RemoveLibro(int id)
        {
            if(_libroRepository.Get(id) != null)
            {
                _libroRepository.Delete(_libroRepository.Get(id));
                _libroRepository.Save();
                return true;
            }
            return false;
        }

        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<Categoria> categorie)
        {
            if(_libroRepository.Get(id) != null)
            {
                Libro l = _libroRepository.Get(id);
                l.nome = nome;
                l.autore = autore;
                l.editore = editore;
                l.dataPubblicazione = data;
                l.categorie = categorie;
                _libroRepository.Update(l);
                _libroRepository.Save();
                return true;
            }
            return false;
        }
    }
}
