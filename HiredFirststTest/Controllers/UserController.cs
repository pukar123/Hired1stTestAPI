using HiredFirst.Domain.DTO;
using HiredFirst.Domain.Services;
using HiredFirstst.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HiredFirststTest.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userData=_userService.GetAllUsers();
            return Ok(new { result = userData });
        }
        [HttpPut]
        [Route("updateUser")]
        public IActionResult UpdateUser([FromBody] UserDTO request)
        {
            try
            {
                _userService.UpdateUser(request);
                return Ok(new { message = "User updated sucessfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUser(string request)
        {
            try
            {
                _userService.DeleteUser(request);
                return Ok(new { message = "User deleted sucessfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
