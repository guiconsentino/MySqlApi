using MysqlApi.Model;

namespace MysqlApi.Repository
{
    public interface IUserRepository
    {

        IEnumerable<User> GetAll();
        int InsertUser(User newUser);
        int DeleteUser(int Id);

    }

}

