namespace MicroserviziGr02.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    
    }

    public class Follow
    {
        public int Follower { get; set; }
        public int Followed { get; set; }
    }
}
