using ItCollabora.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItCollabora.Repository.Interfaces
{
    public interface IRentRepository
    {
        Task<List<Rent>> GetAllRent();
        Task<Rent> GetRentById(Guid id);
        Task<Rent> CreateRent(Rent model);
        Task<Rent> UpdateRent(Guid id, Rent model);
        Task DeleteRent(Guid idRent);
    }
}
