using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CompanyHasOrder
    {
        public int CompanyIdCompany { get; set; }
        public Company? Company { get; set; }

        
        public int OrderIdOrder { get; set; }
        public Order? Order { get; set; }
    }
}