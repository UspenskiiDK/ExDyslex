namespace DAL.DbModels
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
    }
}
