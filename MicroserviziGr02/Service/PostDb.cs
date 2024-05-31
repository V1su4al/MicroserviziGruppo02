using Dapper;
using MicroserviziGr02.Model;
using Npgsql;

namespace MicroserviziGr02.Service
{
    public class PostDb
    {
        public readonly string _connectionString = "Server=127.0.0.1;Port=5432;Database=EsercizioMicroservizi;User Id=gruppo2;Password=1234";

        public void CreatePost(Post post)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query= """                               
                INSERT INTO Post (Url, CreatedAt, UserId)
                VALUES (@Url, @CreatedAt, @UserId);                
                """;
            post.Createdat=DateTime.Now;
            connection.Execute(query,post);
        }

        public IEnumerable<Post> GetListAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            const string query = """
                SELECT Id, Url, CreatedAt, UserId
                FROM Post
                ORDER BY CreatedAt
                """;
            return connection.Query<Post>(query);
        }

        public void LikesPost(Likes likes)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = """                               
                INSERT INTO Likes (UserId, PostId)
                VALUES (@UserId, @PostId);                
                """;            
            connection.Execute(query, likes);
        }

        public void InsertCategory(string CategoryName)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = """                               
                INSERT INTO Category (CategoryName)
                VALUES (@CategoryName);                
                """;
            connection.Execute(query, CategoryName);
        }

    }
}
