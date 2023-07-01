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
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
          //if (_context.Employees == null)
          //{
          //    return NotFound();
          //}
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/title
        [HttpGet("{title}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByTitle(string title)
        {
            
            var employee = await _context.Employees.Where(c => c.Title == title).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/city
        [HttpGet("{City}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByCity(string city)
        {

            var employee = await _context.Employees.Where(c => c.City == city).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/Region
        [HttpGet("{Region}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByRegion(string region)
        {

            var employee = await _context.Employees.Where(c => c.Region == region).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET: api/Employees/title
       [HttpGet("HireDate/{HireDate}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByDate(DateTime HireDate)
        {

            var employees = await _context.Employees.Where(c => c.HireDate == HireDate).ToListAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }


        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'NorthwindContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
