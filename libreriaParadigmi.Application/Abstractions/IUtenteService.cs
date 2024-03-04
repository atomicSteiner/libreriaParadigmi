using libreriaParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Abstractions
{
    public interface IUtenteService
    {
        Utente GetUtente(string id);
    }
}
