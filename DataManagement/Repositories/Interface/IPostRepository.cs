using DataManagement.Models;

namespace DataManagement.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync(int? userd, string title);
        Task<Post> GetPostByIdAsync(int id);
        Task<bool> DeletePostByIdAsync(int id);
    }
}
