using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public interface IVehiculosService
    {
        Task<IEnumerable<Vehiculos>> GetAllVehiculos();
        Task<Vehiculos> GetVehiculos(int id);
        Task<Vehiculos> AddVehiculos(Vehiculos vehiculos);
        Task DeleteVehiculos(int id);
        Task<Vehiculos> UpdateVehiculos(Vehiculos vehiculos);
    }
}
