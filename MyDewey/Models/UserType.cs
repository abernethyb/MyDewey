using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(255) NOT NULL
 */

namespace MyDewey.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
