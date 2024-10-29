using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Auctions
    {
        //----------------------primary key----------------------
        [Key]
        public int AuctionId { get; set; }
        //-------------------------------------------------------
        public int BuyerId { get; set; }
        [Required]
        public required string HighestBids { get; set; }
        [Required]
        [StringLength(100)]
        public string AuctionName { get; set; }
        [Required]
        public DateOnly AuctionStartDate { get; set; }
        public TimeSpan AuctionStartTime { get; set; } //hh:mm:ss
        public TimeSpan TimeBtwItemChange { get; set; }
        public string AuctionItems { get; set; }
        [Required]
        public string AuctionStatus { get; set; }
    }
}
