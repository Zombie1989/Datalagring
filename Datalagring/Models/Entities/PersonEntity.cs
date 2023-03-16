using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datalagring.Models.Entities.TaskEntity;

namespace Datalagring.Models.Entities
{
    class PersonEntity
    {
        public Guid Id { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; } = null!;
        [StringLength(100)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string Email { get; set; } = null!;



        public ICollection<TaskEntity> Tasks = new HashSet<TaskEntity>();

    }
}
