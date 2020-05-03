using MLCApi.IRepositories;
using MLCApi.Mappers;
using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public class VentasService : IVentasService
    {
        private readonly IRepository<Ventas> _ventasRepository;
        public VentasService(IRepository<Ventas> ventasRepository)
        {
            _ventasRepository = ventasRepository;
        }

        public async Task<Ventas> GetVentas(int id)
        {
            var entidad = await _ventasRepository.Get(id);
            if (entidad == null)
            {
                return new Ventas()
                {
                    
                };
            }
            return VentasMapper.Map(entidad);
            //return entidad;
        }
        public async Task<Ventas> AddVentas(Ventas ventas)
        {
           var addedEntity = await _ventasRepository.Add(VentasMapper.Map(ventas));

            return addedEntity;
        }

        public async Task<IEnumerable<Ventas>> GetAllVentas()
        {
            var ventas = await _ventasRepository.GetAll();

            return ventas.Select(VentasMapper.Map);
        }

        public async Task DeleteVentas(int id)
        {
            await _ventasRepository.DeleteAsync(id);
        }

        public async Task<Ventas> UpdateVentas(Ventas ventas)
        {
            var update = await _ventasRepository.Update(ventas);

            return VentasMapper.Map(update);
        }
    }
}
