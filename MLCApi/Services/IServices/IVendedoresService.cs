using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IVendedoresService 
    { 
        Task<string> GetVendedoresName(int id);
        Task<Vendedores> AddAdmin(Vendedores vendedores);
    }
}
