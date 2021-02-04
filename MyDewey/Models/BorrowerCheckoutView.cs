using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Models
{
    public class BorrowerCheckoutView
    {
        public int CheckoutId { get; set; }
        public int BorrowerUserProfileId { get; set; }
        public int ItemId { get; set; }
        public int OwnerUserProfileId { get; set; }
        public string ItemName { get; set; }
        public string ItemImageLocation { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string OwnerUserName { get; set; }
        public string OwnerImageLocation { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Declined { get; set; }
    }
}
