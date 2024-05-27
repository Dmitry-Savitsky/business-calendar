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
    [Route("api/clientaddresses")]
    [ApiController]
    public class ClientAddressController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public ClientAddressController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/clientaddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientAddress>>> GetClientAddresses()
        {
            return await _context.ClientAddresses
                                 .Include(ca => ca.Client)
                                 .ToListAsync();
        }

        // GET: api/clientaddresses/{idClientAddress}
        [HttpGet("{idClientAddress}")]
        public async Task<ActionResult<ClientAddress>> GetClientAddress(int idClientAddress)
        {
            var clientAddress = await _context.ClientAddresses
                                              .Include(ca => ca.Client)
                                              .FirstOrDefaultAsync(ca => ca.IdClientAddress == idClientAddress);

            if (clientAddress == null)
            {
                return NotFound();
            }

            return clientAddress;
        }

        public class ClientAddressCreationDto
        {
            [Required]
            [StringLength(150)]
            public string Address { get; set; }

            [Required]
            public int IdClient { get; set; }
        }

        // POST: api/clientaddresses
        [HttpPost]
        public async Task<ActionResult<ClientAddress>> PostClientAddress([FromBody] ClientAddressCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid client address data");
            }

            var clientAddress = new ClientAddress
            {
                Address = dto.Address,
                IdClient = dto.IdClient
            };

            Console.WriteLine($"Received data: Address={dto.Address}, IdClient={dto.IdClient}");

            _context.ClientAddresses.Add(clientAddress);
            await _context.SaveChangesAsync();

            // Загрузите связанную сущность Client
            await _context.Entry(clientAddress).Reference(ca => ca.Client).LoadAsync();

            return CreatedAtAction("GetClientAddress", new { idClientAddress = clientAddress.IdClientAddress }, clientAddress);
        }

        // DELETE: api/clientaddresses/{idClientAddress}
        [HttpDelete("{idClientAddress}")]
        public async Task<IActionResult> DeleteClientAddress(int idClientAddress)
        {
            var clientAddress = await _context.ClientAddresses.FindAsync(idClientAddress);
            if (clientAddress == null)
            {
                return NotFound();
            }

            _context.ClientAddresses.Remove(clientAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}