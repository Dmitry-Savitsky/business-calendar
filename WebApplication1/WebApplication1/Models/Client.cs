using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public ICollection<ClientAddress> ClientAddresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}