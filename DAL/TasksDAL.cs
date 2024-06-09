using DAL.DbModels;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class TasksDAL
    {
        private readonly ApplicationContext _context;

        public TasksDAL() { _context = new ApplicationContext(new DbContextOptions<ApplicationContext>()); }

        public TasksDAL(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateTask(Entities.Task task)
        {
            var dbTask = ConvertToDbModel(task);

            if (dbTask != null)
            {
                await _context.Tasks.AddAsync(dbTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateTask(Entities.Task task)
        {
            var dbTask = ConvertToDbModel(task);

            if (dbTask != null)
            {
                _context.Tasks.Update(dbTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTask(Entities.Task task)
        {
            var dbTask = ConvertToDbModel(task);

            if (dbTask != null)
            {
                _context.Tasks.Remove(dbTask);
                await _context.SaveChangesAsync();
            }
        }

        public Entities.Task? GetTaskById(int taskId)
        {
            var dbTask =
                _context.Tasks.AsNoTracking().FirstOrDefault(task => task.Id == taskId) ?? throw new Exception();

            return ConvertToEntityShort(dbTask);
        }

        public DbModels.Task? ConvertToDbModel(Entities.Task? entityTask)
        {
            return entityTask == null ? null :
                new DbModels.Task { 
                    Id = entityTask.Id,
                    TaskCategory = entityTask.TaskCategory,
                    TaskQuestion = entityTask.TaskQuestion,
                    AnswerOption1 = entityTask.AnswerOption1,
                    AnswerOption2 = entityTask.AnswerOption2,
                    AnswerOption3 = entityTask.AnswerOption3,
                    AnswerOption4 = entityTask.AnswerOption4,
                    ImagePath = entityTask.ImagePath,
                    Tests = entityTask.Tests.Select(item => new TestsDAL().ConvertToDbModel(item)).ToList(),
                    TasksToTests = entityTask.TasksToTests.Select(item => new TasksToTestsDAL().ConvertToDbModel(item)).ToList()
                };
        }

        public Entities.Task? ConvertToEntity(DbModels.Task? dbTask)
        {
            return dbTask == null ? null :
                new Entities.Task(dbTask.Id, dbTask.TaskCategory, dbTask.TaskQuestion, dbTask.AnswerOption1, dbTask.AnswerOption2,
                    dbTask.AnswerOption3, dbTask.AnswerOption4, dbTask.ImagePath, dbTask.Tests.Select(item => new TestsDAL().ConvertToEntity(item)).ToList(), 
                    dbTask.TasksToTests.Select(item => new TasksToTestsDAL().ConvertToEntity(item)).ToList());
        }

        public Entities.Task? ConvertToEntityShort(DbModels.Task? dbTask)
        {
            return dbTask == null ? null :
                new Entities.Task(dbTask.Id, dbTask.TaskCategory, dbTask.TaskQuestion, dbTask.AnswerOption1, dbTask.AnswerOption2,
                    dbTask.AnswerOption3, dbTask.AnswerOption4, dbTask.ImagePath);
        }
    }
}
