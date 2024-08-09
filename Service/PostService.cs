using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Models;
using SimpleBlog.Payloads;
using SimpleBlog.Repositories;

namespace SimpleBlog.Service
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public PostService(IRepository<Post> postRepository, IHubContext<NotificationHub> hubContext)
        {
            _postRepository = postRepository;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<Post> CreatePostAsync(CreatePostResquest createPost, User user)
        {
            Post obPost = new Post { Title = createPost.Title, Content = createPost.Content, UserId = user.Id, User = user, CreatedAt = DateTime.Now };
            Post post = await this.CreatePostAsync(obPost);

            return post;
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", "Nova postagem criada: " + post.Title);
            return post;
        }

        public async Task UpdatePostAsync(int id, UpdatePostRequest updatePost)
        {
            Post objPost = await this.GetPostByIdAsync(id);
            objPost.Title = updatePost.Title;
            objPost.Content = updatePost.Content;
            
            Post post = objPost;

            await _postRepository.UpdateAsync(post);
        }
        public async Task UpdatePostAsync(Post post)
        {
            await _postRepository.UpdateAsync(post);
        }

        public async Task DeletePostAsync(int id)
        {
            await _postRepository.DeleteAsync(id);
        }
    }
}
