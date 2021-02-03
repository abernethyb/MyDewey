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

        //checkout request from borrower
        public void RequestCheckout(int userProfileId, int itemId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    
                    cmd.CommandText = @"INSERT INTO Checkout (
	                                        UserProfileId,
	                                        ItemId,
	                                        RequestDate,
	                                        CheckoutDate,
	                                        DueDate,
	                                        CheckinDate,
	                                        ReturnVerifiedDate,
	                                        Declined,
	                                        Hidden
			                                          )
	                                        OUTPUT INSERTED.ID

	                                        VALUES (
	                                        @UserProfileId,
	                                        @ItemId,
	                                        GETDATE(),
	                                        NULL,
	                                        NULL,
	                                        NULL,
	                                        NULL,
	                                        0,
	                                        0
			                                        );";

                    DbUtils.AddParameter(cmd, "@UserProfileId", userProfileId);
                    DbUtils.AddParameter(cmd, "@ItemId", itemId);

                    cmd.ExecuteScalar();
                }
            }
        }

        //method to ApproveCheckout (and update "available" status of corresponding item)
        public void ApproveCheckout(Checkout checkout)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Checkout
                        SET CheckoutDate = GETDATE()
                        WHERE Id = @checkoutId;

                        UPDATE Item
                        SET Available = 0
                        WHERE Id = @itemId;";
                    //possible TODO:
                    //modify above command to handle multiple checkout requests
                    //likely:
                    //UPDATE Checkout
                    //SET Declined = 1 
                    //WHERE ItemId = @itemId AND Id != @checkoutId
                    //or leave requests active to all the user to decide upon item return....thus building a queue...

                    DbUtils.AddParameter(cmd, "@checkoutId", checkout.Id);
                    DbUtils.AddParameter(cmd, "@itemId", checkout.ItemId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //method to DeclineCheckout
        public void DeclineCheckout(Checkout checkout)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Checkout
                        SET Declined = 1
                        WHERE Id = @checkoutId;";


                    DbUtils.AddParameter(cmd, "@checkoutId", checkout.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //method to ReturnItem
        public void Checkin(Checkout checkout)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Checkout
                        SET CheckinDate = GETDATE()
                        WHERE Id = @checkoutId;";


                    DbUtils.AddParameter(cmd, "@checkoutId", checkout.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        //method to VerifyReturn (and update "available" status of corresponding item)
        public void VerifyCheckin(Checkout checkout)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Checkout
                        SET ReturnVerifiedDate = GETDATE()
                        WHERE Id = @checkoutId;

                        UPDATE Item
                        SET Available = 1
                        WHERE Id = @itemId;";


                    DbUtils.AddParameter(cmd, "@checkoutId", checkout.Id);
                    DbUtils.AddParameter(cmd, "@itemId", checkout.ItemId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //SELECT method to get checkout requests 
        public List<Request> GetCheckoutRequests(int userProfileId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id,
                                        c.UserProfileId AS BorrowerUserProfileId,
                                        c.ItemId,
                                        i.UserProfileId AS OwnerUserProfileId,
                                        i.Name AS ItemName,
                                        i.ImageLocation AS ItemImageLocation,
                                        i.CategoryId,
                                        cat.Name AS CategoryName,
                                        u.UserName AS BorrowerUserName,
                                        u.ImageLocation AS BorrowerImageLocation,
                                        c.RequestDate
                                        FROM Checkout c
                                        LEFT JOIN UserProfile u ON c.UserProfileId = u.Id
                                        LEFT JOIN Item i ON c.ItemId = i.Id
                                        LEFT JOIN Category cat ON i.CategoryId = cat.Id
                                        WHERE c.CheckoutDate is NULL AND c.Declined = 0 AND i.UserProfileId = userProfileId;";

                    DbUtils.AddParameter(cmd, "@userProfileId", userProfileId);


                    var reader = cmd.ExecuteReader();

                    var requests = new List<Request>();
                    while (reader.Read())
                    {
                        requests.Add(new Request()
                        {
                            CheckoutId = DbUtils.GetInt(reader, "Id"),
                            BorrowerUserProfileId = DbUtils.GetInt(reader, "BorrowerUserProfileId"),
                            ItemId = DbUtils.GetInt(reader, "ItemId"),
                            OwnerUserProfileId = DbUtils.GetInt(reader, "OwnerUserProfileId"),
                            ItemName = DbUtils.GetString(reader, "ItemName"),
                            ItemImageLocation = DbUtils.GetString(reader, "ItemImageLocation"),
                            CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                            CategoryName = DbUtils.GetString(reader, "CategoryName"),
                            BorrowerUserName = DbUtils.GetString(reader, "BorrowerUserName"),
                            BorrowerImageLocation = DbUtils.GetString(reader, "BorrowerImageLocation"),
                            RequestDate = DbUtils.GetDateTime(reader, "RequestDate"),

                        });
                    }

                    reader.Close();

                    return requests;
                }
            }
        }
        //SELECT method to get active checkouts 

    }
}
