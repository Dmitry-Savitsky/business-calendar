using EntityFrameworkCore.MySQL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        // GET: api/Executors/5
        [HttpGet("{idCompany}")]
        public async Task<ActionResult<IEnumerable<Executor>>> GetExecutors(int idCompany)
        {
            return await _context.Executors.Where(e => e.IdCompany == idCompany).ToListAsync();
        }

        public class ExecutorCreationDto
        {
            [Required]
            [StringLength(255)]
            public string ExecutorName { get; set; }

            [Required]
            [StringLength(45)]
            public string ExecutorPhone { get; set; }

            // Дополнительно можно добавить идентификатор компании, если он передается в запросе
            public int IdCompany { get; set; }
        }

        // POST: api/Executors
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

            return CreatedAtAction("GetExecutors", new { idCompany = executor.IdCompany }, executor);
        }

        // DELETE: api/Executors/5
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
