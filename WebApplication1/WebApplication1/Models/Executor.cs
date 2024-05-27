using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        public Company? Company { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<OrderHasExecutor> OrderHasExecutors { get; set; }

        [JsonIgnore]
        public ICollection<ExecutorHasService> ExecutorHasServices { get; set; }
    }
}