using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Navigation properties
        [ForeignKey("IdClient")]
        public Client Client { get; set; }
    }
}