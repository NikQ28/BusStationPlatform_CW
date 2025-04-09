using BusStationPlatform.Domains.DTO;
using BusStationPlatform.Domains.Entities;
using BusStationPlatform.Pages;
using BusStationPlatform.Repositories.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System.Runtime.InteropServices;

namespace BusStationPlatform.Services
{
    public class UserAuthentificationService(IRepository _repository) : IUserAuthentificationService
    {
        public async Task<User?> AuthentificationAsync(UserDTO userDTO)
        {
            var user = await _repository.GetUserByEmailAsync(userDTO.Email);
            if (user == null) 
                return null;
            if (user.Password != userDTO.Password)
                return null;
            return user;
        }

        public async Task<User> ChangePasswordAsync(UserDTO userDTO)
        {
            var user = await _repository.GetUserByEmailAsync(userDTO.Email);
            user.Password = userDTO.Password;
            await _repository.UpdateUserAsync(user);
            return user;
        }

        public async Task<User?> RegisterAsync(User newUser)
        {
            if (await IsUserExistsAsync(newUser))
                return null;
            return await _repository.CreateUserAsync(newUser);
        }

        private async Task<bool> IsUserExistsAsync(User newUser)
        {
            var userEmail = await _repository.GetUserByEmailAsync(newUser.Email);
            if (userEmail == null) 
                return false;
            return true;
        }
    }
}
