using libreriaParadigmi.Application.Abstractions;
using libreriaParadigmi.Models.Entities;
using libreriaParadigmi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }
        public bool AddCategoria(string nome)
        {
            Categoria categoria = new Categoria();
            categoria.nome = nome;
            if(_categoriaRepository.GetByNome(nome) != null)
            {
                return false;
            }
            _categoriaRepository.Add(categoria);
            _categoriaRepository.Save();
            return true;
        }

        public bool RemoveCategoria(string nome)
        {
            Categoria categoria = _categoriaRepository.GetByNome(nome);
            if(categoria != null&& !categoria.libri.Any())          //controlla che non ci siano libri associati alla categoria e che la categoria esista
            {
                _categoriaRepository.Delete(categoria);
                _categoriaRepository.Save();
                return true;
            }
            return false;
        }
    }
}
