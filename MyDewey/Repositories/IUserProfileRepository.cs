using MyDewey.Models;

namespace MyDewey.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByFirebaseId(string FirebaseUserId);
    }
}