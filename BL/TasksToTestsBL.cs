using DAL;
using DAL.DbModels;
using Entities;
using TaskToTest = Entities.TasksToTest;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class TasksToTestsBL
    {
        public async Task CreateTaskToTest(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().CreateTaskToTest(taskToTest);
        }

        public async Task UpdateTaskToTest(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().UpdateTaskToTest(taskToTest);
        }

        public async Task DeleteTaskToTest(TaskToTest taskToTest)
        {
            await new TasksToTestsDAL().DeleteTaskToTest(taskToTest);
        }

        public List<Entities.TasksToTest> GetTaskToTestByTestId(int testId)
        {
            return  new TasksToTestsDAL().GetTaskToTestByTestId(testId);
        }
    }
}
