using MLCApi.IRepositories;
using MLCApi.Mappers;
using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public class VendedoresService : IVendedoresService
    {
        private readonly IRepository<Vendedores> _VendedoresRepository;
        public VendedoresService(IRepository<Vendedores> VendedoresRepository)
        {
            _VendedoresRepository = VendedoresRepository;
        }

        public async Task<Vendedores> GetVendedores(int id)
        {
            var entidad = await _VendedoresRepository.Get(id);
            if (entidad == null)
            {
                return new Vendedores()
                {
                    VendedoresId = -1,
                    Nombre = "no existe vendedor"

                };
            }
            return VendedoresMapper.Map(entidad);
            //return entidad;
        }
        public async Task<Vendedores> AddVendedor(Vendedores vendedores)
        {
           var addedEntity = await _VendedoresRepository.Add(VendedoresMapper.Map(vendedores));

            return addedEntity;
        }

        public async Task<IEnumerable<Vendedores>> GetAllVendedores()
        {
            var vendedores = await _VendedoresRepository.GetAll();

            return vendedores.Select(VendedoresMapper.Map);
        }

        public async Task DeleteVendedor(int id)
        {
            await _VendedoresRepository.DeleteAsync(id);
        }

        public async Task<Vendedores> UpdateVendedor(Vendedores vendedores)
        {
            var update = await _VendedoresRepository.Update(vendedores);

            return VendedoresMapper.Map(update);
        }
    }
}
