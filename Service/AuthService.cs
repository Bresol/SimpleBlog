using Org.BouncyCastle.Crypto.Generators;
using SimpleBlog.Models;
using SimpleBlog.Repositories;

namespace SimpleBlog.Service
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(string username, string password)
        {
            //var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var passwordHash = password;
            var user = new User { Username = username, Password = passwordHash };
            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = (await _userRepository.GetAllAsync()).FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
                return null;

            return user;
        }
    }
}
