using DAL;
using DAL.DbModels;
using Entities;
using TaskToTest = Entities.TasksToTest;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class TasksToTestsBL
    {
        public async Task CreateClient(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().CreateTaskToTest(taskToTest);
        }

        public async Task UpdateClient(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().UpdateTaskToTest(taskToTest);
        }

        public async Task DeleteClient(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().DeleteTaskToTest(taskToTest);
        }
    }
}
