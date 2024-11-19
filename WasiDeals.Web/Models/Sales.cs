using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Sales
    {

        //----------------------primary key----------------------
        [Key]
        public int SalesId { get; set; }

        //-------------------------------------------------------
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public string PaymentStatus { get; set; }
    }
}
