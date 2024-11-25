﻿using MCFWebApi.Models;
using MCFWebApi.Repositories;

namespace MCFWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository) 
        { 
            _repository = repository;
        }
        public async Task<User> ProcessLoginUser(string userName, string password)
        {
            var users = await _repository.FindAsync(u => u.UserName.Equals(userName) && u.Password.Equals(password));

            var user = users.SingleOrDefault();

            return user;
        }
    }
}
