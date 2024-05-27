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
    [Route("api/orderhasexecutors")]
    [ApiController]
    public class OrderHasExecutorController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public OrderHasExecutorController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/orderhasexecutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHasExecutor>>> GetOrderHasExecutors()
        {
            return await _context.OrderHasExecutors
                                 .Include(ohe => ohe.Order)
                                    .ThenInclude(o => o.Client)
                                 .Include(ohe => ohe.Order)
                                    .ThenInclude(o => o.Service)
                                 .Include(ohe => ohe.Order)
                                    .ThenInclude(o => o.ClientAddress)
                                 .Include(ohe => ohe.Order)
                                    .ThenInclude(o => o.Company)
                                 .Include(ohe => ohe.Executor)
                                    .ThenInclude(e => e.Company)
                                 .ToListAsync();
        }

        // GET: api/orderhasexecutors/{idOrder}/{idExecutor}
        [HttpGet("{idOrder}/{idExecutor}")]
        public async Task<ActionResult<OrderHasExecutor>> GetOrderHasExecutor(int idOrder, int idExecutor)
        {
            var orderHasExecutor = await _context.OrderHasExecutors
                                                 .Include(ohe => ohe.Order)
                                                    .ThenInclude(o => o.Client)
                                                 .Include(ohe => ohe.Order)
                                                    .ThenInclude(o => o.Service)
                                                 .Include(ohe => ohe.Order)
                                                    .ThenInclude(o => o.ClientAddress)
                                                 .Include(ohe => ohe.Order)
                                                    .ThenInclude(o => o.Company)
                                                 .Include(ohe => ohe.Executor)
                                                    .ThenInclude(e => e.Company)
                                                 .FirstOrDefaultAsync(ohe => ohe.IdOrder == idOrder && ohe.IdExecutor == idExecutor);

            if (orderHasExecutor == null)
            {
                return NotFound();
            }

            return orderHasExecutor;
        }

        public class OrderHasExecutorCreationDto
        {
            [Required]
            public int IdOrder { get; set; }

            [Required]
            public int IdExecutor { get; set; }
        }

        // POST: api/orderhasexecutors
        [HttpPost]
        public async Task<ActionResult<OrderHasExecutor>> PostOrderHasExecutor([FromBody] OrderHasExecutorCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid order-executor data");
            }

            // Проверка существования заказа
            var order = await _context.Orders.FindAsync(dto.IdOrder);
            if (order == null)
            {
                return BadRequest($"Order with IdOrder {dto.IdOrder} does not exist.");
            }

            // Проверка существования исполнителя
            var executor = await _context.Executors.FindAsync(dto.IdExecutor);
            if (executor == null)
            {
                return BadRequest($"Executor with IdExecutor {dto.IdExecutor} does not exist.");
            }

            var orderHasExecutor = new OrderHasExecutor
            {
                IdOrder = dto.IdOrder,
                IdExecutor = dto.IdExecutor
            };

            _context.OrderHasExecutors.Add(orderHasExecutor);
            await _context.SaveChangesAsync();

            // Загрузите связанные сущности Order и Executor
            await _context.Entry(orderHasExecutor).Reference(ohe => ohe.Order).LoadAsync();
            await _context.Entry(orderHasExecutor).Reference(ohe => ohe.Executor).LoadAsync();

            return CreatedAtAction("GetOrderHasExecutor", new { idOrder = orderHasExecutor.IdOrder, idExecutor = orderHasExecutor.IdExecutor }, orderHasExecutor);
        }

        // DELETE: api/orderhasexecutors/{idOrder}/{idExecutor}
        [HttpDelete("{idOrder}/{idExecutor}")]
        public async Task<IActionResult> DeleteOrderHasExecutor(int idOrder, int idExecutor)
        {
            var orderHasExecutor = await _context.OrderHasExecutors
                                                 .FirstOrDefaultAsync(ohe => ohe.IdOrder == idOrder && ohe.IdExecutor == idExecutor);

            if (orderHasExecutor == null)
            {
                return NotFound();
            }

            _context.OrderHasExecutors.Remove(orderHasExecutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}