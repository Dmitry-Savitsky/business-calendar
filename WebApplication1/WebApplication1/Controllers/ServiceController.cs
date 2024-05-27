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
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public ServiceController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/services/{idCompany}
        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices(int idCompany)
        {
            return await _context.Services
                                 .Where(s => s.IdCompany == idCompany)
                                 .Include(s => s.Company)
                                 .ToListAsync();
        }

        public class ServiceCreationDto
        {
            [Required]
            [StringLength(255)]
            public string ServiceName { get; set; }

            [Required]
            public int ServiceType { get; set; }

            public int? ServicePrice { get; set; }

            public int IdCompany { get; set; }
        }

        // POST: api/services
        [HttpPost]
        public async Task<ActionResult<Service>> PostService([FromBody] ServiceCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid service data");
            }

            var service = new Service
            {
                ServiceName = dto.ServiceName,
                ServiceType = dto.ServiceType,
                ServicePrice = dto.ServicePrice,
                IdCompany = dto.IdCompany
            };

            Console.WriteLine($"Received data: ServiceName={dto.ServiceName}, ServiceType={dto.ServiceType}, ServicePrice={dto.ServicePrice}, IdCompany={dto.IdCompany}");

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            // Загрузите связанную сущность Company
            await _context.Entry(service).Reference(s => s.Company).LoadAsync();

            return CreatedAtAction("GetServices", new { idCompany = service.IdCompany }, service);
        }

        // DELETE: api/services/{idService}
        [HttpDelete("{idService}")]
        public async Task<IActionResult> DeleteService(int idService)
        {
            var service = await _context.Services.FindAsync(idService);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}