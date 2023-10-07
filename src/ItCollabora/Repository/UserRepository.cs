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

        public async Task<UserModel> GetOne(Guid userId)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<UserModel> CreateOne(UserModel user)
        {
            user.UserId = Guid.NewGuid();
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> Modify(UserModel updatedUser, Guid userId)
        {
            UserModel user = await GetOne(userId);
            if (user == null)
            {
                throw new Exception($"Usuário com o Id {userId} não foi encontrado");
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.EncryptedPassword = updatedUser.EncryptedPassword;
            user.RentedRooms = updatedUser.RentedRooms;
            user.OwnedRooms = updatedUser.OwnedRooms;

            await _dbContext.SaveChangesAsync();

            return updatedUser;
        }

        public async Task DeleteOne(Guid userId)
        {
            UserModel user = await GetOne(userId);
            if (user == null)
            {
                throw new Exception($"Usuário com o Id {userId} não foi encontrado");
            } 

            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
