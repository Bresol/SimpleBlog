using SimpleBlog.Models;

namespace SimpleBlog.Payloads
{
    public class UpdatePostRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
