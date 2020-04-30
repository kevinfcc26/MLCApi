using System;
using System.Collections.Generic;

namespace MLCApi.Models
{
    public partial class Ventas
    {
        public int VentasId { get; set; }
        public int VendedorId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime FechaVenta { get; set; }

        public virtual Vehiculos Vehiculo { get; set; }
        public virtual Vendedores Vendedor { get; set; }
    }
}
