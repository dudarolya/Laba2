using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlowerShops.Models;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FlowerShops.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfGoodsController : ControllerBase
    {
        private readonly FlowerShopsContext _context;

        public TypeOfGoodsController(FlowerShopsContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfGoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfGood>>> GetTypeOfGoods()
        {
            return await _context.TypeOfGoods.ToListAsync();
        }

        // GET: api/TypeOfGoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfGood>> GetTypeOfGood(int id)
        {
            var typeOfGood = await _context.TypeOfGoods.FindAsync(id);

            if (typeOfGood == null)
            {
                return NotFound();
            }

            return typeOfGood;
        }

        // PUT: api/TypeOfGoods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfGood(int id, TypeOfGood typeOfGood)
        {
            if (id != typeOfGood.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeOfGood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfGoodExists(id))
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

        // POST: api/TypeOfGoods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeOfGood>> PostTypeOfGood(TypeOfGood typeOfGood)
        {
            if (_context.TypeOfGoods.Where(t => t.Name.ToLower() == typeOfGood.Name.ToLower()).Count() == 0)
            {
                _context.TypeOfGoods.Add(typeOfGood);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTypeOfGood", new { id = typeOfGood.Id }, typeOfGood);
            }
            return NoContent();
        }

        // DELETE: api/TypeOfGoods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeOfGood>> DeleteTypeOfGood(int id)
        {
            var typeOfGood = await _context.TypeOfGoods.FindAsync(id);
            if (typeOfGood == null)
            {
                return NotFound();
            }

            _context.TypeOfGoods.Remove(typeOfGood);
            await _context.SaveChangesAsync();

            return typeOfGood;
        }

        private bool TypeOfGoodExists(int id)
        {
            return _context.TypeOfGoods.Any(e => e.Id == id);
        }
    }
}
