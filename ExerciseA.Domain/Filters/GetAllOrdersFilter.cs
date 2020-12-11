using System;

namespace ExerciseA.Domain.Filters
{
    public class GetAllOrdersFilter
    {
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
