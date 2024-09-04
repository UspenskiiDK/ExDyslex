using Task = Entities.Task;

namespace ExDyslex.Areas.Public.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int TaskCategory { get; set; }
        public string TaskQuestion { get; set; }
        public string? AnswerOption1 { get; set; }
        public string? AnswerOption2 { get; set; }
        public string? AnswerOption3 { get; set; }
        public string? AnswerOption4 { get; set; }
        public string? ImagePath { get; set; }

        public TaskModel(int id, int taskCategory, string taskQuestion,
            string? answerOption1, string? answerOption2, string? answerOption3, string? answerOption4, string? imagePath)
        {
            Id = id;
            TaskCategory = taskCategory;
            TaskQuestion = taskQuestion;
            AnswerOption1 = answerOption1;
            AnswerOption2 = answerOption2;
            AnswerOption3 = answerOption3;
            AnswerOption4 = answerOption4;
            ImagePath = imagePath;
        }

        public static TaskModel? ConvertFromEntity(Task taskEntity)
        {
            return taskEntity == null ? null :
                new TaskModel(taskEntity.Id, taskEntity.TaskCategory, taskEntity.TaskQuestion, taskEntity.AnswerOption1,
                    taskEntity.AnswerOption2, taskEntity.AnswerOption3, taskEntity.AnswerOption4, taskEntity.ImagePath);
        }
    }
}
