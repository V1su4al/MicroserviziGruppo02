namespace MicroserviziGr02.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime Createdat { get; set; }
        public int UserId { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
