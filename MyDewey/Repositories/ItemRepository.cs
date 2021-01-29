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
                            Id = DbUtils.GetInt(reader, "Id"),
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId"),
                            OwnerUserName = DbUtils.GetString(reader, "OwnerUserName"),
                            CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                            CategoryName = DbUtils.GetString(reader, "CategoryName"),
                            Available = reader.GetBoolean(reader.GetOrdinal("Available")),
                            Private = reader.GetBoolean(reader.GetOrdinal("Private")),
                            OwnerPostalCode = DbUtils.GetString(reader, "OwnerPostalCode"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            Name = DbUtils.GetString(reader, "Name"),
                            Author = DbUtils.GetString(reader, "Author"),
                            Maker = DbUtils.GetString(reader, "Maker"),
                            Model = DbUtils.GetString(reader, "Model"),
                            YearMade = DbUtils.GetInt(reader, "YearMade"),
                            Notes = DbUtils.GetString(reader, "Notes"),
                            ExternalId = DbUtils.GetString(reader, "ExternalId")

                        });
                    }

                    reader.Close();

                    return items;
                }
            }
        }

    }
}
