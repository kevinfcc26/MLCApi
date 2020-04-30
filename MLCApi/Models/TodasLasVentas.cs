using System;
using System.Collections.Generic;

namespace MLCApi.Models
{
    public partial class TodasLasVentas
    {
        public int VentasId { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Vehiculo { get; set; }
        public string Marca { get; set; }
        public int? Precio { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
