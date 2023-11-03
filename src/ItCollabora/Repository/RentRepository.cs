using ItCollabora.Data;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItCollabora.Repository
{
    public class RentRepository : IRentRepository
    {
        private readonly AppDBContext _dbContext;

        public RentRepository(AppDBContext AppDBContext)
        {

            _dbContext = AppDBContext;
        }

        public async Task<Rent> GetRentById(Guid id)
        {
            return await _dbContext.Rents.FirstOrDefaultAsync(r => r.IdRent == id);
      
        }

        public async Task<Rent> CreateRent(Rent rent)
        {

            await _dbContext.Rents.AddAsync(rent);
            await _dbContext.SaveChangesAsync();

            return rent;
        }

    }
}