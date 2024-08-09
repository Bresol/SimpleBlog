﻿using SimpleBlog.Models;

namespace SimpleBlog.Service
{
    public interface IAuthService
    {
        Task<User> Register(string username, string password);
        Task<User> Login(string username, string password);
    }
}
