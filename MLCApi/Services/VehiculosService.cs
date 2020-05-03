using MLCApi.IRepositories;
using MLCApi.Mappers;
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

            var Vendedores  = await _vendedoresService.GetVendedores(idVendedores);
        }
        public async Task<Vehiculos> GetVehiculos(int id)
        {
            var entidad = await _vehiculosRepository.Get(id);
            if (entidad == null)
            {
                return new Vehiculos()
                {
                    MarcaId = -1,
                    Nombre = "no existe vendedor"

                };
            }
            return VehiculosMapper.Map(entidad);
            //return entidad;
        }
        public async Task<Vehiculos> AddVehiculos(Vehiculos marca)
        {
            var addedEntity = await _vehiculosRepository.Add(VehiculosMapper.Map(marca));

            return addedEntity;
        }

        public async Task<IEnumerable<Vehiculos>> GetAllVehiculos()
        {
            var vehiculos = await _vehiculosRepository.GetAll();

            return vehiculos.Select(VehiculosMapper.Map);
        }

        public async Task DeleteVehiculos(int id)
        {
            await _vehiculosRepository.DeleteAsync(id);
        }

        public async Task<Vehiculos> UpdateVehiculos(Vehiculos vehiculos)
        {
            var update = await _vehiculosRepository.Update(vehiculos);

            return VehiculosMapper.Map(update);
        }
    }
}
