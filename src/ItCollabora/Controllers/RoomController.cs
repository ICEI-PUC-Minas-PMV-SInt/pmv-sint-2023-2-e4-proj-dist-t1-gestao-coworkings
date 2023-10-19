using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItCollabora.Models;
using ItCollabora.Repository.Interfaces;

namespace ItCollabora.Controllers {

    [Route("api/[controller]")]
    [ApiController]
public class RoomController : ControllerBase
{

    private readonly IRoomRepository _roomRepository;

    public RoomController(IRoomRepository roomRepository) {
           _roomRepository = roomRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomModel>>> GetAll()
    {
        List<RoomModel> room = await _roomRepository.GetAll();
        return Ok(room);
    }

     [HttpGet("{RoomId}")]
    public async Task<ActionResult<RoomModel>> GetOne(Guid roomId)
    {
        try
        {
            RoomModel room = await _roomRepository.GetOne(roomId);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }   

    [HttpPost]
    public async Task<ActionResult<RoomModel>> CreateRoom([FromBody] RoomModel room)
    {
        RoomModel createdRoom = await _roomRepository.CreateOne(room);
        return Ok(createdRoom);
    }

    [HttpPut("{RoomId}")]
    public async Task<IActionResult> UpdateRoom(Guid roomId, RoomModel updatedRoom)
    {
        try
        {
            updatedRoom.RoomId = roomId;
            RoomModel modifiedRoom = await _roomRepository.Modify(updatedRoom, roomId);

            return Ok(modifiedRoom);
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }
    }

    [HttpDelete("{RoomId}")]
    public async Task<IActionResult> DeleteRoom(Guid RoomId)
    {
        try
        {
            RoomModel existingRoom = await _roomRepository.GetOne(RoomId);

            if (existingRoom == null)
            {
                return NotFound();
            }

            await _roomRepository.DeleteOne(RoomId);

            return NoContent();
        } catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro interno do servidor: {ex.Message}");
        }

    }
}
}
