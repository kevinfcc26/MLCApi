using MLCApi.Models;
using MLCApi.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IVentasService
    { 
        Task<IEnumerable<Ventas>> GetAllVentas();
        Task<Ventas> GetVentas(int id);
        Task<Ventas> AddVentas(Ventas ventas);
        Task DeleteVentas(int id);
        Task<Ventas> UpdateVentas(Ventas ventas);

    }
}
