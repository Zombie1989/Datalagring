using System;
using System.ComponentModel.DataAnnotations;

namespace Datalagring.Models.Entities
{
    class TaskEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; } = null!;
        [StringLength(255)]
        public string Text { get; set; } = null!;
        public DateTime Created { get; set; } = DateTime.Now;
        public string StatusName { get; set; } = null!;
        public Status StatusModes { get; set; } = Status.NotStarted;


        //foreign keys
        public Guid PersonId { get; set; }
        public PersonEntity Person { get; set; } = null!;


        public enum Status
        {
            NotStarted,
            Ongoing,
            Completed
        }
    }
}
