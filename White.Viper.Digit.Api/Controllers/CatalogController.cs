using Microsoft.AspNetCore.Mvc;
using White.Viper.Digit.Domain.Catalog;
using White.Viper.Digit.Data;


namespace White.Viper.Digit.Api.Controllers
{
    [ApiController]
    [Route("/catalog")]
    public class CatalogController : ControllerBase
    {
    
        private readonly StoreContext _db;
        
        public CatalogController(StoreContext db)
        {
            _db = db;
        }

      [HttpGet]
      public IActionResult GetItems()
    {
        return Ok(_db.Items);

    } 

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id)
        { 
            var item = _db.Items.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPost]
        public IActionResult Post(Item item)
        {
           _db.Items.Add(item);
           _db.SaveChanges();
           return Created($"/catalog/{item.Id}", item);
        }
        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt.", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);

            return Ok(item);
        }
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }  

}
