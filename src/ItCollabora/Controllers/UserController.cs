using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ItCollabora.Models;

namespace ItCollabora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModel>> GetAllUser()
        {
            return Ok();
        }
    }
}
