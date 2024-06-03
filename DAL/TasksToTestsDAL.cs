using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using TasksToTest = Entities.TasksToTest;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class TasksToTestsDAL
    {
        private readonly ApplicationContext _context;

        public TasksToTestsDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public TasksToTestsDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateTaskToTest(TasksToTest taskToTest)
        {
            var dbTaskToTest = ConvertToDbModel(taskToTest);

            if (dbTaskToTest != null)
            {
                await _context.TasksToTests.AddAsync(dbTaskToTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTaskToTest(TasksToTest taskToTest)
        {
            var dbTaskToTest = ConvertToDbModel(taskToTest);

            if (dbTaskToTest != null)
            {
                _context.TasksToTests.Update(dbTaskToTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTaskToTest(TasksToTest taskToTest)
        {
            var dbTaskToTest = ConvertToDbModel(taskToTest);

            if (dbTaskToTest != null)
            {
                _context.TasksToTests.Remove(dbTaskToTest);
                await _context.SaveChangesAsync();
            }
        }

        public DbModels.TasksToTest? ConvertToDbModel(TasksToTest? entityTaskToTest)
        {
            return entityTaskToTest == null ? null :
                new DbModels.TasksToTest { 
                    Id = entityTaskToTest.Id,
                    TaskId = entityTaskToTest.TaskId,
                    TestId = entityTaskToTest.TestId,
                    Task = new TasksDAL().ConvertToDbModel(entityTaskToTest.Task),
                    Test = new TestsDAL().ConvertToDbModel(entityTaskToTest.Test),
                    TestsToClients = entityTaskToTest.TestsToClients.Select(item => new TestsToClientsDAL().ConvertToDbModel(item)).ToList(),
                };
        }

        public TasksToTest? ConvertToEntity(DbModels.TasksToTest? dbTasksToTest)
        {
            return dbTasksToTest == null ? null :
                new TasksToTest(dbTasksToTest.Id, dbTasksToTest.TaskId, dbTasksToTest.TestId, 
                new TasksDAL().ConvertToEntity(dbTasksToTest.Task), new TestsDAL().ConvertToEntity(dbTasksToTest.Test),
                dbTasksToTest.TestsToClients.Select(item => new TestsToClientsDAL().ConvertToEntity(item)).ToList());
        }
    }
}
