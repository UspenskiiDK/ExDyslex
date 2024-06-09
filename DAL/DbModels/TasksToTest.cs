using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class TasksToTest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int TestId { get; set; }

        public Task? Task { get; set; }
        public Test? Test { get; set; }
        public virtual ICollection<TestsToClient> TestsToClients { get; set; }
    }
}
