using System;

namespace ExerciseA.API.Requests
{
    public class GetAllOrdersFilterRequest : PaginationRequest
    {
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
