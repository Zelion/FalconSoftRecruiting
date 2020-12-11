using System.Collections.Generic;
using System.Threading.Tasks;
using Bogus;
using Bogus.Extensions;
using ExerciseA.Domain.Entities;

namespace ExerciseA.API.UnitTesting.MockedResults
{
    public class Results
    {
        public static async Task<IEnumerable<Order>> GetOrdersMockedData()
        {
            var orderIds = 1;
            var order = new Faker<Order>()
                .RuleFor(m => m.Id, f => orderIds++)
                .RuleFor(m => m.CustomerName, f => f.Person.FullName)
                .RuleFor(m => m.CreatedDate, f => f.Date.Recent(7));
            var orders = order.GenerateBetween(50, 50);

            return await Task.FromResult(orders);
        }
    }
}
