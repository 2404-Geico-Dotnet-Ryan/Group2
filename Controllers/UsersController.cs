using Microsoft.AspNetCore.Mvc;
using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Controllers

{
    [ApiController]
    [Route("[controller]")]

    public class UsersController : ControllerBase

    //     public User? AddUser(User u);
    //     public User? GetUser(int id);
    //     public List<User>? GetAllUsers();
    //     public User? UpdateUser(User u);
    //     public User? DeleteUser(int id);
    //     public void Save();
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUser()
        {
            var users = _context.Users
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                }).ToList();

            return users;
        }

        [HttpGet("{UserId}")]
        public ActionResult<UserDTO> GetUserById(int UserId)
        {
            var user = _context.Users.Find(UserId);
            var userDto = new UserDTO
            {
                UserName = user.UserName,
                UserId = user.UserId,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
            return userDto;
        }

        [HttpPost]
        public ActionResult<UserDTO> AddUser(UserDTO userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(userDto);
            //return CreatedAtAction(nameof(GetUserById), new { User = user.UserId }, userDto);
        }

        [HttpPut("{UserId}")]
        public ActionResult<UserDTO> UpdateUser(int UserId, UserDTO UpdatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);

            user.UserName = UpdatedUser.UserName;
            user.Password = UpdatedUser.Password;
            user.FirstName = UpdatedUser.FirstName;
            user.LastName = UpdatedUser.LastName;

            _context.Users.Update(user);
            _context.SaveChanges();

            return Ok(UpdatedUser);
        }

        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }
    }
}