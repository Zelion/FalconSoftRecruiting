using System;

namespace ExerciseA.Domain.Filters
{
    public class GetAllOrdersFilter
    {
        public string OrderName { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
