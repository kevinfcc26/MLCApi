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
    public class VentasRepository : IRepository<Ventas>
    {
        //CRUD --> CREATE READ UPDATE DELETE
        private readonly ConcesionarioContext _concesionarioContext;

        public VentasRepository(ConcesionarioContext concesionarioContext)
        {
            _concesionarioContext = concesionarioContext;
        }

        public async Task<Ventas> Add(Ventas entity)
        {
            await _concesionarioContext.Ventas.AddAsync(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Ventas> Update(int identity, Ventas updateEnt)
        {
            var entity = await Get(identity);

            entity.FechaVenta = updateEnt.FechaVenta;

            _concesionarioContext.Ventas.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }
        public async Task<Ventas> Update(Ventas entity)
        {
            var updateEntity = _concesionarioContext.Ventas.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Ventas> Get(int identity)
        {
            var result = await _concesionarioContext.Ventas.FirstOrDefaultAsync(x => x.VentasId == identity);

            return result;
        }
        
        public async Task DeleteAsync(int identity)
        {
            var entity = await _concesionarioContext.Ventas.SingleAsync(x => x.VentasId == identity);
            _concesionarioContext.Ventas.Remove(entity);

            await _concesionarioContext.SaveChangesAsync();
        }

        public Task<bool> Exit(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ventas>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
