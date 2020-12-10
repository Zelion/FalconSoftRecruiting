using System;

namespace ExerciseA.API.Requests
{
    public class GetAllOrdersFilterRequest : PaginationRequest
    {
        public string OrderName { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
