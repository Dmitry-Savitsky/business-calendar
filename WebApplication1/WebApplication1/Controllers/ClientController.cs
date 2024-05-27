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
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public ClientController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients
                                 .Include(c => c.ClientAddresses)
                                 .Include(c => c.Orders)
                                 .Include(c => c.Reviews)
                                 .ToListAsync();
        }

        // GET: api/clients/{idClient}
        [HttpGet("{idClient}")]
        public async Task<ActionResult<Client>> GetClient(int idClient)
        {
            var client = await _context.Clients
                                       .Include(c => c.ClientAddresses)
                                       .Include(c => c.Orders)
                                       .Include(c => c.Reviews)
                                       .FirstOrDefaultAsync(c => c.IdClient == idClient);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        public class ClientCreationDto
        {
            [Required]
            [StringLength(255)]
            public string ClientName { get; set; }

            [Required]
            [StringLength(45)]
            public string ClientPhone { get; set; }
        }

        // POST: api/clients
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient([FromBody] ClientCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid client data");
            }

            var client = new Client
            {
                ClientName = dto.ClientName,
                ClientPhone = dto.ClientPhone
            };

            Console.WriteLine($"Received data: ClientName={dto.ClientName}, ClientPhone={dto.ClientPhone}");

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            // Загрузите связанные сущности ClientAddresses, Orders и Reviews
            await _context.Entry(client).Collection(c => c.ClientAddresses).LoadAsync();
            await _context.Entry(client).Collection(c => c.Orders).LoadAsync();
            await _context.Entry(client).Collection(c => c.Reviews).LoadAsync();

            return CreatedAtAction("GetClient", new { idClient = client.IdClient }, client);
        }

        // DELETE: api/clients/{idClient}
        [HttpDelete("{idClient}")]
        public async Task<IActionResult> DeleteClient(int idClient)
        {
            var client = await _context.Clients.FindAsync(idClient);
            if (client == null)
            {
                return NotFound();
            }

            // Remove related entries from ClientAddresses
            var addresses = _context.ClientAddresses.Where(ca => ca.IdClient == idClient);
            _context.ClientAddresses.RemoveRange(addresses);

            // Remove related entries from Orders
            var orders = _context.Orders.Where(o => o.IdClient == idClient);
            _context.Orders.RemoveRange(orders);

            // Remove related entries from Reviews
            var reviews = _context.Reviews.Where(r => r.IdClient == idClient);
            _context.Reviews.RemoveRange(reviews);

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}