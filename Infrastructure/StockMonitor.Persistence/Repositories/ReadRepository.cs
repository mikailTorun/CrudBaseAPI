using Microsoft.EntityFrameworkCore;
using StockMonitor.Application.Repositories;
using StockMonitor.Domain.Entities.Common;
using StockMonitor.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StockMonitor.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly StockMonitorDbContext _dbContext;

        public ReadRepository(StockMonitorDbContext stockMonitorDbContext)
        {
            _dbContext = stockMonitorDbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable() ;
            if(!tracking)
                query = Table.AsNoTracking() ;

            return query;
        }

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
            return await query.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = tracking ? Table.AsQueryable() : Table.AsQueryable().AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query =  Table.Where(method);
            return tracking ? query : query.AsNoTracking();
        }

        public Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            throw new NotImplementedException();
        }
        public IQueryable<T> Get(int id, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Get(Guid id, bool tracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
