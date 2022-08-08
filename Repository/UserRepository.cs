using Dapper;
using MySql.Data.MySqlClient;
using MysqlApi.Model;

namespace MysqlApi.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            var sql = "SELECT * FROM user";
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<User>(sql);
                //usando dapper        
            }

        }

        public int InsertUser(User newUser)
        {
            var sql = "INSERT INTO USER VALUES(@Id, @Name, @Age)";

            User user = new User()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Age = newUser.Age,
            };

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Execute(sql, user);
            }

        }

        public int DeleteUser(int id)
        {
            var sql = "DELETE FROM USER WHERE id = @Id";

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {

                return connection.Execute(sql, new { id });
            };

        }
    }
}

