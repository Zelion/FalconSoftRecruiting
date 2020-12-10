using ExerciseA.Domain.Entities;

namespace ExerciseA.Domain.DataContext
{
    public class OrderDetailDataContext
    {
        public long Id { get; set; }
        public int Quantity { get; set; }

        public void Update(OrderDetail orderDetail)
        {
            orderDetail.Quantity = Quantity;
        }
    }
}
