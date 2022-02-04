using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterCloneAPI.Models
{
    public class Tweet
    {
        public Tweet()
        {
            Comments = new List<Comment>();
        }   

        public int Id { get; set; }

        [Required]
        [MaxLength(280)]
        public string TweetContent { get; set; }

        public int Likes { get; set; }

        public int Retweets { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        
        [MaxLength(280)]
        public List<Comment> Comments { get; set; }
    }
}
