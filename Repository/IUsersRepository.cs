using EchoPOS.Models;

namespace EchoPOS.Repository
{
    public interface IUsersRepository
    {
        int AddUser(Users user);
        Users GetUserById(int userId);
        IEnumerable<Users> GetAllUsers();
        void UpdateUser(Users user);
        void DeleteUser(int userId);
    }
}
