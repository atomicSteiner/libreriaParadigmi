using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaParadigmi.Application.Models.Requests
{
    public class DeleteLibroRequest
    {
        public int id { get; set; }
        public DeleteLibroRequest(int id)
        {
            this.id = id;
        }
    }
}
