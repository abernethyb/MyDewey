using Microsoft.Extensions.Configuration;
using MyDewey.Models;
using MyDewey.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Repositories
{
    public class ItemRepository : BaseRepository, IItemRepository
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
        public List<Item> GetUserItems(int userProfileId)
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
                                        Left Join Category c ON i.CategoryId = c.Id
                                        WHERE i.UserProfileId = @userProfileId AND i.Flagdelete = 0";

                    DbUtils.AddParameter(cmd, "@userProfileId", userProfileId);


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

        public List<Item> GetNonUserItems(int userProfileId)
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
                                        Left Join Category c ON i.CategoryId = c.Id
                                        WHERE i.UserProfileId != @userProfileId AND i.Flagdelete = 0 AND i.Available = 1";

                    DbUtils.AddParameter(cmd, "@userProfileId", userProfileId);


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
        public void Add(Item item)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Item (
	                                        UserProfileId,
	                                        CategoryId,
	                                        Available,
	                                        Private,
	                                        ImageLocation,
	                                        Name,
	                                        Author,
	                                        Maker,
	                                        Model,
	                                        YearMade,
	                                        Notes,
	                                        ExternalId
			                                          )
	                                        OUTPUT INSERTED.ID

	                                        VALUES (
	                                        @UserProfileId,
	                                        @CategoryId,
	                                        1,
	                                        0,
	                                        @ImageLocation,
	                                        @Name,
	                                        @Author,
	                                        @Maker,
	                                        @Model,
	                                        @YearMade,
	                                        @Notes,
	                                        @ExternalId
			                                        );";

                    DbUtils.AddParameter(cmd, "@UserProfileId", item.UserProfileId);
                    DbUtils.AddParameter(cmd, "@CategoryId", item.CategoryId);
                    DbUtils.AddParameter(cmd, "@Available", item.Available);
                    DbUtils.AddParameter(cmd, "@Private", item.Private);
                    DbUtils.AddParameter(cmd, "@ImageLocation", item.ImageLocation);
                    DbUtils.AddParameter(cmd, "@Name", item.Name);
                    DbUtils.AddParameter(cmd, "@Author", item.Author);
                    DbUtils.AddParameter(cmd, "@Maker", item.Maker);
                    DbUtils.AddParameter(cmd, "@Model", item.Model);
                    DbUtils.AddParameter(cmd, "@YearMade", item.YearMade);
                    DbUtils.AddParameter(cmd, "@Notes", item.Notes);
                    DbUtils.AddParameter(cmd, "@ExternalId", item.ExternalId);

                    item.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

    }
}
