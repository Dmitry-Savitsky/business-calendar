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
    [Route("api/executors")]
    [ApiController]
    public class ExecutorController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public ExecutorController(RepairManagementDbContext context)
        {
            _context = context;
        }
        public class ExecutorDto
        {
            public int IdExecutor { get; set; }
            public string ExecutorName { get; set; }
            public string ExecutorPhone { get; set; }
            public int IdCompany { get; set; }
        }


        // GET: api/executors/{idCompany}
        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<ExecutorDto>>> GetExecutors(int idCompany)
        {
            var executors = await _context.Executors
                                          .Where(e => e.IdCompany == idCompany)
                                          .ToListAsync();

            var executorDtos = executors.Select(e => new ExecutorDto
            {
                IdExecutor = e.IdExecutor,
                ExecutorName = e.ExecutorName,
                ExecutorPhone = e.ExecutorPhone,
                IdCompany = e.IdCompany
            });

            return Ok(executorDtos);
        }

        public class ExecutorCreationDto
        {
            [Required]
            [StringLength(255)]
            public string ExecutorName { get; set; }

            [Required]
            [StringLength(45)]
            public string ExecutorPhone { get; set; }

            public int IdCompany { get; set; }
        }

        // POST: api/executors
        [HttpPost]
        public async Task<ActionResult<Executor>> PostExecutor([FromBody] ExecutorCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid executor data");
            }

            var executor = new Executor
            {
                ExecutorName = dto.ExecutorName,
                ExecutorPhone = dto.ExecutorPhone,
                IdCompany = dto.IdCompany
            };

            Console.WriteLine($"Received data: ExecutorName={dto.ExecutorName}, ExecutorPhone={dto.ExecutorPhone}, IdCompany={dto.IdCompany}");

            _context.Executors.Add(executor);
            await _context.SaveChangesAsync();

            // Загрузите связанную сущность Company
            await _context.Entry(executor).Reference(e => e.Company).LoadAsync();

            return CreatedAtAction("GetExecutors", new { idCompany = executor.IdCompany }, executor);
        }

        // DELETE: api/executors/{idExecutor}
        [HttpDelete("{idExecutor}")]
        public async Task<IActionResult> DeleteExecutor(int idExecutor)
        {
            var executor = await _context.Executors.FindAsync(idExecutor);
            if (executor == null)
            {
                return NotFound();
            }

            // Remove related entries from ExecutorHasService
            var services = _context.ExecutorHasServices.Where(ehs => ehs.IdExecutor == idExecutor);
            _context.ExecutorHasServices.RemoveRange(services);

            // Remove related entries from OrderHasExecutor
            var orders = _context.OrderHasExecutors.Where(ohe => ohe.IdExecutor == idExecutor);
            _context.OrderHasExecutors.RemoveRange(orders);

            _context.Executors.Remove(executor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}