using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OrderHasExecutor
    {
        public int IdOrder { get; set; }
        public int IdExecutor { get; set; }

        // Navigation properties
        [ForeignKey("IdOrder")]
        public Order Order { get; set; }

        [ForeignKey("IdExecutor")]
        public Executor Executor { get; set; }
    }
}