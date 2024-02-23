using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Models.Entities
{
    public class Utente
    {
        public int id { get; set; }
        public string nome { get; set; } = string.Empty;
        public string cognome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
