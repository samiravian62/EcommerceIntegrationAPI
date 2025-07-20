using Microsoft.AspNetCore.Mvc;
using EcommerceIntegrationAPI.Data;
using EcommerceIntegrationAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace EcommerceIntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceOrdersController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public EcommerceOrdersController(EcommerceDbContext context)
        {
            _context = context;
        }

        // POST: api/EcommerceOrders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] EcommerceOrder order)
        {
            if (order == null)
                return BadRequest("Order is null.");

            _context.EcommerceOrders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        // GET: api/EcommerceOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EcommerceOrder>> GetOrder(int id)
        {
            var order = await _context.EcommerceOrders.FindAsync(id);

            if (order == null)
                return NotFound();

            return order;
        }

        // GET: api/EcommerceOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EcommerceOrder>>> GetAllOrders()
        {
            return await _context.EcommerceOrders.OrderByDescending(o => o.CreatedOn).ToListAsync();
        }
    }
}
