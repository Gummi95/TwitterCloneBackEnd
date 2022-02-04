using System.ComponentModel.DataAnnotations;

namespace TwitterCloneAPI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(280)]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int UserId { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
