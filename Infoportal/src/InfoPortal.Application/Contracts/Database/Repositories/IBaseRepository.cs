namespace InfoPortal.Application.Contracts.Database.Repositories
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T baseEntity);
        Task UpdateAsync(T baseEntity);
        Task DeleteAsync(Guid Id);
        Task<T> GetAsync(Guid Id);
        Task SaveChangesAsync();
    }
}
