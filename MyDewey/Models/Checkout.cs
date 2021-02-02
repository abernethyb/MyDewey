using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Models
{

    /*
     [Id] integer PRIMARY KEY IDENTITY,
  [UserProfileId] integer NOT NULL,

  [ItemId] integer NOT NULL,

  [RequestDate] datetime NOT NULL,

  [CheckoutDate] datetime,
  [DueDate] datetime,

  [CheckinDate] datetime,

  [ReturnVerifiedDate] datetime,

  [Declined] bit NOT NULL,
  [Hidden] bit NOT NULL
     */
    public class Checkout
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public int ItemId { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CheckoutDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CheckinDate { get; set; }
        public DateTime? ReturnVerifiedDate { get; set; }
        public bool Declined { get; set; }
        public bool Hidden { get; set; }
    }
}
