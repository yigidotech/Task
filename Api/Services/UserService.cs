using Api.Services;
using Api.Entities;
using Api.Contexts;
using Api.Repositories;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Services
{
    public class UserService
    {
         private UserRepository userRepository;
        public UserService(TaskContext taskContext, IConfiguration configuration)
        {
            this.userRepository = new UserRepository(taskContext,configuration);
        }
        public async System.Threading.Tasks.Task<User> SignIn(User user)
        {
            return await this.userRepository.CreateUser(user);
        }

        internal async System.Threading.Tasks.Task<LoginResponse> Login(string username, string password)
        {
            return await this.userRepository.Login(username, password);
        }

    }
}