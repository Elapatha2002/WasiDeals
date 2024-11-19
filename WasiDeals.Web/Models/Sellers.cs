using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    //---------------Seller class inherit by UserActivity class---------------
    public class Sellers : UserActivity
    {
       

        //----------------------primary key----------------------
        [Key]
        public int SellerId { get; set; }

        //-------------------------------------------------------

        [Required] //Validation
        [StringLength(100)]
        public string SellerName { get; set; }

        [Required]
        [EmailAddress]
        public string SellerEmail { get; set; }

        [Phone]
        public string SellerPhoneNumber { get; set; }
        public string SellerAddress { get; set; }
    }
}
