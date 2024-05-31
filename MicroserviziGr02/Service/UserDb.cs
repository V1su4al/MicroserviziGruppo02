using MicroserviziGr02.Model;
using Npgsql;
using Dapper;


namespace MicroserviziGr02.Service
{
    
    public class UserDb
    {
        public readonly string _connectionString = "Server=127.0.0.1;Port=5432;Database=EsercizioMicroservizi;User Id=gruppo2;Password=1234";


        public void CreateUser( User user)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            int bitValue = user.IsAdmin ? 1 : 0;
         

            string query = """
                INSERT INTO Users
                (
                  
                  Username,
                  Email,
                  PasswordHash,
                  IsAdmin                    
                  )                
                   VALUES
                (                  
                  @Username,
                  @Email,
                  @PasswordHash,
                  @IsAdmin                  
                )
                """;
            connection.Execute(query, user);
        }

        public IEnumerable<Post> GetUserPost(int UserId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = """
                select * from Post where UserId=@Id
                """;

            return connection.Query<Post>(query, new {Id=UserId});
        }

        public void Following(Follow follow)
        {
            using var connection = new NpgsqlConnection(_connectionString);
               string query = """
                INSERT INTO Follows
                (
                  Follower,
                  Followed
                                    
                  )                
                   VALUES
                (                  
                  @Follower,
                  @Followed
                )
                """;
            connection.Execute(query, follow);
        }
        public IEnumerable<Post> GetUserLikedPost(int UserId)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            string query = """
                
                """;

            return connection.Query<Post>(query, new { Id = UserId });
        }
    }
}
