using ItCollabora.Models;

namespace ItCollabora.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetOne(Guid userId);
        Task DeleteOne(Guid userId);
        Task<UserModel> CreateOne(UserModel user);
        Task<UserModel> Modify(UserModel updatedUser, Guid userId);
    }
}
