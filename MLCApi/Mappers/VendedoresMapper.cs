using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Mappers
{
    public class VendedoresMapper
    {
        public static Vendedores Map(Vendedores dto)
        {
            return new Vendedores()
            {
                //VendedoresId = dto.VendedoresId,
                Cedula = dto.Cedula,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Edad = dto.Edad,
                FechaInicio = dto.FechaInicio
            };
        }
    }
}
