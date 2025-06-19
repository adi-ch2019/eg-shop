namespace EgShopApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryController : ControllerBase
    {
        private readonly IGroceryService _groceryService;

        public GroceryController(IGroceryService groceryService)
        {
            _groceryService = groceryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Grocery>> Get()
        {
            return await _groceryService.GetAllGroceriesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grocery>> Get(int id)
        {
            var grocery = await _groceryService.GetGroceryByIdAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }
            return grocery;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Grocery grocery)
        {
            await _groceryService.AddGroceryAsync(grocery);
            return CreatedAtAction(nameof(Get), new { id = grocery.Id }, grocery);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Grocery grocery)
        {
            if (id != grocery.Id)
            {
                return BadRequest();
            }
            await _groceryService.UpdateGroceryAsync(grocery);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _groceryService.DeleteGroceryAsync(id);
            return NoContent();
        }
    }
}
