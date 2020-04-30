using MLCApi.Models;
using MLCApi.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Mappers
{
    public class VendedorMapper
    {
        public static Vendedores Map(Vendedor dto)
        {
            return new Vendedores()
            {
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
