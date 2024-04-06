using System.ComponentModel.DataAnnotations;

namespace nft_marketplace.Models
{
    public class createBid
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public int minBid { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime expDate { get; set; }
        
        [Required]
        public string title { get; set; }

        
        public string description { get; set; }
    }
}
