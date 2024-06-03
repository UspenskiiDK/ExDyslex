using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using Test = Entities.Test;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class TestsDAL
    {
        private readonly ApplicationContext _context;

        public TestsDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public TestsDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateTest(Test test)
        {
            var dbTest = ConvertToDbModel(test);

            if (dbTest != null)
            {
                await _context.Tests.AddAsync(dbTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTest(Test test)
        {
            var dbTest = ConvertToDbModel(test);

            if (dbTest != null)
            {
                _context.Tests.Update(dbTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTest(Test test)
        {
            var dbTest = ConvertToDbModel(test);

            if (dbTest != null)
            {
                _context.Tests.Remove(dbTest);
                await _context.SaveChangesAsync();
            }
        }

        public DbModels.Test? ConvertToDbModel(Test? entityTest)
        {
            return entityTest == null ? null :
                new DbModels.Test { 
                    Id = entityTest.Id,
                    Name = entityTest.Name,
                    ImagePath = entityTest.ImagePath,
                    Tasks = entityTest.Tasks.Select(item => new TasksDAL().ConvertToDbModel(item)).ToList(),
                    TasksToTests = entityTest.TasksToTests.Select(item => new TasksToTestsDAL().ConvertToDbModel(item)).ToList()
                };
        }

        public Test? ConvertToEntity(DbModels.Test? dbTest)
        {
            return dbTest == null ? null :
                new Test(dbTest.Id, dbTest.Name, dbTest.ImagePath, dbTest.Tasks.Select(item => new TasksDAL().ConvertToEntity(item)).ToList(), 
                dbTest.TasksToTests.Select(item => new TasksToTestsDAL().ConvertToEntity(item)).ToList());
        }
    }
}
