using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Application.Exeptions;
using InfoPortal.Domains.Entities;
using InfoPortal.Persistence.DbSettings;
using Microsoft.EntityFrameworkCore;

namespace InfoPortal.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        internal readonly DbSet<T> _db;
        internal readonly InfoPortalDBContext _context;
        public BaseRepository(InfoPortalDBContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task CreateAsync(T baseEntity)
        {
            baseEntity.Id = Guid.NewGuid();
            baseEntity.CreateDate = DateTime.Now;
            baseEntity.UpdateDate = DateTime.Now;
            _db.Add(baseEntity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid Id)
        {
            var baseEntity = await GetAsync(Id);
            _db.Remove(baseEntity);
            await SaveChangesAsync();
        }

        public async Task<T> GetAsync(Guid Id)
        {
            return await _db.FindAsync(Id) ?? throw new NotFoundException();
        }

        public async Task UpdateAsync(T baseEntity)
        {
            baseEntity.UpdateDate = DateTime.Now;
            _context.Entry(baseEntity).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}

