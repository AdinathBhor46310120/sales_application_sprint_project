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
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public OrdersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        /*
          //Get: api/orders/orderbyemployee/{Firstname}
        [HttpGet("{FirstName}")]

        public async Task<ActionResult<Shipper>> GetShipperByCompanyName(string FirstName)
        {
            var firstname = await _context.Orders.Where(o => o.FirstName == FirstName).FirstOrDefaultAsync();

            if (firstname == null)
            {
                return NotFound();
            }

            return firstname;
        }
         */

        // GET: api/shitpdetails/5
        [HttpGet("shipdetails/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        /*
          //Get: /api/orders/BetweenDate/{FromDate}/{ToDate}
        [HttpGet("{FirstName}")]

        public async Task<ActionResult<Shipper>> GetShipperByCompanyName(string FirstName)
        {
            var firstname = await _context.Orders.Where(o => o.FirstName == FirstName).FirstOrDefaultAsync();

            if (firstname == null)
            {
                return NotFound();
            }

            return firstname;
        }
         */

        /*
          //Get: /api/orders/allshipdetails
        [HttpGet("{FirstName}")]

        public async Task<ActionResult<Shipper>> GetShipperByCompanyName(string FirstName)
        {
            var firstname = await _context.Orders.Where(o => o.FirstName == FirstName).FirstOrDefaultAsync();

            if (firstname == null)
            {
                return NotFound();
            }

            return firstname;
        }
         */

        /*
          //Get: /api/orders/numberoforderbyeachemployee
        [HttpGet("{FirstName}")]

        public async Task<ActionResult<Shipper>> GetShipperByCompanyName(string FirstName)
        {
            var firstname = await _context.Orders.Where(o => o.FirstName == FirstName).FirstOrDefaultAsync();

            if (firstname == null)
            {
                return NotFound();
            }

            return firstname;
        }
         */


        // GET: api/orderDetails
        [HttpGet("ordersDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {

            var orders = await _context.OrderDetails.ToListAsync();



            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // GET: api/orderDetails/{EmployeeID}
        [HttpGet("ordersDetails/{EmployeeID}")]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetailsByEmployeeId(int EmployeeID)
        {
            List<OrderDetail> output = new List<OrderDetail>();

            var orders = await _context.Orders.Where(o => o.EmployeeId == EmployeeID).ToListAsync();

            foreach (var order in orders)
            {
                var orderdetails = await _context.OrderDetails.Where(od => od.OrderId == order.OrderId).FirstOrDefaultAsync();
                output.Add(orderdetails);
            }


            return output;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}

