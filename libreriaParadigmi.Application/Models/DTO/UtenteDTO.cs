using libreriaParadigmi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.DTO
{
    public class UtenteDTO
    {
        public string nome { get; set; } = string.Empty;
        public string cognome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public UtenteDTO(Utente u)
        {
            this.nome = u.nome;
            this.cognome = u.cognome;
            this.email = u.email;
            this.password = u.password;
        }
    }
}
