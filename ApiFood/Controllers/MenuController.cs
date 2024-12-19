using Microsoft.AspNetCore.Mvc;
using ApiFood.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly LucavicFoodEatContext _context; // Замените на ваш DbContext

        public MenuController(LucavicFoodEatContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Menus>>> GetMenuItems()
        {
            return await _context.Menus.ToListAsync();
        }

        // GET: api/Menu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Menus>> GetMenuItem(int id)
        {
            var menuItem = await _context.Menus.FindAsync(id);

            if (menuItem == null)
            {
                return NotFound();
            }

            return menuItem;
        }

        // POST: api/Menu
        [HttpPost]
        public async Task<ActionResult<Menus>> CreateMenuItem(Menus menuItem)
        {
            _context.Menus.Add(menuItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.MenuId }, menuItem);
        }

        // PUT: api/Menu/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, Menus menuItem)
        {
            if (id != menuItem.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Menu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItem = await _context.Menus.FindAsync(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menuItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MenuItemExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}