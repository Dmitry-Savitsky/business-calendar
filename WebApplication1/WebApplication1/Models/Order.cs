using System;
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

        public int IdClient { get; set; }
        public int IdService { get; set; }
        public int IdClientAddress { get; set; }

        [Required]
        public DateTime OrderStart { get; set; }

        public DateTime? OrderEnd { get; set; }

        public bool? Confirmed { get; set; }
        public bool? Completed { get; set; }

        // Navigation properties
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        [ForeignKey("IdService")]
        public Service Service { get; set; }

        [ForeignKey("IdClientAddress")]
        public ClientAddress ClientAddress { get; set; }
    }
}