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
        private readonly CategoriaRepository _categoriaRepository;
        public LibroService(LibroRepository libroRepository, CategoriaRepository categoriaRepository)
        {
            _libroRepository = libroRepository;
            _categoriaRepository = categoriaRepository;
        }
        public bool AddLibro(string nome, string autore, string editore, DateTime data, HashSet<string>categorie)
        {
            HashSet<Categoria> categorieSet = new HashSet<Categoria>();
            categorieSet = GetCategorie(categorie);
            Libro libro = new Libro(nome, autore, editore, data, categorieSet);
            _libroRepository.Add(libro);
            _libroRepository.Save();
            return true;
        }
        private HashSet<Categoria> GetCategorie(HashSet<string> categorie)
        {
            HashSet<Categoria> categorieSet = new HashSet<Categoria>();
            //vado a prendere solo le categorie che esistono
            foreach (string c in categorie)
            {
                Categoria categoria = _categoriaRepository.GetByNome(c);
                if (categoria != null)
                {
                    categorieSet.Add(categoria);
                }
            }
            return categorieSet;
        }

        public IEnumerable<Libro> GetLibri(string? categoria, string? nome, string? autore, DateTime? dataPubblicazione, int from, int num, out int totalnum)
        {
            return _libroRepository.GetLibri(categoria, nome, autore, dataPubblicazione, from, num, out totalnum);
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

        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<string> categorie)
        {
            HashSet<Categoria> categorieSet = new HashSet<Categoria>();
            categorieSet = GetCategorie(categorie);
            if (_libroRepository.Get(id) != null)
            {
                Libro l = _libroRepository.Get(id);
                l.nome = nome;
                l.autore = autore;
                l.editore = editore;
                l.dataPubblicazione = data;
                l.categorie = categorieSet;
                _libroRepository.Update(l);
                _libroRepository.Save();
                return true;
            }
            return false;
        }
    }
}
