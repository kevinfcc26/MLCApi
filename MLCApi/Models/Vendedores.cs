using System;
using System.Collections.Generic;

namespace MLCApi.Models
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int VendedoresId { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public DateTime FechaInicio { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
