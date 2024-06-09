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
        public List<Test> GetAllTests()
        {
            var dbTests = _context.Tests.Select(item => item).ToList();

            var entitiesTests = new List<Test>();

            if (dbTests != null)
            {
                entitiesTests = dbTests.Select(item => ConvertToEntity(item)).ToList();
            }

            if (entitiesTests != null)
            {
                return entitiesTests;
            }
            else
            {
                return new List<Test>();
            }
            
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

        public async Task<Test?> GetTesttById(int testId)
        {
            var dbTest =
                await _context.Tests.AsNoTracking().FirstOrDefaultAsync(test => test.Id == testId) ?? throw new Exception();

            return ConvertToEntity(dbTest);
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

        public Test ConvertToEntity(DbModels.Test dbTest)
        {
            var test = new Test(dbTest.Id, dbTest.Name, dbTest.ImagePath);

            var ttt = new TasksToTestsDAL().GetTaskToTestByTestId(test.Id);
            var tasks = ttt.Select(item => new TasksDAL().GetTaskById(item.TaskId)).ToList();

            if (tasks != null && tasks.Count > 0)
            {
                test.Tasks = tasks;
            }
            else
            {
                test.Tasks = new List<Entities.Task>();
            }

            return test;
        }
    }
}
