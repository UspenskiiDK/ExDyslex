using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using TestsToClient = Entities.TestsToClient;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class TestsToClientsDAL
    {
        private readonly ApplicationContext _context;

        public TestsToClientsDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public TestsToClientsDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateTestsToClient(TestsToClient testToClient)
        {
            var dbTestToClient = ConvertToDbModel(testToClient);

            if (dbTestToClient != null)
            {
                await _context.TestsToClients.AddAsync(dbTestToClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTestsToClient(TestsToClient testToClient)
        {
            var dbTestToClient = ConvertToDbModel(testToClient);

            if (dbTestToClient != null)
            {
                _context.TestsToClients.Update(dbTestToClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTestsToClient(TestsToClient testToClient)
        {
            var dbTestToClient = ConvertToDbModel(testToClient);

            if (dbTestToClient != null)
            {
                _context.TestsToClients.Remove(dbTestToClient);
                await _context.SaveChangesAsync();
            }
        }

        public DbModels.TestsToClient? ConvertToDbModel(TestsToClient? entityTestsToClient)
        {
            return entityTestsToClient == null ? null :
                new DbModels.TestsToClient
                { 
                    Id = entityTestsToClient.Id,
                    ClientId = entityTestsToClient.ClientId,
                    TasksToTestId = entityTestsToClient.TasksToTestId,
                    Answer = entityTestsToClient.Answer,
                    Grade = entityTestsToClient.Grade,
                    TasksToTest = new TasksToTestsDAL().ConvertToDbModel(entityTestsToClient.TasksToTest),
                    Client = new ClientsDAL().ConvertToDbModel(entityTestsToClient.Client),
                };
        }

        public TestsToClient? ConvertToEntity(DbModels.TestsToClient? dbTestsToClient)
        {
            return dbTestsToClient == null ? null :
                new TestsToClient(dbTestsToClient.Id,dbTestsToClient.ClientId,
                dbTestsToClient.TasksToTestId,dbTestsToClient.Answer,dbTestsToClient.Grade,
                new TasksToTestsDAL().ConvertToEntity(dbTestsToClient.TasksToTest), new ClientsDAL().ConvertToEntity(dbTestsToClient.Client));
        }
    }
}
