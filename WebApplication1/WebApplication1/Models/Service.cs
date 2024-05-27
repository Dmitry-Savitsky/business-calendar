using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Service
    {
        [Key]
        public int IdService { get; set; }

        [Required]
        [StringLength(255)]
        public string ServiceName { get; set; }

        public int ServiceType { get; set; }

        [Required]
        public int? ServicePrice { get; set; }

        public int IdCompany { get; set; }

        public Company? Company { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public ICollection<ExecutorHasService> ExecutorHasServices { get; set; }
    }
}