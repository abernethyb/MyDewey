using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*
  [Id] integer PRIMARY KEY IDENTITY,

  [UserProfileId] integer NOT NULL,

  [CategoryId] integer NOT NULL,

  [Available] bit NOT NULL,

  [Private] bit NOT NULL,

  [ImageLocation] nvarchar(4000),

  [Name] nvarchar(255),

  [Author] nvarchar(255),

  [Maker] nvarchar(255),

  [Model] nvarchar(255),

  [YearMade] integer,

  [notes] nvarchar(255),

  [ExternalId] nvarchar(255)
 */


namespace MyDewey.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }

        //from user profile
        public string OwnerUserName { get; set; }
        public int CategoryId { get; set; }

        //from user category
        public string CategoryName { get; set; }
        public bool Available { get; set; }

        //only for frinds to see
        public bool Private { get; set; }
        
        //from user profile
        public string OwnerPostalCode { get; set; }
        public string ImageLocation { get; set; }

        //ex: hammer, book title, etc
        public string Name { get; set; }
        public string Author { get; set; }

        //or publisher, etc...
        public string Maker { get; set; }
        public string Model { get; set; }
        public int YearMade { get; set; }
        public string Notes { get; set; }

        //isbn, serial, etc
        public string ExternalId { get; set; }
    }
}
