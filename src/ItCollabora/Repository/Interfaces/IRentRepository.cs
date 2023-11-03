using ItCollabora.Models;
using Microsoft.AspNetCore.Mvc;

namespace ItCollabora.Repository.Interfaces
{
    public interface IRentRepository
    {
        
        Task<Rent> GetRentById(Guid id);
        Task<Rent> CreateRent(Rent model);
    }
}
