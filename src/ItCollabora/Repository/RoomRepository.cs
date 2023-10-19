using ItCollabora.Data;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItCollabora.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDBContext _dbContext;
        public RoomRepository(AppDBContext AppDBContext) {

            _dbContext = AppDBContext;
        }

        public async Task<List<RoomModel>> GetAll()
        {
            return await _dbContext.Room.ToListAsync();
            
        }

        public async Task<RoomModel> GetOne(Guid RoomId)
        {
            return await _dbContext.Room.FirstOrDefaultAsync(u => u.RoomId == RoomId);
        }

        public async Task<RoomModel> CreateOne(RoomModel room)
        {
            await _dbContext.Room.AddAsync(room);
            await _dbContext.SaveChangesAsync();

            return room;
        }

        public async Task<RoomModel> Modify(RoomModel updatedRoom, Guid RoomId)
        {
            RoomModel room = await GetOne(RoomId);
            if (room == null)
            {
                throw new Exception($"Sala com o Id {RoomId} não foi encontrado");
            }

            room.Name = updatedRoom.Name;
            room.Description = updatedRoom.Description;
            room.Price = updatedRoom.Price;
            room.TotalCapacity = updatedRoom.TotalCapacity;
            room.OwnerUserId = updatedRoom.OwnerUserId;

            await _dbContext.SaveChangesAsync();

            return updatedRoom;
        }

        public async Task DeleteOne(Guid RoomId)
        {
            RoomModel room = await GetOne(RoomId);
            if (room == null)
            {
                throw new Exception($"Salas com o Id {RoomId} não foi encontrado");
            } 

            _dbContext.Room.Remove(room);
            await _dbContext.SaveChangesAsync();
        }
    }
}
