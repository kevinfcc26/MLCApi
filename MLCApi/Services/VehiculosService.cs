using MLCApi.IRepositories;
using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public class VehiculosService : IVehiculosService
    {
        private readonly IVendedoresService _vendedoresService;
        private readonly IRepository<Vehiculos> _vehiculosRepository;

         public VehiculosService(IRepository<Vehiculos> vehiculosRepository,IVendedoresService vendedoresService)
        {
            _vendedoresService = vendedoresService;
            _vehiculosRepository = vehiculosRepository;
        }

        public async Task GetVehiculosName(int idVehiculos, int idVendedores)
        {
            var Vehiculos = await _vehiculosRepository.Get(idVehiculos);

            var Vendedores  = await _vendedoresService.GetVendedoresName(idVendedores);
        }

    }
}
