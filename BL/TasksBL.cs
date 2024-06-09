using DAL;
using DAL.DbModels;
using Entities;
using Task = System.Threading.Tasks.Task;

namespace BL
{
    public class TasksBL
    {
        public async Task CreateTask(Entities.Task task)
        {
            await new TasksDAL().CreateTask(task);
        }

        public async Task UpdateTask(Entities.Task task)
        {
            await new TasksDAL().UpdateTask(task);
        }

        public async Task DeleteTask(Entities.Task task)
        {
            await new TasksDAL().DeleteTask(task);
        }

        public List<Entities.Task> GetAllTasks()
        {
            var tasks = new TasksDAL().GetAllTasks();

            return tasks;
        }

        public Entities.Task? GetTaskById(int id)
        {
            var task = new TasksDAL().GetTaskById(id);
            return task;
        }
    }
}
