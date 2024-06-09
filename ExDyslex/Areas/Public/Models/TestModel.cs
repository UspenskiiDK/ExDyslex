using Entities;

namespace ExDyslex.Areas.Public.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ImagePath { get; set; }

        public TestModel(int id, string name, string? imagePath)
        {
            Id = id;
            Name = name;
            ImagePath = imagePath;
        }

        public static TestModel? ConvertFromEntity(Test testEntity)
        {
            return testEntity == null ? null :
                new TestModel(testEntity.Id, testEntity.Name, testEntity.ImagePath);
        }

        public static Test? ConvertToEntity(TestModel testModel)
        {
            return testModel == null ? null :
                new Test(testModel.Id, testModel.Name, testModel.ImagePath);
        }
    }
}
