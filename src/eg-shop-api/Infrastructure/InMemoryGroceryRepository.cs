namespace EgShopApi.Infrastructure
{
    public class InMemoryGroceryRepository : IGroceryRepository
    {
        private readonly List<Grocery> _groceries = new List<Grocery>();

        public Task<IEnumerable<Grocery>> GetAllAsync()
        {
            return Task.FromResult(_groceries.AsEnumerable());
        }

        public Task<Grocery?> GetByIdAsync(int id)
        {
            var grocery = _groceries.FirstOrDefault(g => g.Id == id);
            return Task.FromResult(grocery);
        }

        public Task AddAsync(Grocery grocery)
        {
            _groceries.Add(grocery);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Grocery grocery)
        {
            var existing = _groceries.FirstOrDefault(g => g.Id == grocery.Id);
            if (existing != null)
            {
                existing.Name = grocery.Name;
                existing.Price = grocery.Price;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var grocery = _groceries.FirstOrDefault(g => g.Id == id);
            if (grocery != null)
            {
                _groceries.Remove(grocery);
            }
            return Task.CompletedTask;
        }
    }
}
