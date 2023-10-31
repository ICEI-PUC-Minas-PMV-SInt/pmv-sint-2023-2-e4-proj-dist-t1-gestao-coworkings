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
    public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserModel user)
    {
        UserModel createdUser = await _userRepository.CreateOne(user);
        return Ok(createdUser);
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

                if (!string.IsNullOrEmpty(updatedUser.Name))
                {
                    existingUser.Name = updatedUser.Name;
                }

                if (!string.IsNullOrEmpty(updatedUser.Email))
                {
                    existingUser.Email = updatedUser.Email;
                }

                if (!string.IsNullOrEmpty(updatedUser.EncryptedPassword))
                {
                    existingUser.EncryptedPassword = updatedUser.EncryptedPassword;
                }

                await _userRepository.Modify(existingUser, userId);

                return Ok(existingUser);
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
