using System.Collections.Generic;
using System.Threading.Tasks;
using EgShopApi.Domain;
using EgShopApi.Domain.Entities;

namespace EgShopApi.Application
{
    public class GroceryService : IGroceryService
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceryService(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public async Task<IEnumerable<Grocery>> GetAllGroceriesAsync()
        {
            return await _groceryRepository.GetAllAsync();
        }

        public async Task<Grocery?> GetGroceryByIdAsync(int id)
        {
            return await _groceryRepository.GetByIdAsync(id);
        }

        public async Task AddGroceryAsync(Grocery grocery)
        {
            await _groceryRepository.AddAsync(grocery);
        }

        public async Task UpdateGroceryAsync(Grocery grocery)
        {
            await _groceryRepository.UpdateAsync(grocery);
        }

        public async Task DeleteGroceryAsync(int id)
        {
            await _groceryRepository.DeleteAsync(id);
        }
    }
}
