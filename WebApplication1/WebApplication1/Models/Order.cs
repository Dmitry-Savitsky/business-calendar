using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }

        [StringLength(255)]
        public string OrderComment { get; set; }

        [Required]
        public DateTime OrderStart { get; set; }

        public DateTime? OrderEnd { get; set; }

        public bool? Confirmed { get; set; }
        public bool? Completed { get; set; }

        public int IdClient { get; set; }
        public Client? Client { get; set; }

        public int IdService { get; set; }
        public Service? Service { get; set; }

        public int IdClientAddress { get; set; }
        public ClientAddress? ClientAddress { get; set; }

        public int IdCompany { get; set; }
        public Company? Company { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }

        [JsonIgnore]
        public ICollection<OrderHasExecutor> OrderHasExecutors { get; set; }
    }
}