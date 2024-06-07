namespace Entities
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }
        public List<Task>? Tasks { get; set; }
        public List<TasksToTest>? TasksToTests { get; set; }

        public Test(int id, string name, string? imagePath)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
        }
    }
}
