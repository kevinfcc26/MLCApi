using System;
using System.Collections.Generic;

namespace MLCApi.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculos = new HashSet<Vehiculos>();
        }

        public int MarcaId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vehiculos> Vehiculos { get; set; }
    }
}
