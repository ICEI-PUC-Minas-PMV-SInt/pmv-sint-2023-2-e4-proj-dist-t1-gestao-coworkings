using ItCollabora.Data;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItCollabora.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemOfUserDBContext _dbContext;
        public UserRepository(SystemOfUserDBContext systemOfUserDBContext) {

            _dbContext = systemOfUserDBContext;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> GetOne(Guid userId, SystemOfUserDBContext _dbContext)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public Task<UserModel> CreateOne(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOne(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Modify(UserModel updatedUser, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
