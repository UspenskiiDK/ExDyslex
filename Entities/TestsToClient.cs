namespace Entities
{
    public class TestsToClient
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TasksToTestId { get; set; }
        public string? Answer { get; set; }
        public int? Grade { get; set; }

        public TasksToTest? TasksToTest { get; set; }
        public Client? Client { get; set; }

        public TestsToClient(int id, int clientId, int tasksToTestId, string? answer, int? grade, TasksToTest? tasksToTest, Client? client)
        {
            Id = id;
            ClientId = clientId;
            TasksToTestId = tasksToTestId;
            Answer = answer;
            Grade = grade;
            TasksToTest = tasksToTest;
            Client = client;
        }
    }
}
