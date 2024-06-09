namespace ExDyslex.Areas.Public.Models
{
    public class TasksToTestModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TestId { get; set; }

        public TaskModel? Task { get; set; }
        public TestModel? Test { get; set; }
        //public List<TestsToClient> TestsToClients { get; set; }

        public TasksToTestModel(int id, int taskId, int testId, TaskModel task, TestModel test)
        {
            Id = id;
            TaskId = taskId;
            TestId = testId;
            Task = task;
            Test = test;
        }
    }
}
