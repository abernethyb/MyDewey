using Microsoft.Extensions.Configuration;
using MyDewey.Models;
using MyDewey.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDewey.Repositories
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        public UserProfile GetByFirebaseId(string FirebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    //SELECT Id, FirebaseUserId, UserTypeId, Username, FirstName, LastName, ImageLocation, Email, City, Region  FROM UserProfile
                    cmd.CommandText = @"
                        SELECT Id,
                               FirebaseUserId,
                               UserTypeId,
                               UserName,
                               FirstName,
                               LastName,
                               ImageLocation,
                               Email,
                               City,
                               Region
                               FROM UserProfile
                         WHERE FirebaseUserId = @FirebaseUserId;";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", FirebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            FirebaseUserId = DbUtils.GetString(reader, "FirebaseUserId"),
                            UserTypeId = DbUtils.GetInt(reader, "UserTypeId"),
                            UserName = DbUtils.GetString(reader, "UserName"),
                            FirstName = DbUtils.GetString(reader, "FirstName"),
                            LastName = DbUtils.GetString(reader, "LastName"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            Email = DbUtils.GetString(reader, "Email"),
                            City = DbUtils.GetString(reader, "City"),
                            Region = DbUtils.GetString(reader, "Region")

                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }

        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO UserProfile (
                               FirebaseUserId,
                               UserTypeId,
                               UserName,
                               FirstName,
                               LastName,
                               ImageLocation,
                               Email,
                               City,
                               Region
                               )
                               OUTPUT INSERTED.ID
                               VALUES 
                               (
                               @FirebaseUserId,
                               @UserTypeId,
                               @UserName,
                               @FirstName,
                               @LastName,
                               @ImageLocation,
                               @Email,
                               @City,
                               @Region 
                               )";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);
                    DbUtils.AddParameter(cmd, "@UserTypeId", userProfile.UserTypeId);
                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@FirstName", userProfile.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", userProfile.LastName);
                    DbUtils.AddParameter(cmd, "@ImageLocation", userProfile.ImageLocation);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@City", userProfile.City);
                    DbUtils.AddParameter(cmd, "@Region", userProfile.Region);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
