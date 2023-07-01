using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_Application_Api.Models;

namespace Sales_Application_Api.Controllers
{
    [Route("api/shippers")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ShippersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Shippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            return await _context.Shippers.ToListAsync();
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> GetShipper(int id)
        {
          if (_context.Shippers == null)
          {
              return NotFound();
          }
            var shipper = await _context.Shippers.FindAsync(id);

            if (shipper == null)
            {
                return NotFound();
            }

            return shipper;
        }

        //GET: api/shipper/{companyname}

        [HttpGet("{CompanyName}")]

        public async Task<ActionResult<Shipper>> GetShipperByCompanyName(string CompanyName)
        {
            var company = await _context.Shippers.Where(c => c.CompanyName== CompanyName).FirstOrDefaultAsync();

            if(company == null)
            {
                return NotFound();
            }

            return company;
        }
   

        // PUT: api/Shippers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("edit/{ShipperID}")]
        public async Task<IActionResult> PutShipper(int ShipperID, Shipper shipper)
        {
            if (ShipperID != shipper.ShipperId)
            {
                return BadRequest();
            }

            _context.Entry(shipper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipperExists(ShipperID))
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


        // PATCH: api/Shippers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPatch("edit/{ShipperID}")]
        public async Task<IActionResult> PatchShipper(int ShipperID, JsonPatchDocument<Shipper> shipperPatch)
        {
            var shipper = await this._context.Shippers.FindAsync(ShipperID);

            if(shipper != null)
            {
                shipperPatch.ApplyTo(shipper);
                _context.SaveChanges();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/Shippers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> PostShipper(Shipper shipper)
        {
          if (_context.Shippers == null)
          {
              return Problem("Entity set 'NorthwindContext.Shippers'  is null.");
          }
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();

            return Ok("Record Created Successfully");
        }

        // DELETE: api/Shippers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            if (_context.Shippers == null)
            {
                return NotFound();
            }
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper == null)
            {
                return NotFound();
            }

            _context.Shippers.Remove(shipper);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipperExists(int id)
        {
            return (_context.Shippers?.Any(e => e.ShipperId == id)).GetValueOrDefault();
        }
    }
}
