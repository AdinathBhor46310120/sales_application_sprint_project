using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_Application_Api.Models;

namespace Sales_Application_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public TerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // POST: api/territory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Territory>> PostTerritory(Territory territory)
        {
            if (_context.Territories == null)
            {
                return Problem("Entity set 'NorthwindContext.Territories'  is null.");
            }
            _context.Territories.Add(territory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TerritoryExists(territory.TerritoryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTerritory", new { id = territory.TerritoryId }, territory);
        }

        // GET: api/territory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Territory>>> GetTerritories()
        {
            if (_context.Territories == null)
            {
                return NotFound();
            }
            return await _context.Territories.ToListAsync();
        }

        // GET: api/territory
        [HttpGet("/changedisc")]
        public async Task<ActionResult<string>> change()
        {
            var terrs = await _context.Territories.ToListAsync();
            foreach(var terr in terrs)
            {
                terr.TerritoryDescription = terr.TerritoryDescription.Trim();
                await Console.Out.WriteLineAsync(terr.TerritoryDescription);
                await _context.SaveChangesAsync();
            }

            return Ok("changed");
        }

        // GET: api/territory/region/{region}
        [HttpGet("region/{region}")]
        public async Task<ActionResult<IEnumerable<Territory>>> GetTerritoriesOfRegion(string region)
        {
            var regionObj = await _context.Regions.Where(r => r.RegionDescription == region).FirstOrDefaultAsync();

            if (regionObj == null)
            {
                return BadRequest("Region Do Not Exist");
            }
            
            return await _context.Territories.Where(tr => tr.RegionId == regionObj.RegionId).ToListAsync();

        }

        // PUT: api/territory/edit/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> PutTerritory(string id, Territory territory)
        {
            if (id != territory.TerritoryId)
            {
                return BadRequest();
            }

            _context.Entry(territory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerritoryExists(id))
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

        

        private bool TerritoryExists(string id)
        {
            return (_context.Territories?.Any(e => e.TerritoryId == id)).GetValueOrDefault();
        }
    }
}
