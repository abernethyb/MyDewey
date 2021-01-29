using Microsoft.Extensions.Configuration;
using MyDewey.Models;
using MyDewey.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Repositories
{
    public class ItemRepository : BaseRepository
    {
        public ItemRepository(IConfiguration configuration) : base(configuration) { }

        public List<Item> GetAllItems()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT i.Id,
                                        i.UserProfileId,
                                        u.UserName AS OwnerUserName,
                                        i.CategoryId,
                                        c.Name AS CategoryName,
                                        i.Available,
                                        i.Private,
                                        u.PostalCode AS OwnerPostalCode,
                                        i.ImageLocation,
                                        i.Name,
                                        i.Author,
                                        i.Maker,
                                        i.Model,
                                        i.YearMade,
                                        i.Notes,
                                        i.ExternalId  
                                        FROM Item i
                                        Left Join UserProfile u ON i.UserProfileId = u.Id
                                        Left Join Category c ON i.CategoryId = c.Id";


                    var reader = cmd.ExecuteReader();

                    var items = new List<Item>();
                    while (reader.Read())
                    {
                        items.Add(new Item()
                        {
                            Id = DbUtils.GetInt(reader, "Id")
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                            OwnerUserName = DbUtils.GetString(reader, "OwnerUserName")
                            CategoryId = DbUtils.GetInt(reader, "CategoryId")
                            CategoryName = DbUtils.GetInt(reader, "Id")
                            Available = DbUtils.GetInt(reader, "Id")
                            Private = DbUtils.GetInt(reader, "Id")
                            ImageLocation = DbUtils.GetInt(reader, "Id")
                            Name = DbUtils.GetInt(reader, "Id")
                            Author = DbUtils.GetInt(reader, "Id")
                            Maker = DbUtils.GetInt(reader, "Id")
                            Model = DbUtils.GetInt(reader, "Id")
                            YearMade = DbUtils.GetInt(reader, "Id")
                            Notes = DbUtils.GetInt(reader, "Id")
                            ExternalId = DbUtils.GetInt(reader, "Id")
                            
                        });
                    }

                    reader.Close();

                    return items;
                }
            }
        }

    }
}
