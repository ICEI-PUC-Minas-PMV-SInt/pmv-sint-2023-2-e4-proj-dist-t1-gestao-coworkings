using ItCollabora.Data;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ItCollabora.Repository
{
    public class RentRepository : IRentRepository
    {
        private readonly AppDBContext _dbContext;

        public RentRepository(AppDBContext AppDBContext)
        {

            _dbContext = AppDBContext;
        }

        public async Task<List<Rent>> GetAllRent()
        {
            return await _dbContext.Rents.ToListAsync();

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

        public async Task<Rent> UpdateRent(Guid idRent, Rent rentUpdate)
        {
            Rent rent = await GetRentById(idRent);
            if (rent == null)
            {
                throw new Exception($"N�o encontramos reserva para o {idRent}");
            }

            rent.StartDate = rentUpdate.StartDate;
            rent.EndDate = rentUpdate.EndDate;

     
            await _dbContext.SaveChangesAsync();

            return rentUpdate;
        }

        public async Task DeleteRent(Guid idRent)
        {
            Rent getRent = await GetRentById(idRent);
            if (getRent == null)
            {
                throw new Exception($"A reserva de n�mero {idRent} n�o foi encontrada");
            }

            _dbContext.Rents.Remove(getRent);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}