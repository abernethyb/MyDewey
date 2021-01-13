using MyDewey.Models;

namespace MyDewey.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseId(string FirebaseUserId);
    }
}