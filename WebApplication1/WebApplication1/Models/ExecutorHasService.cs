using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class ExecutorHasService
    {
        public int IdExecutor { get; set; }
        public Executor? Executor { get; set; }

        public int IdService { get; set; }
        public Service? Service { get; set; }
    }
}