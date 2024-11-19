using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Items
    {
        //----------------------primary key----------------------
        [Key]
        public int ItemId { get; set; }

        //-------------------------------------------------------
        [Required]
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinimumBid { get; set; }

        // Stores the image file path
        public string? Picture { get; set; }

        [Required]
        public int Qty { get; set; }
    }
}
