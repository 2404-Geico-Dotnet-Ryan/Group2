using Microsoft.AspNetCore.Mvc;
using ProjectTwo.DTOs;
using ProjectTwo.Services;


namespace ProjectTwo.Controllers

{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase
    {

        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _usersService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{UserId}")]
        public ActionResult<UserDTO> GetUserById(int UserId)
        {
            var user = _usersService.GetUserById(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    

        [HttpPost]
        public ActionResult<UserDTO> AddUser(UserDTO userDto)
        {
            var user = _usersService.AddUser(userDto);
            if (user == null)
            {
                return BadRequest("Username already exists");
            }
            else
            {
                return Ok();
            }
        }

        [HttpPut("{UserId}")]
        public ActionResult<UserDTO> UpdateUser(int UserId, UserDTO UpdatedUser)
        {
            var user = _usersService.UpdateUser(UserId, UpdatedUser);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            int idReturned = _usersService.DeleteUser(UserId);

            if (idReturned == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("login")]
        public ActionResult<UserDTO> LoginUser(UserLoginDTO userloginDto)
        {
            try
            {
                var user = _usersService.LoginUser(userloginDto);
                return Ok(user);
            }
            catch (Exception e)
            {
                if (e.Message == "Invalid UserName / Password combo. Please try again.")
                {
                    return Forbid(e.Message);
                }
                throw;
            }
        }

    }
}