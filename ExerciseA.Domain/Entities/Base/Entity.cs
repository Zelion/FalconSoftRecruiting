using System;

namespace ExerciseA.Domain.Entities.Base
{
    public class Entity : BaseEntity
    {
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
