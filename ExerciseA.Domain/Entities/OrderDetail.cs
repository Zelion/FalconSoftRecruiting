﻿namespace ExerciseA.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}
