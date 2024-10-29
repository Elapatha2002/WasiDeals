using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class Invoice
    {

        //----------------------primary key----------------------
        [Key]
        public int InvoiceId { get; set; }

        //-------------------------------------------------------

        [Required]
        public string? BuyerName { get; set; }
        public int BuyerId { get; set; }

        [Required]
        public string? SellerName { get; set; }
        public int SellerId { get; set; }

        [Required]
        public string ItemName { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        //----------------------Make TotalPrice nullable----------------------
        public int? TotalPrice { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
