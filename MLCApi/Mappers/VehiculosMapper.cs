using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Mappers
{
    public class VehiculosMapper
    {
        public static Vehiculos Map(Vehiculos dto)
        {
            return new Vehiculos()
            {
                //VehiculosId = dto.VehiculosId,
                Nombre = dto.Nombre,
                MarcaId = dto.MarcaId,
                Modelo = dto.Modelo,
                Cilindraje = dto.Cilindraje,
                Precio = dto.Precio
            };
        }
    }
}
