namespace TwitterCloneAPI.Models.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Likes { get; set; }

        public int UserId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
