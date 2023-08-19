using Deneme.Application.Interfaces.Repositories;
using Deneme.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<TEntity> Create(TEntity entity)
        {
            TEntity data = _appDbContext.Add(entity).Entity;
            _appDbContext.SaveChanges();

            return Task.FromResult(data);
        }

        public Task<TEntity> GetById(int id)
        {
            TEntity data = _appDbContext.Set<TEntity>().FirstOrDefault(p => p.Id == id);

            return Task.FromResult(data);

        }

        public Task<List<TEntity>> GetAll()
        {
            List<TEntity> Entities = _appDbContext.Set<TEntity>().ToList();

            return Task.FromResult(Entities);
        }

        public Task<TEntity> Update(TEntity entity)
        {
            _appDbContext.Attach(entity);

            TEntity data = _appDbContext.Update(entity).Entity;

            _appDbContext.SaveChanges();

            return Task.FromResult(data);
        }
    }
}
