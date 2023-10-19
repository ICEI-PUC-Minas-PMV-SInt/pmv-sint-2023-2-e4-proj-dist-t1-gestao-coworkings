using ItCollabora.Models;

namespace ItCollabora.Repository.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<RoomModel>> GetAll();
        Task<RoomModel> GetOne(Guid RoomId);
        Task DeleteOne(Guid RoomId);
        Task<RoomModel> CreateOne(RoomModel room);
        Task<RoomModel> Modify(RoomModel updatedRoom, Guid RoomId);
    }
}
