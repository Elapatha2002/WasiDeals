using System.ComponentModel.DataAnnotations;

namespace Admin.Models.viewmodel
{
    public class AuctionCreateViewModel
    {
        public int AuctionId { get; set; }

        [Required]
        [StringLength(100)]
        public string AuctionName { get; set; }

        [Required]
        public DateOnly AuctionStartDate { get; set; }

        [Required]
        public TimeSpan AuctionStartTime { get; set; }

        [Required]
        public TimeSpan TimeBtwItemChange { get; set; }

        public List<int> SelectedItemIds { get; set; } = new List<int>();

        [Required]
        public string AuctionStatus { get; set; }
        
        public string? HighestBid {  get; set; }

        public List<ItemViewModel> AvailableItems { get; set; } = new List<ItemViewModel>();

        public class ItemViewModel
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; }
            public string ItemDescription { get; set; }
            public decimal MinimumBid { get; set; }
            public string Picture { get; set; }
            public string SellerName { get; set; }
        }
    }

}
