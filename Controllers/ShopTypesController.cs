using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlowerShops.Models;

namespace FlowerShops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopTypesController : ControllerBase
    {
        private readonly FlowerShopsContext _context;

        public ShopTypesController(FlowerShopsContext context)
        {
            _context = context;
        }

        // GET: api/ShopTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopTypes>>> GetShopTypes()
        {
            return await _context.ShopTypes.ToListAsync();
        }

        // GET: api/ShopTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopTypes>> GetShopTypes(int id)
        {
            var shopTypes = await _context.ShopTypes.FindAsync(id);

            if (shopTypes == null)
            {
                return NotFound();
            }

            return shopTypes;
        }

        // PUT: api/ShopTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopTypes(int id, ShopTypes shopTypes)
        {
            if (id != shopTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(shopTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopTypesExists(id))
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

        // POST: api/ShopTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShopTypes>> PostShopTypes(ShopTypes shopTypes)
        {
            _context.ShopTypes.Add(shopTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopTypes", new { id = shopTypes.Id }, shopTypes);
        }

        // DELETE: api/ShopTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShopTypes>> DeleteShopTypes(int id)
        {
            var shopTypes = await _context.ShopTypes.FindAsync(id);
            if (shopTypes == null)
            {
                return NotFound();
            }

            _context.ShopTypes.Remove(shopTypes);
            await _context.SaveChangesAsync();

            return shopTypes;
        }

        private bool ShopTypesExists(int id)
        {
            return _context.ShopTypes.Any(e => e.Id == id);
        }
    }
}
