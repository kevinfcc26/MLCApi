using MLCApi.Models;
using MLCApi.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IMarcaService
    { 
        Task<IEnumerable<Marca>> GetAllMarca();
        Task<Marca> GetMarca(int id);
        Task<Marca> AddMarca(Marca marca);
        Task DeleteMarca(int id);
        Task<Marca> UpdateMarca(Marca marca);

    }
}
