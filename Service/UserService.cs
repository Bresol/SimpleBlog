using SimpleBlog.Models;
using SimpleBlog.Repositories;

namespace SimpleBlog.Service
{
    public class UserService: IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = (await _userRepository.GetAllAsync()).FirstOrDefault(u => u.Username == userName);
            if (user == null)
                return null;

            return user;
        }
    }
}
