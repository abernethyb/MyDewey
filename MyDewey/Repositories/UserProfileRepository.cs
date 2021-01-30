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
                    //SELECT Id, FirebaseUserId, UserTypeId, Username, FirstName, LastName, ImageLocation, Email, PostalCode  FROM UserProfile
                    cmd.CommandText = @"
                        SELECT Id,
                               FirebaseUserId,
                               UserTypeId,
                               UserName,
                               FirstName,
                               LastName,
                               ImageLocation,
                               Email,
                               PostalCode
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
                            PostalCode = DbUtils.GetString(reader, "PostalCode")

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
                               PostalCode
                               )
                               OUTPUT INSERTED.ID
                               VALUES 
                               (
                               @FirebaseUserId,
                               2,
                               @UserName,
                               @FirstName,
                               @LastName,
                               @ImageLocation,
                               @Email,
                               @PostalCode
                               )";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);
                    //DbUtils.AddParameter(cmd, "@UserTypeId", userProfile.UserTypeId);
                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@FirstName", userProfile.FirstName);
                    DbUtils.AddParameter(cmd, "@LastName", userProfile.LastName);
                    DbUtils.AddParameter(cmd, "@ImageLocation", userProfile.ImageLocation);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@PostalCode", userProfile.PostalCode);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
