using ProjectTwo.Data;
using ProjectTwo.DTOs;
using ProjectTwo.Models;

namespace ProjectTwo.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public UserDTO AddUser(UserDTO userDTO)
        {
            var user = new User
            {
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return userDTO;
        }

        public void DeleteUser(int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public UserDTO GetUserById(int UserId)
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

        public IEnumerable<UserDTO> GetUsers()
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

        public UserDTO LoginUser(UserLoginDTO userLogin)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userLogin.UserName && u.Password == userLogin.Password);
            if (user == null)
            {
                return null; // Indicate failure to find the user
            }

            // Convert the User entity to a UserDTO
            var userDto = ConvertUserToUserDTO(user);

            return userDto;
        }

        // Method to convert a User entity to a UserDTO
        private UserDTO ConvertUserToUserDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,

            };
        }



        public UserDTO UpdateUser(int UserId, UserDTO userDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);

            user.UserName = userDTO.UserName;
            user.Password = userDTO.Password;
            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;

            _context.Users.Update(user);
            _context.SaveChanges();

            return userDTO;
        }
    }
}
