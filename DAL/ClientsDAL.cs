using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using Client = Entities.Client;

namespace DAL
{
    public class ClientsDAL
    {
        private readonly ApplicationContext _context;

        public ClientsDAL() { }

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

        private DbModels.Client? ConvertToDbModel(Client? entityClient)
        {
            return entityClient == null ? null :
                new DbModels.Client(entityClient.Id, entityClient.FirstName, entityClient.LastName, entityClient.PatronymicName, 
                entityClient.Birthday, entityClient.Phone, entityClient.Email, entityClient.Password, entityClient.MainPhotoPath);
        }

        private Client? ConvertToEntity(DbModels.Client? dbClient)
        {
            return dbClient == null ? null :
                new Client(dbClient.Id, dbClient.FirstName, dbClient.LastName, dbClient.PatronymicName,
                dbClient.Birthday, dbClient.Phone, dbClient.Email, dbClient.Password, dbClient.MainPhotoPath);
        }
    }
}
