using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClient { get; set; }

        [Required]
        [StringLength(255)]
        public string ClientName { get; set; }

        [Required]
        [StringLength(45)]
        public string ClientPhone { get; set; }

        // Navigation properties

        [JsonIgnore]
        public ICollection<ClientAddress> ClientAddresses { get; set; }
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        [JsonIgnore]
        public ICollection<Review> Reviews { get; set; }
    }
}