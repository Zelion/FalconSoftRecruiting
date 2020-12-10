using System;
using System.Collections.Generic;

namespace ExerciseA.WebAPI.Controllers.Order.Response
{
    public class OrderResponse
    {
        public long OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }

        public IEnumerable<OrderDetailResponse> OrderDetails { get; set; }
    }
}
