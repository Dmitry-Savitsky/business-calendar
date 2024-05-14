using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/executors")]
    [ApiController]
    public class ExecutorController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetExecutors()
        {
            var executors = new[]
            {
                new {Name = "Dmitry"},
                new {Name = "Oleg"}
            };
            return Ok(executors);
        }
    }
}
