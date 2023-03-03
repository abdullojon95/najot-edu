namespace NajotEdu.Application.Abstractions
{
    public interface ICrudService<T, V, C, U>
    {
        Task<V> GetByIdAsync(T id);
        Task<List<V>> GetAllAsync();
        Task CreateAsync(C model);
        Task UpdateAsync(U model);
        Task DeleteAsync(T id);
    }
}
