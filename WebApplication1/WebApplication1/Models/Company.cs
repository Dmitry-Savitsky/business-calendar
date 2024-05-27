using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }

        [StringLength(45)]
        public string CompanyName { get; set; }

        [StringLength(15)]
        public string CompanyPhone { get; set; }

        [StringLength(150)]
        public string CompanyAddress { get; set; }

        [StringLength(45)]
        public string Login { get; set; }

        [StringLength(255)]
        public string Password { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<Executor> Executors { get; set; }
        [JsonIgnore]
        public ICollection<Service> Services { get; set; }
    }
}