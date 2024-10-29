using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    //---------------Users class inherit by UserActivity class----------------
    public class Users : UserActivity
    {

        //----------------------primary key----------------------
        [Key]
        public int UserId { get; set; }

        //-------------------------------------------------------
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Phone]
        public string UserPhoneNumber { get; set; }

        public string UserAddress { get; set; }

        [Required]
        public string UserStatus { get; set; }

    }
}
