using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Mappers
{
    public class VentasMapper
    {
        public static Ventas Map(Ventas dto)
        {
            return new Ventas()
            {
               // VentasId = dto.VentasId,
                VendedorId = dto.VendedorId,
                VehiculoId = dto.VehiculoId,
                FechaVenta = dto.FechaVenta
            };
        }
    }
}
