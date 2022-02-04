namespace TwitterCloneAPI.Models.DTO
{
    public class UserDTO
    {
        public UserDTO()
        {
            Tweets = new List<Tweet>();
        }

        public int Id { get; set; }

        public string userName { get; set; }
        public string handle { get; set; }
        public string profileImgUrl { get; set; }
        public List<Tweet> Tweets { get; set; }
    }
}
