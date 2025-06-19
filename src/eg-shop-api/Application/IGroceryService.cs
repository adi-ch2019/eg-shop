namespace EgShopApi.Application
{
    public interface IGroceryService
    {
        Task<IEnumerable<Grocery>> GetAllGroceriesAsync();
        Task<Grocery?> GetGroceryByIdAsync(int id);
        Task AddGroceryAsync(Grocery grocery);
        Task UpdateGroceryAsync(Grocery grocery);
        Task DeleteGroceryAsync(int id);
    }
}
