using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using Client = Entities.Client;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class ClientsDAL
    {
        private readonly ApplicationContext _context;

        public ClientsDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public ClientsDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateClient(Client client)
        {
            var dbClient = ConvertToDbModel(client);

            if (dbClient != null)
            {
                await _context.Clients.AddAsync(dbClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateClient(Client client)
        {
            var dbClient = ConvertToDbModel(client);

            if (dbClient != null)
            {
                _context.Clients.Update(dbClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(Client client)
        {
            var dbClient = ConvertToDbModel(client);

            if (dbClient != null)
            {
                _context.Clients.Remove(dbClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Client?> GetClientByEmail(string email)
        {
            var dbClient = string.IsNullOrWhiteSpace(email) ? null :
                await _context.Clients.AsNoTracking().FirstOrDefaultAsync(client => client.Email == email) ?? throw new Exception();

            return ConvertToEntity(dbClient);
        }

        public DbModels.Client? ConvertToDbModel(Client? entityClient)
        {
            return entityClient == null ? null :
                new DbModels.Client { 
                    Id = entityClient.Id,
                    FirstName = entityClient.FirstName,
                    LastName = entityClient.LastName, 
                    PatronymicName = entityClient.PatronymicName,
                    Birthday = entityClient.Birthday, 
                    Phone = entityClient.Phone, 
                    Email = entityClient.Email, 
                    Password = entityClient.Password, 
                    MainPhotoPath = entityClient.MainPhotoPath 
                };
        }

        public Client? ConvertToEntity(DbModels.Client? dbClient)
        {
            return dbClient == null ? null :
                new Client(dbClient.Id, dbClient.FirstName, dbClient.LastName, dbClient.PatronymicName,
                dbClient.Birthday, dbClient.Phone, dbClient.Email, dbClient.Password, dbClient.MainPhotoPath);
        }
    }
}
