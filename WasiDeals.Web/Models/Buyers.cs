using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{

    //---------------Buyers class inherit by UserActivity class----------------
    public class Buyers : UserActivity
    {
       
            //----------------------primary key----------------------
            [Key]
            public int BuyerId { get; set; }

            //-------------------------------------------------------
            [Required]
            [StringLength(100)]
            public string BuyerName { get; set; }

            [Required]
            [EmailAddress]
            public string BuyerEmail { get; set; }

            [Phone]
            public string BuyerPhoneNumber { get; set; }

            public string BuyerAddress { get; set; }
        }
}
