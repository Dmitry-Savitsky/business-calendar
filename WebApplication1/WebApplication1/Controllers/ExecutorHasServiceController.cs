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
    [Route("api/executorhasservices")]
    [ApiController]
    public class ExecutorHasServiceController : ControllerBase
    {
        private readonly RepairManagementDbContext _context;

        public ExecutorHasServiceController(RepairManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/executorhasservices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExecutorHasService>>> GetExecutorHasServices()
        {
            return await _context.ExecutorHasServices
                                 .Include(ehs => ehs.Executor)
                                 .Include(ehs => ehs.Service)
                                 .ToListAsync();
        }

        // GET: api/executorhasservices/{idExecutor}/{idService}
        [HttpGet("{idExecutor}/{idService}")]
        public async Task<ActionResult<ExecutorHasService>> GetExecutorHasService(int idExecutor, int idService)
        {
            var executorHasService = await _context.ExecutorHasServices
                .Include(ehs => ehs.Executor)
                .Include(ehs => ehs.Service)
                .FirstOrDefaultAsync(ehs => ehs.IdExecutor == idExecutor && ehs.IdService == idService);

            if (executorHasService == null)
            {
                return NotFound();
            }

            return executorHasService;
        }

        public class ExecutorHasServiceCreationDto
        {
            [Required]
            public int IdExecutor { get; set; }

            [Required]
            public int IdService { get; set; }
        }

        // POST: api/executorhasservices
        [HttpPost]
        public async Task<ActionResult<ExecutorHasService>> PostExecutorHasService([FromBody] ExecutorHasServiceCreationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid executor-service data");
            }

            var executorHasService = new ExecutorHasService
            {
                IdExecutor = dto.IdExecutor,
                IdService = dto.IdService
            };

            _context.ExecutorHasServices.Add(executorHasService);
            await _context.SaveChangesAsync();

            // Загрузите связанные сущности Executor и Service
            await _context.Entry(executorHasService).Reference(ehs => ehs.Executor).LoadAsync();
            await _context.Entry(executorHasService).Reference(ehs => ehs.Service).LoadAsync();

            return CreatedAtAction("GetExecutorHasService", new { idExecutor = executorHasService.IdExecutor, idService = executorHasService.IdService }, executorHasService);
        }

        // DELETE: api/executorhasservices/{idExecutor}/{idService}
        [HttpDelete("{idExecutor}/{idService}")]
        public async Task<IActionResult> DeleteExecutorHasService(int idExecutor, int idService)
        {
            var executorHasService = await _context.ExecutorHasServices
                .FirstOrDefaultAsync(ehs => ehs.IdExecutor == idExecutor && ehs.IdService == idService);

            if (executorHasService == null)
            {
                return NotFound();
            }

            _context.ExecutorHasServices.Remove(executorHasService);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}