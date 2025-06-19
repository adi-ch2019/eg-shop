namespace EgShopApi.Domain
{
    public interface IGroceryRepository
    {
        Task<IEnumerable<Grocery>> GetAllAsync();
        Task<Grocery?> GetByIdAsync(int id);
        Task AddAsync(Grocery grocery);
        Task UpdateAsync(Grocery grocery);
        Task DeleteAsync(int id);
    }
}
