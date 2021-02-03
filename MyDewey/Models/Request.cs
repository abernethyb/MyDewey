using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Models
{
    /*
     c.Id,

c.UserProfileId AS BorrowerUserProfileId,

c.ItemId,

i.UserProfileId AS OwnerUserProfileId,

i.Name AS ItemName,

i.ImageLocation,

i.CategoryId,

cat.Name AS CategoryName,

u.UserName AS BorrowerUserName,

c.RequestDate
     */
    public class Request
    {
        public int CheckoutId { get; set; }
        public int BorrowerUserProfileId { get; set; }
        public int ItemId { get; set; }
        public int OwnerUserProfileId { get; set; }
        public string ItemName { get; set; }
        public string ImageLocation { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BorrowerUserName { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
