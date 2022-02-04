using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Repository
{
    public interface IRepository
    {
        //Users
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);

        //Comments
        Task<List<CommentDTO>> GetAllCommentsAsync();
        Task<CommentDTO> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(Comment comment);
        Task<Comment> UpdateCommentAsync(int id, Comment comment);
        Task<bool> DeleteCommentAsync(int id);

        //Tweets
        Task<List<TweetDTO>> GetAllTweetsAsync();
        Task<TweetDTO> GetTweetByIdAsync(int id);
        Task CreateTweetAsync(Tweet tweet);
        Task<Tweet> UpdateTweetAsync(int id, Tweet tweet);
        Task<bool> DeleteTweetAsync(int id);
    }
}
