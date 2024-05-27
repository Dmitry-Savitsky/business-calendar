using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class ClientAddress
    {
        [Key]
        public int IdClientAddress { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        public int IdClient { get; set; }
        public Client? Client { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
    }
}