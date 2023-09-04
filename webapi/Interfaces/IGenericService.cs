namespace webapi.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<int> GetCountAsync();
        Task<bool> Exists(int id);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}
