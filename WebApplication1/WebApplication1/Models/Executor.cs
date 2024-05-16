using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Executor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdExecutor { get; set; }

        [Required]
        [StringLength(255)]
        public string ExecutorName { get; set; }

        [Required]
        [StringLength(45)]
        public string ExecutorPhone { get; set; }

        public int IdCompany { get; set; }

        // Navigation properties
        [ForeignKey("IdCompany")]
        public Company Company { get; set; }
    }
}