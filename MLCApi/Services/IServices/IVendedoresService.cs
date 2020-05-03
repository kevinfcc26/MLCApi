using MLCApi.Models;
using MLCApi.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IVendedoresService 
    { 
        Task<IEnumerable<Vendedores>> GetAllVendedores();
        Task<Vendedores> GetVendedores(int id);
        Task<Vendedores> AddVendedor(Vendedores vendedores);
        Task DeleteVendedor(int id);
        Task<Vendedores> UpdateVendedor(Vendedores vendedores);

    }
}
