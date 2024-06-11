using ProjectTwo.DTOs;

namespace ProjectTwo.Services
{
    public interface IUsersService
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUserById(int UserId);
        UserDTO AddUser(UserDTO userDTO);
        UserDTO UpdateUser(int UserId, UserDTO userDTO);
        int DeleteUser(int UserId);

        UserDTO LoginUser(UserLoginDTO userLogin);
    }
}