using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPI.Models
{
    public class User
    {
        public User()
        {
            Tweets = new List<Tweet>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string  userName { get; set; }
        [Required]
        [MaxLength(255)]
        public string handle { get; set; }
        [Required]
        public string profileImgUrl { get; set; }
        public List<Tweet> Tweets { get; set; }

    }
}
