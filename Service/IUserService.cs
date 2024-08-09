using SimpleBlog.Models;

namespace SimpleBlog.Service
{
    public interface IUserService
    {
        Task<User> GetUserByUserName(string userName);
    }
}
