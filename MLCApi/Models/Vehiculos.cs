using System;
using System.Collections.Generic;

namespace MLCApi.Models
{
    public partial class Vehiculos
    {
        public Vehiculos()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int VehiculosId { get; set; }
        public string Nombre { get; set; }
        public int MarcaId { get; set; }
        public int Modelo { get; set; }
        public int Cilindraje { get; set; }
        public int Precio { get; set; }

        public virtual Marca Marca { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
