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

        public async Task<string> GetVendedoresName(int id)
        {
            var entidad = await _VendedoresRepository.Get(id);
            if (entidad == null)
            {
                return "No hay vendedor creado";
            }
            return entidad.Nombre;
        }
        public async Task<Vendedores> AddAdmin(Vendedores vendedores)
        {
           var addedEntity = await _VendedoresRepository.Add(VendedoresMapper.Map(vendedores));

            return addedEntity;
        }
    }
}
