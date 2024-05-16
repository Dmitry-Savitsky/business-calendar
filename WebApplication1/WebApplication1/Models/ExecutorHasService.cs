using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ExecutorHasService
    {
        public int IdExecutor { get; set; }
        public int IdService { get; set; }

        // Navigation properties
        [ForeignKey("IdExecutor")]
        public Executor Executor { get; set; }

        [ForeignKey("IdService")]
        public Service Service { get; set; }
    }
}