namespace ExerciseA.API.Controllers.Order.Response
{
    public class OrderDetailResponse
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
