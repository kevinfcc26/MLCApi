using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Mappers
{
    public class MarcaMapper
    {
        public static Marca Map(Marca dto)
        {
            return new Marca()
            {
               // MarcaId = dto.MarcaId,
                Nombre = dto.Nombre,
            };
        }
    }
}
