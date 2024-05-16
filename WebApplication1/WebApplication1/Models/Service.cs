using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdService { get; set; }

        [Required]
        [StringLength(255)]
        public string ServiceName { get; set; }

        [Required]
        public int ServiceType { get; set; }

        public int? ServicePrice { get; set; }

        public int IdCompany { get; set; }

        // Navigation properties
        [ForeignKey("IdCompany")]
        public Company Company { get; set; }
    }
}