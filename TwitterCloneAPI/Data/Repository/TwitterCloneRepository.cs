using Microsoft.EntityFrameworkCore;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Models.DTO;
using TwitterCloneAPI.Repository;

namespace TwitterCloneAPI.Data
{
    public class TwitterCloneRepository : IRepository
    {
        private readonly TwitterCloneDbContext _dbContext;
        public TwitterCloneRepository()
        {
            _dbContext = new TwitterCloneDbContext();
        }
        public async Task CreateCommentAsync(Comment comment)
        {
            using (var db = _dbContext)
            {
                await db.Comments.AddAsync(comment);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateTweetAsync(Tweet tweet)
        {
            using (var db = _dbContext)
            {
                await db.Tweets.AddAsync(tweet);
                await db.SaveChangesAsync();
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using (var db = _dbContext)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            Comment commentToDelete;

            using (var db = _dbContext)
            {
                commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);
                if (commentToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Comments.Remove(commentToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteTweetAsync(int id)
        {
            Tweet tweetToDelete;

            using (var db = _dbContext)
            {
                tweetToDelete = db.Tweets.FirstOrDefault(t => t.Id == id);
                if (tweetToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Tweets.Remove(tweetToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User userToDelete;

            using (var db = _dbContext)
            {
                userToDelete = db.Users.FirstOrDefault(u => u.Id == id);
                if (userToDelete == null)
                {
                    return false;
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
        }

        public async Task<List<CommentDTO>> GetAllCommentsAsync()
        {
            List<Comment> comments;

            using (var db = _dbContext) 
            {
                comments = await db.Comments.ToListAsync();
            }
            List<CommentDTO> commentToReturn = new List<CommentDTO>();

            foreach (Comment com in comments)
            {
                CommentDTO comToAdd = new CommentDTO();
                comToAdd.Id = com.Id;
                comToAdd.Content = com.Content;
                comToAdd.Likes = com.Likes;
                comToAdd.UserId = com.UserId;
                comToAdd.Timestamp = com.Timestamp;

                commentToReturn.Add(comToAdd);
            }
            return commentToReturn;
        }
        
        public async Task<List<TweetDTO>> GetAllTweetsAsync()
        {
            List<Tweet> tweets;

            using (var db = _dbContext)
            {
                tweets = await db.Tweets.Include(t => t.Comments).ToListAsync();
            }
            List<TweetDTO> tweetToReturn = new List<TweetDTO>();

            foreach (Tweet twe in tweets)
            {
                TweetDTO tweToAdd = new TweetDTO();
                tweToAdd.Id = twe.Id;
                tweToAdd.TweetContent = twe.TweetContent;
                tweToAdd.Likes = twe.Likes;
                tweToAdd.Retweets = twe.Retweets;
                tweToAdd.Timestamp = twe.Timestamp;
                tweetToReturn.Add(tweToAdd);
            }
            return tweetToReturn;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            List<User> users;

            using (var db = _dbContext)
            {
                users = await db.Users.Include(u => u.Tweets).ToListAsync();
            }
            List<UserDTO> userToReturn = new List<UserDTO>();

            foreach (User us in users)
            {
                UserDTO usToAdd = new UserDTO();
                usToAdd.Id = us.Id;
                usToAdd.userName = us.userName;
                usToAdd.handle = us.handle;
                usToAdd.profileImgUrl = us.profileImgUrl;
                usToAdd.Tweets = us.Tweets;

                userToReturn.Add(usToAdd);
            }
            return userToReturn;
        }

        public async Task<CommentDTO> GetCommentByIdAsync(int id)
        {
            using (var db = _dbContext)
            {
                Comment c = await db.Comments.FirstOrDefaultAsync(x => x.Id == id);

            }
            CommentDTO commentToReturn = new CommentDTO();

            return commentToReturn;
        }

        public async Task<TweetDTO> GetTweetByIdAsync(int id)
        {
            Tweet t;
           
            using (var db = _dbContext)
            {
                 t = await db.Tweets.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
            }
            TweetDTO tweetToReturn = new TweetDTO();

            List<CommentDTO> commentDTOs = new List<CommentDTO>();

            foreach (Comment c in t.Comments)
            {
                CommentDTO dto = new CommentDTO();
                dto.Id = c.Id;
                dto.Content = c.Content;
                dto.Likes = c.Likes;
                dto.UserId = c.UserId;
                commentDTOs.Add(dto);
            }

            tweetToReturn.Id = t.Id;
            tweetToReturn.TweetContent = t.TweetContent;
            tweetToReturn.Likes = t.Likes;
            tweetToReturn.Retweets = t.Retweets;
            tweetToReturn.Comments = t.Comments;
            tweetToReturn.Timestamp = t.Timestamp;
            return tweetToReturn;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            User u;

            using (var db = _dbContext)
            {
                u = await db.Users.Include(c => c.Tweets).FirstOrDefaultAsync(x => x.Id == id);
            }
            UserDTO userToReturn = new UserDTO();

            List<TweetDTO> tweetDTOs = new List<TweetDTO>();

            foreach (Tweet t in u.Tweets)
            {
                TweetDTO dto = new TweetDTO();
                dto.Id = t.Id;
                dto.TweetContent = t.TweetContent;
                dto.Likes = t.Likes;
                dto.Retweets = t.Retweets;
                tweetDTOs.Add(dto);
            }

            userToReturn.Id = u.Id;
            userToReturn.Tweets = u.Tweets;
            userToReturn.userName = u.userName;
            userToReturn.handle = u.handle;
            userToReturn.profileImgUrl = u.profileImgUrl;

            return userToReturn;
        }

        public async Task<Comment> UpdateCommentAsync(int id, Comment comment)
        {
            Comment commentToUpdate;

            using (var db = _dbContext)
            {
                commentToUpdate = await db.Comments.FirstOrDefaultAsync(x => x.Id == id);

                if (commentToUpdate == null)
                {
                    return null;
                }

                commentToUpdate.Id = comment.Id;
                commentToUpdate.Content = comment.Content;
                commentToUpdate.Likes = comment.Likes;
                commentToUpdate.UserId = comment.UserId;

                await db.SaveChangesAsync();

                return commentToUpdate;
            }
        }

        public async Task<Tweet> UpdateTweetAsync(int id, Tweet tweet)
        {
            Tweet tweetToUpdate;

            using (var db = _dbContext)
            {
                tweetToUpdate = await db.Tweets.FirstOrDefaultAsync(x => x.Id == id);

                if (tweetToUpdate == null)
                {
                    return null;
                }

                tweetToUpdate.Id = tweet.Id;
                tweetToUpdate.TweetContent = tweet.TweetContent;
                tweetToUpdate.Likes = tweet.Likes;
                tweetToUpdate.Retweets = tweet.Retweets;

                await db.SaveChangesAsync();

                return tweetToUpdate;
            }
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            User userToUpdate;

            using (var db = _dbContext)
            {
                userToUpdate = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (userToUpdate == null)
                {
                    return null;
                }

                userToUpdate.Id = user.Id;
                userToUpdate.userName = user.userName;
                userToUpdate.handle = user.handle;
                userToUpdate.profileImgUrl = user.profileImgUrl;
                userToUpdate.Tweets = user.Tweets; 

                await db.SaveChangesAsync();

                return userToUpdate;
            }
        }
    }
}