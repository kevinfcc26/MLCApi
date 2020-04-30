using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Models.ApiModels
{
    public class Vendedor
    {
        //public int VendedoresId { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
