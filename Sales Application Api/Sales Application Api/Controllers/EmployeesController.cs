using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales_Application_Api.Models;
using static NuGet.Packaging.PackagingConstants;

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

        // POST: api/employee
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

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            return await _context.Employees.ToListAsync();
        }

        // PUT: api/employee/edit/5
        [HttpPut("edit/{id}")]
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

        // PATCH: api/employee/edit/5
        [HttpPatch("edit/{EmployeeID}")]
        public async Task<IActionResult> PatchEmployee(int EmployeeID, JsonPatchDocument<Employee> employeePatch)
        {
            var employee = await this._context.Employees.FindAsync(EmployeeID);

            if (employee != null)
            {
                employeePatch.ApplyTo(employee);
                _context.SaveChanges();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // GET: api/employees/title/{title}
        [HttpGet("title/{title}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByTitle(string title)
        {

            var employees = await _context.Employees.Where(c => c.Title == title).ToListAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // GET: api/employee/City/{City}
        [HttpGet("City/{City}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByCity(string City)
        {

            var employee = await _context.Employees.Where(c => c.City == City).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/Employees/Region/{RegionDescription}
        [HttpGet("Region/{RegionDescription}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByRegion(string RegionDescription)
        {

            var employee = await _context.Employees.Where(c => c.Region == RegionDescription).ToListAsync();

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        //GET: api/Employees/HireDate
        [HttpGet("HireDate/{HireDate}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeByDate(string HireDate)
        {
            DateTime date = DateTime.Parse(HireDate);
            var employees = await _context.Employees.Where(c => c.HireDate == date).ToListAsync();

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        //GET: api/Employees/highestsalebyemployee/{EmployeeID}
        [HttpGet("highestsalebyemployee/{EmployeeID}")]
        public async Task<ActionResult<IEnumerable<SalesTotalsByAmount>>> GetHeightSaleByEmployee(int EmployeeID)
        {

            var salesTotalByAmount = await _context.SalesTotalsByAmounts.ToListAsync();
            if(salesTotalByAmount == null)
            {
                return BadRequest();
            }

            var employeeSales = new List<SalesTotalsByAmount>();

            foreach(var sta in salesTotalByAmount)
            {
                var order = await _context.Orders.Where(o => o.OrderId == sta.OrderId).FirstOrDefaultAsync();

                if(order.EmployeeId == EmployeeID)
                {
                    employeeSales.Add(sta);
                }
            }

            return Ok(employeeSales.OrderByDescending(s => s.SaleAmount));

            //List<OrderDetail> ordersDetails = new List<OrderDetail>();

            //foreach (var order in orders)
            //{
            //    var orderDetail = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
            //    if (orderDetail != null)
            //    {

            //        ordersDetails.Add(orderDetail);
            //    }
            //}
        }

        //GET: api/Employees/highestsalebyemployee/{Date}
        [HttpGet("salebyemploye/date/{EmployeeID}/{Date}")]
        public async Task<ActionResult<IEnumerable<SalesTotalsByAmount>>> GetHeightSaleByEmployeeOnDate(int EmployeeID,string Date)
        {

            var dt = DateTime.Parse(Date);

            var salesTotalByAmount = await _context.SalesTotalsByAmounts.ToListAsync();
            if (salesTotalByAmount == null)
            {
                return BadRequest();
            }

            var employeeSales = new List<SalesTotalsByAmount>();

            foreach (var sta in salesTotalByAmount)
            {
                var order = await _context.Orders.Where(o => o.OrderId == sta.OrderId).FirstOrDefaultAsync();

                if (order.EmployeeId == EmployeeID && order.OrderDate == dt)
                {
                    employeeSales.Add(sta);
                }
            }

            return Ok(employeeSales.OrderByDescending(s => s.SaleAmount));

            //List<OrderDetail> ordersDetails = new List<OrderDetail>();

            //foreach (var order in orders)
            //{
            //    var orderDetail = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
            //    if (orderDetail != null)
            //    {

            //        ordersDetails.Add(orderDetail);
            //    }
            //}
        }

        //GET: api/Employees/highestsalebyemployee/{Date}
        [HttpGet("salebyemploye/year/{EmployeeID}/{Year}")]
        public async Task<ActionResult<IEnumerable<SalesTotalsByAmount>>> GetHeightSaleByEmployeeOnYear(int EmployeeID, string Year)
        {

            

            var salesTotalByAmount = await _context.SalesTotalsByAmounts.ToListAsync();
            if (salesTotalByAmount == null)
            {
                return BadRequest();
            }

            var employeeSales = new List<SalesTotalsByAmount>();

            foreach (var sta in salesTotalByAmount)
            {
                var order = await _context.Orders.Where(o => o.OrderId == sta.OrderId).FirstOrDefaultAsync();

                if (order.EmployeeId == EmployeeID && order.OrderDate.Year == int.Parse(Year))
                {
                    employeeSales.Add(sta);
                }
            }

            return Ok(employeeSales.OrderByDescending(s => s.SaleAmount));

            //List<OrderDetail> ordersDetails = new List<OrderDetail>();

            //foreach (var order in orders)
            //{
            //    var orderDetail = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
            //    if (orderDetail != null)
            //    {

            //        ordersDetails.Add(orderDetail);
            //    }
            //}
        }

        //GET: api/Employees/highestsalebyemployee/{Date}
        [HttpGet("salebyemploye/month/{EmployeeID}/{Month}")]
        public async Task<ActionResult<IEnumerable<SalesTotalsByAmount>>> GetHeightSaleByEmployeeInMonth(int EmployeeID, string Month)
        {



            var salesTotalByAmount = await _context.SalesTotalsByAmounts.ToListAsync();
            if (salesTotalByAmount == null)
            {
                return BadRequest();
            }

            var employeeSales = new List<SalesTotalsByAmount>();

            foreach (var sta in salesTotalByAmount)
            {
                var order = await _context.Orders.Where(o => o.OrderId == sta.OrderId).FirstOrDefaultAsync();

                if (order.EmployeeId == EmployeeID && order.OrderDate.Month == int.Parse(Month))
                {
                    employeeSales.Add(sta);
                }
            }

            return Ok(employeeSales.OrderByDescending(s => s.SaleAmount));

            //List<OrderDetail> ordersDetails = new List<OrderDetail>();

            //foreach (var order in orders)
            //{
            //    var orderDetail = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
            //    if (orderDetail != null)
            //    {

            //        ordersDetails.Add(orderDetail);
            //    }
            //}
        }

        //GET: api/Employees/highestsalebyemployee/{Date}
        [HttpGet("salebyemploye/betweendate/{EmployeeID}/{FromDate}/{ToDate}")]
        public async Task<ActionResult<IEnumerable<SalesTotalsByAmount>>> GetHeightSaleByEmployeeFromToDate(int EmployeeID, string FromDate,string ToDate)
        {



            var salesTotalByAmount = await _context.SalesTotalsByAmounts.ToListAsync();
            if (salesTotalByAmount == null)
            {
                return BadRequest();
            }

            var employeeSales = new List<SalesTotalsByAmount>();

            foreach (var sta in salesTotalByAmount)
            {
                var order = await _context.Orders.Where(o => o.OrderId == sta.OrderId).FirstOrDefaultAsync();

                if (order.EmployeeId == EmployeeID && order.OrderDate >= DateTime.Parse(FromDate) && order.OrderDate <= DateTime.Parse(ToDate))
                {
                    employeeSales.Add(sta);
                }
            }

            return Ok(employeeSales.OrderByDescending(s => s.SaleAmount));

            //List<OrderDetail> ordersDetails = new List<OrderDetail>();

            //foreach (var order in orders)
            //{
            //    var orderDetail = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
            //    if (orderDetail != null)
            //    {

            //        ordersDetails.Add(orderDetail);
            //    }
            //}
        }





        //GET: /api/employee/orders/{EmployeeID}
        [HttpGet("orders/{EmployeeID}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersPlacedByEmployee(int EmployeeID)
    {

            var orders = await _context.Orders.Where(o => o.EmployeeId == EmployeeID).ToListAsync();

            if(orders == null)
            {
                return BadRequest();
            }

            return Ok(orders);
    }


    //GET: /api/employee/companyname/{EmployeeID}
    [HttpGet("companyname/{EmployeeID}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetCompanyName(int EmployeeID)
    {

            List<string> companyNames = new List<string>();

            var suppilers = await this._context.Suppliers.ToListAsync();

            if(suppilers == null)
            {
                return BadRequest();
            }

            foreach(var supplier in suppilers)
            {
                companyNames.Add(supplier.CompanyName);
            }

            return Ok(companyNames);

    }


        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
