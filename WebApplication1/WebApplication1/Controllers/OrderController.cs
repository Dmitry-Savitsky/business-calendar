using EntityFrameworkCore.MySQL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public OrderController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/orders
        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int idCompany)
        {
            return await _context.Orders
                                 .Where(o => o.IdCompany == idCompany)
                                 .Include(o => o.Client)
                                 .Include(o => o.Service)
                                 .Include(o => o.ClientAddress)
                                 .Include(o => o.Company)
                                 .ToListAsync();
        }

        // GET: api/orders/{idCompany}/{idOrder}
        [HttpGet("{idCompany}/{idOrder}")]
        public async Task<ActionResult<Order>> GetOrder(int idCompany, int idOrder)
        {
            var order = await _context.Orders
                                      .Where(o => o.IdCompany == idCompany)
                                      .Include(o => o.Client)
                                      .Include(o => o.Service)
                                      .Include(o => o.ClientAddress)
                                      .Include(o => o.Company)
                                      .FirstOrDefaultAsync(o => o.IdOrder == idOrder);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        public class OrderCreationDto
        {
            [StringLength(255)]
            public string OrderComment { get; set; }

            [Required]
            public DateTime OrderStart { get; set; }

            public DateTime? OrderEnd { get; set; }

            [Required]
            public int IdClient { get; set; }

            [Required]
            public int IdService { get; set; }

            [Required]
            public int IdClientAddress { get; set; }

            [Required]
            public int IdCompany { get; set; }
        }

        // POST: api/orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder([FromBody] OrderCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid order data");
            }

            var order = new Order
            {
                OrderComment = dto.OrderComment,
                OrderStart = dto.OrderStart,
                OrderEnd = dto.OrderEnd,
                Confirmed = false,
                Completed = false,
                IdClient = dto.IdClient,
                IdService = dto.IdService,
                IdClientAddress = dto.IdClientAddress,
                IdCompany = dto.IdCompany
            };

            Console.WriteLine($"Received data: OrderComment={dto.OrderComment}, OrderStart={dto.OrderStart}, OrderEnd={dto.OrderEnd}, Confirmed={false}, Completed={false}, IdClient={dto.IdClient}, IdService={dto.IdService}, IdClientAddress={dto.IdClientAddress}, IdCompany={dto.IdCompany}");

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Загрузите связанные сущности Client, Service, ClientAddress и Company
            await _context.Entry(order).Reference(o => o.Client).LoadAsync();
            await _context.Entry(order).Reference(o => o.Service).LoadAsync();
            await _context.Entry(order).Reference(o => o.ClientAddress).LoadAsync();
            await _context.Entry(order).Reference(o => o.Company).LoadAsync();

            return CreatedAtAction("GetOrder", new { idCompany = dto.IdCompany, idOrder = order.IdOrder }, order);
        }

        public class OrderUpdateDto
        {
            [StringLength(255)]
            public string OrderComment { get; set; }

            [Required]
            public DateTime OrderStart { get; set; }

            public DateTime? OrderEnd { get; set; }

            public bool? Confirmed { get; set; }
            public bool? Completed { get; set; }

            [Required]
            public int IdClient { get; set; }

            [Required]
            public int IdService { get; set; }

            [Required]
            public int IdClientAddress { get; set; }

            [Required]
            public int IdCompany { get; set; }
        }

        // PUT: api/orders/{idCompany}/{idOrder}
        [HttpPut("{idCompany}/{idOrder}")]
        public async Task<IActionResult> PutOrder(int idCompany, int idOrder, [FromBody] OrderUpdateDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid order data");
            }

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.IdOrder == idOrder && o.IdCompany == idCompany);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderComment = dto.OrderComment;
            order.OrderStart = dto.OrderStart;
            order.OrderEnd = dto.OrderEnd;
            order.Confirmed = dto.Confirmed;
            order.Completed = dto.Completed;
            order.IdClient = dto.IdClient;
            order.IdService = dto.IdService;
            order.IdClientAddress = dto.IdClientAddress;
            order.IdCompany = dto.IdCompany;

            Console.WriteLine($"Updated data: OrderComment={dto.OrderComment}, OrderStart={dto.OrderStart}, OrderEnd={dto.OrderEnd}, Confirmed={dto.Confirmed}, Completed={dto.Completed}, IdClient={dto.IdClient}, IdService={dto.IdService}, IdClientAddress={dto.IdClientAddress}, IdCompany={dto.IdCompany}");

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // Загрузите связанные сущности Client, Service, ClientAddress и Company
            await _context.Entry(order).Reference(o => o.Client).LoadAsync();
            await _context.Entry(order).Reference(o => o.Service).LoadAsync();
            await _context.Entry(order).Reference(o => o.ClientAddress).LoadAsync();
            await _context.Entry(order).Reference(o => o.Company).LoadAsync();

            return NoContent();
        }

        // DELETE: api/orders/{idCompany}/{idOrder}
        [HttpDelete("{idCompany}/{idOrder}")]
        public async Task<IActionResult> DeleteOrder(int idCompany, int idOrder)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.IdOrder == idOrder && o.IdCompany == idCompany);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}