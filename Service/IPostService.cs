using SimpleBlog.Models;
using SimpleBlog.Payloads;

namespace SimpleBlog.Service
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> CreatePostAsync(CreatePostResquest createpost, User user);
        Task UpdatePostAsync(Post post);
        Task UpdatePostAsync(int id, UpdatePostRequest updatePost);
        Task DeletePostAsync(int id);
    }
}
