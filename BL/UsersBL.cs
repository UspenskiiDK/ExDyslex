using DAL;
using DAL.DbModels;
using Entities;
using User = Entities.User;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class UsersBL
    {
        public async Task CreateClient(User user)
        {
            await new UsersDAL().CreateUser(user);
        }

        public async Task UpdateClient(User user)
        {
            await new UsersDAL().UpdateUser(user);
        }

        public async Task DeleteClient(User user)
        {
            await new UsersDAL().DeleteUser(user);
        }
    }
}
