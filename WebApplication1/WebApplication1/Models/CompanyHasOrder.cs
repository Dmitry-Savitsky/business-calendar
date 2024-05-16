using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CompanyHasOrder
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyIdCompany { get; set; }

        [Key]
        [Column(Order = 2)]
        public int OrderIdOrder { get; set; }

        // Navigation properties
        [ForeignKey("CompanyIdCompany")]
        public Company Company { get; set; }

        [ForeignKey("OrderIdOrder")]
        public Order Order { get; set; }
    }
}