using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using User = Entities.User;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class UsersDAL
    {
        private readonly ApplicationContext _context;

        public UsersDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public UsersDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            var dbUser = ConvertToDbModel(user);

            if (dbUser != null)
            {
                await _context.Users.AddAsync(dbUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User user)
        {
            var dbUser = ConvertToDbModel(user);

            if (dbUser != null)
            {
                _context.Users.Update(dbUser);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(User user)
        {
            var dbUser = ConvertToDbModel(user);

            if (dbUser != null)
            {
                _context.Users.Remove(dbUser);
                await _context.SaveChangesAsync();
            }
        }

        private DbModels.User? ConvertToDbModel(User? entityUser)
        {
            return entityUser == null ? null :
                new DbModels.User { 
                    Id = entityUser.Id,
                    FirstName = entityUser.FirstName,
                    LastName = entityUser.LastName, 
                    PatronymicName = entityUser.PatronymicName,
                    Birthday = entityUser.Birthday, 
                    Password = entityUser.Password,
                    RoleId = entityUser.RoleId
                };
        }
    }
}
