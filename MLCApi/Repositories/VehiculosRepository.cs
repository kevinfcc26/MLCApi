using Microsoft.EntityFrameworkCore;
using MLCApi.IRepositories;
using MLCApi.Models;
using MLCApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLCApi.Repositories
{
    public class VehiculosRepository : IRepository<Vehiculos>
    {
        //CRUD --> CREATE READ UPDATE DELETE
        private readonly ConcesionarioContext _concesionarioContext;

        public VehiculosRepository(ConcesionarioContext concesionarioContext)
        {
            _concesionarioContext = concesionarioContext;
        }

        public async Task<Vehiculos> Add(Vehiculos entity)
        {
            await _concesionarioContext.Vehiculos.AddAsync(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Vehiculos> Update(int identity, Vehiculos updateEnt)
        {
            var entity = await Get(identity);

            entity.Nombre = updateEnt.Nombre;

            _concesionarioContext.Vehiculos.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }
        public async Task<Vehiculos> Update(Vehiculos entity)
        {
            var updateEntity = _concesionarioContext.Vehiculos.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Vehiculos> Get(int identity)
        {
            var result = await _concesionarioContext.Vehiculos.FirstOrDefaultAsync(x => x.VehiculosId == identity);

            return result;
        }
        
        public async Task DeleteAsync(int identity)
        {
            var entity = await _concesionarioContext.Vehiculos.SingleAsync(x => x.VehiculosId == identity);
            _concesionarioContext.Vehiculos.Remove(entity);

            await _concesionarioContext.SaveChangesAsync();
        }

        public Task<bool> Exit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vehiculos>> GetAll()
        {
            return _concesionarioContext.Vehiculos.Select(x => x);
        }
    }
}
