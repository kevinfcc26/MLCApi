using Microsoft.EntityFrameworkCore;
using MLCApi.IRepositories;
using MLCApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Repositories
{
    public class MarcaRepository : IRepository<Marca>
    {
        //CRUD --> CREATE READ UPDATE DELETE
        private readonly ConcesionarioContext _concesionarioContext;

        public MarcaRepository(ConcesionarioContext concesionarioContext)
        {
            _concesionarioContext = concesionarioContext;
        }

        public async Task<Marca> Add(Marca entity)
        {
            await _concesionarioContext.Marca.AddAsync(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Marca> Update(int identity, Marca updateEnt)
        {
            var entity = await Get(identity);

            entity.Nombre = updateEnt.Nombre;

            _concesionarioContext.Marca.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }
        public async Task<Marca> Update(Marca entity)
        {
            var updateEntity = _concesionarioContext.Marca.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Marca> Get(int identity)
        {
            var result = await _concesionarioContext.Marca.FirstOrDefaultAsync(x => x.MarcaId == identity);

            return result;
        }
        
        public async Task DeleteAsync(int identity)
        {
            var entity = await _concesionarioContext.Marca.SingleAsync(x => x.MarcaId == identity);
            _concesionarioContext.Marca.Remove(entity);

            await _concesionarioContext.SaveChangesAsync();
        }

        public Task<bool> Exit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Marca>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
