using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReview { get; set; }

        [StringLength(255)]
        public string ReviewText { get; set; }

        [Required]
        public int ReviewRating { get; set; }

        public int IdClient { get; set; }
        public int IdOrder { get; set; }

        // Navigation properties
        [ForeignKey("IdClient")]
        public Client Client { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
    }
}