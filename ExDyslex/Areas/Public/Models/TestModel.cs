using Entities;

namespace ExDyslex.Areas.Public.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        public TestModel(int id, string name, string? imagePath, List<TaskModel> tasks)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
            Tasks = tasks;
        }

        public static TestModel? ConvertFromEntity(Test testEntity)
        {
            return testEntity == null ? null :
                new TestModel(testEntity.Id, 
                    testEntity.Name, 
                    testEntity.ImagePath, 
                    testEntity.Tasks.Select(item => TaskModel.ConvertFromEntity(item)).ToList());
        }
    }
}
