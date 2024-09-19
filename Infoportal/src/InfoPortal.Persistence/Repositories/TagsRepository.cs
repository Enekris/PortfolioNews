using InfoPortal.Application.Contracts.Database.Repositories;
using InfoPortal.Domains.Entities;
using InfoPortal.Persistence.DbSettings;
using Microsoft.EntityFrameworkCore;

namespace InfoPortal.Persistence.Repositories
{
    public class TagsRepository : BaseRepository<TagDb>, ITagsRepository
    {
        public TagsRepository(InfoPortalDBContext context) : base(context)
        {
        }

        public async Task<List<TagDb>> GetAllAsync()
        {
            return await _db.Include(e => e.News).ToListAsync();
        }
    }
}
