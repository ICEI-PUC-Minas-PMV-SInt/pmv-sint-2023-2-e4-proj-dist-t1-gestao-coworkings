using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;
using ItCollabora.Data;
using ItCollabora.Repository;

namespace ItCollabora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
       
        private readonly IRentRepository _rentRepository;

        public RentController(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                Rent model = await _rentRepository.GetRentById(id);

                if (model == null)
                {
                    return NotFound();
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Rent rent)
        {
            if (rent.StartDate > rent.EndDate || rent.EndDate < rent.StartDate)
            {
                return BadRequest(new { message = "A data inicio do aluguel não pode ser maior que a de fim!" });
            }

            Rent createdRent = await _rentRepository.CreateRent(rent);
            return Ok(rent);
        }

    }

}