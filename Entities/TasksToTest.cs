namespace Entities
{
    public class TasksToTest
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TestId { get; set; }

        public Task? Task { get; set; }
        public Test? Test { get; set; }
        public List<TestsToClient> TestsToClients { get; set; }

        public TasksToTest(int id, int taskId, int testId, Task? task, Test? test, List<TestsToClient> testsToClients)
        {
            Id = id;
            TaskId = taskId;
            TestId = testId;
            Task = task;
            Test = test;
            TestsToClients = testsToClients;
        }
    }
}
