using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Domains.Entities;
using InfoPortal.Persistence.DbSettings;
using Microsoft.EntityFrameworkCore;

namespace InfoPortal.Persistence.Repositories
{
    public class NewsRepository : BaseRepository<NewsDb>, INewsRepository
    {
        public NewsRepository(InfoPortalDBContext context) : base(context)
        {
        }

        public async Task<List<NewsDb>> GetAllAsync()
        {
            return await _db.Include(e => e.Tags).ToListAsync();
        }
    }
}
