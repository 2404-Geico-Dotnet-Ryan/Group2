using Microsoft.AspNetCore.Mvc;
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
            // Convert the UserDTO to a User entity
            var checkUser = GetUserByUserName(userDTO.UserName);

            if (checkUser == null)
            {
                var user = ConvertUserDTOToUser(userDTO);
                _context.Users.Add(user);
                _context.SaveChanges();

                // Return the original UserDTO
                return userDTO;
            }
            else
            {
                return null;
            }
        }

        public int DeleteUser(int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
            {
                return -1;
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return UserId;
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
        private User ConvertUserDTOToUser(UserDTO userDto)
        {
            return new User
            {
                UserId = userDto.UserId,
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
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

        public ActionResult<UserDTO> GetUserByUserName(string userName)
        {
            // Find the user by username
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {
                return null; // Indicate failure to find the user
            }

            // Convert the User entity to a UserDTO
            var userDto = ConvertUserToUserDTO(user);

            return userDto;
        }

       
    }
}
