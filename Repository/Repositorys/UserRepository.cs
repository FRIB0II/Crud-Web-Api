using Crud_Web_Api.Data;
using Crud_Web_Api.Models;
using Crud_Web_Api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crud_Web_Api.Repository.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContextdb _myContextdb;

        public UserRepository(MyContextdb myContextdb)
        {
            _myContextdb = myContextdb;
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            await _myContextdb.Users.AddAsync(user);
            await _myContextdb.SaveChangesAsync();
            return user;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _myContextdb.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            UserModel userSearched = await GetUserById(user.Id);

            userSearched.UserName = user.UserName;
            userSearched.UserLastName = user.UserLastName;
            userSearched.UserPassword = user.UserPassword;
            userSearched.UserPassword = user.UserPassword;

            await _myContextdb.SaveChangesAsync();
            return userSearched;
        }

        public async Task<UserModel> DeleteUser(int id)
        {
            UserModel user = await GetUserById(id);

            if (user == null)
            {
                return user;
            }
            else
            {
                _myContextdb.Users.Remove(user);
                await _myContextdb.SaveChangesAsync();
                return user;
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = await _myContextdb.Users.ToListAsync();
            return users;
        }
    }
}
