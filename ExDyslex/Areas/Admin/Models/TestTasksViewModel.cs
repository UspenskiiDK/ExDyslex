using Entities;

namespace ExDyslex.Areas.Admin.Models
{
    public class TestTasksViewModel
    {
        public Test TestEntity { get; set; }
        public string TasksIds { get; set; }

        public TestTasksViewModel(Test testEntity, string tasksIds)
        {
            TestEntity = testEntity;
            TasksIds = tasksIds;
        }

        public TestTasksViewModel()
        {
        }
    }
}
