using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;

namespace ItCollabora.Controllers {

    [Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository) {
        _userRepository = userRepository;
    }



    [HttpGet("{userId}")]
    public async Task<ActionResult<UserModel>> GetOne(Guid userId)
    {
        try
        {
            UserModel user = await _userRepository.GetOne(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> CreateUser(UserModel user)
    {
        try
        {
            UserModel createdUser = await _userRepository.CreateOne(user);
            return CreatedAtAction(nameof(GetOne), new { userId = createdUser.UserId }, createdUser);
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser(Guid userId, UserModel updatedUser)
    {
        try
        {
            UserModel existingUser = await _userRepository.GetOne(userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            updatedUser.UserId = userId;
            UserModel modifiedUser = await _userRepository.Modify(updatedUser, userId);

            return Ok(modifiedUser);
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        try
        {
            UserModel existingUser = await _userRepository.GetOne(userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteOne(userId);

            return NoContent();
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }

    }
}
}
