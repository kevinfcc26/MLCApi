using MLCApi.IRepositories;
using MLCApi.Mappers;
using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IRepository<Marca> _marcaRepository;
        public MarcaService(IRepository<Marca> marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<Marca> GetMarca(int id)
        {
            var entidad = await _marcaRepository.Get(id);
            if (entidad == null)
            {
                return new Marca()
                {
                    MarcaId = -1,
                    Nombre = "no existe vendedor"

                };
            }
            return MarcaMapper.Map(entidad);
            //return entidad;
        }
        public async Task<Marca> AddMarca(Marca marca)
        {
           var addedEntity = await _marcaRepository.Add(MarcaMapper.Map(marca));

            return addedEntity;
        }

        public async Task<IEnumerable<Marca>> GetAllMarca()
        {
            var Marca = await _marcaRepository.GetAll();

            return Marca.Select(MarcaMapper.Map);
        }

        public async Task DeleteMarca(int id)
        {
            await _marcaRepository.DeleteAsync(id);
        }

        public async Task<Marca> UpdateMarca(Marca marca)
        {
            var update = await _marcaRepository.Update(marca);

            return MarcaMapper.Map(update);
        }
    }
}
