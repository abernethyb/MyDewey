using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

/*
 CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,

  [FirebaseUserId] nvarchar(28) NOT NULL,

  [UserTypeId] integer NOT NULL,

  [Username] nvarchar(255) NOT NULL,

  [FirstName] nvarchar(255),

  [LastName] nvarchar(255),

  [Image] nvarchar(4000),

  [Email] nvarchar(255) NOT NULL,

  [PostalCode] nvarchar(255) NOT NULL
)
 * */

namespace MyDewey.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        [StringLength(28, MinimumLength = 28)]
        public string FirebaseUserId { get; set; }

        public int UserTypeId { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageLocation { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }

    }
}
