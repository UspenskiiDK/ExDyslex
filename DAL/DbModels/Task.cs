namespace DAL.DbModels
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
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<TasksToTest> TasksToTests { get; set; }
    }
}
