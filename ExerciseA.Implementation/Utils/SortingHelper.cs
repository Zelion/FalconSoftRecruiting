using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using ExerciseA.Domain.Entities;

namespace ExerciseA.Implementation.Utils
{
    public static class SortingHelper
    {
        public static void ApplySort(ref IQueryable<Order> query, string orderByQueryString)
        {
            if (!query.Any() || string.IsNullOrEmpty(orderByQueryString))
                return;

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Order).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var sortingOrder = param.EndsWith(" asc") ? "ascending" : "descending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return;
            }

            query = query.OrderBy(orderQuery);
        }
    }
}
