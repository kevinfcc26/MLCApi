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
    public class VendedoresRepository : IRepository<Vendedores>
    {
        //CRUD --> CREATE READ UPDATE DELETE
        private readonly ConcesionarioContext _concesionarioContext;

        public VendedoresRepository(ConcesionarioContext concesionarioContext)
        {
            _concesionarioContext = concesionarioContext;
        }

        public async Task<Vendedores> Add(Vendedores entity)
        {
            await _concesionarioContext.Vendedores.AddAsync(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Vendedores> Update(int identity, Vendedores updateEnt)
        {
            var entity = await Get(identity);

            entity.Nombre = updateEnt.Nombre;

            _concesionarioContext.Vendedores.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return entity;
        }
        public async Task<Vendedores> Update(Vendedores entity)
        {
            var updateEntity = _concesionarioContext.Vendedores.Update(entity);

            await _concesionarioContext.SaveChangesAsync();

            return updateEntity.Entity;
        }

        public async Task<Vendedores> Get(int identity)
        {
            var result = await _concesionarioContext.Vendedores.FirstOrDefaultAsync(x => x.VendedoresId == identity);

            return result;
        }
        
        public async Task DeleteAsync(int identity)
        {
            var entity = await _concesionarioContext.Vendedores.SingleAsync(x => x.VendedoresId == identity);
            _concesionarioContext.Vendedores.Remove(entity);

            await _concesionarioContext.SaveChangesAsync();
        }

        public Task<bool> Exit(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vendedores>> GetAll()
        {
            return _concesionarioContext.Vendedores.Select(x => x);
        }
    }
}
