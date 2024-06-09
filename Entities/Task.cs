namespace Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int TaskCategory { get; set; }
        public string TaskQuestion { get; set; }
        public string? AnswerOption1 { get; set; }
        public string? AnswerOption2 { get; set; }
        public string? AnswerOption3 { get; set; }
        public string? AnswerOption4 { get; set; }
        public string? ImagePath { get; set; }
        public List<Test> Tests { get; set; }
        public List<TasksToTest> TasksToTests { get; set; }

        public Task(int id, int taskCategory, string taskQuestion, 
            string? answerOption1, string? answerOption2, string? answerOption3, string? answerOption4,
            string? imagePath, List<Test> tests, List<TasksToTest> tasksToTests)
        {
            Id = id;
            TaskCategory = taskCategory;
            TaskQuestion = taskQuestion;
            AnswerOption1 = answerOption1;
            AnswerOption2 = answerOption2;
            AnswerOption3 = answerOption3;
            AnswerOption4 = answerOption4;
            ImagePath = imagePath;
            Tests = tests;
            TasksToTests = tasksToTests;
        }

        public Task(int id, int taskCategory, string taskQuestion,
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
    }
}
