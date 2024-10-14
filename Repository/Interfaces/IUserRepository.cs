using Crud_Web_Api.Models;

namespace Crud_Web_Api.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> CreateUser(UserModel user);
        Task<UserModel> GetUserById(int id);
        Task<UserModel> UpdateUser(UserModel user);
        Task<UserModel> DeleteUser(int id);
        Task<List<UserModel>> GetAllUsers();
    }
}
