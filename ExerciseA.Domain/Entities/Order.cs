using System;
using System.Collections.Generic;

namespace ExerciseA.Domain.Entities
{
    public class Order: BaseEntity
    {
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
