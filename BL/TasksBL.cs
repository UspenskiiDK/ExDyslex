using DAL;
using DAL.DbModels;
using Entities;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class TasksBL
    {
        public async Task CreateClient(Entities.Task task)
        {
            await new TasksDAL().CreateTask(task);
        }

        public async Task UpdateClient(Entities.Task task)
        {
            await new TasksDAL().UpdateTask(task);
        }

        public async Task DeleteClient(Entities.Task task)
        {
            await new TasksDAL().DeleteTask(task);
        }
    }
}
