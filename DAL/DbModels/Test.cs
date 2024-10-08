﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbModels
{
    public class Test
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<TasksToTest> TasksToTests { get; set; }
    }
}
