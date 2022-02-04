namespace TwitterCloneAPI.Models.DTO
{
    public class TweetDTO
    {
        public TweetDTO()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        
        public string TweetContent { get; set; }

        public int Likes { get; set; }

        public int Retweets { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;


        public List<Comment> Comments { get; set; }
    }
}
