using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Respositories;
using ExerciseA.Implementation.DbContexts;
using ExerciseA.Implementation.Utils;
using Microsoft.EntityFrameworkCore;

namespace ExerciseA.Implementation.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ExerciseAContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllFilteredAsync(PaginationFilter paginationFilter, SortingFilter sortingFilter, GetAllOrdersFilter filter = null)
        {
            var query = dbContext.Set<Order>()
                            .Include(x => x.OrderDetails)
                                .ThenInclude(x => x.Product)
                            .AsQueryable();

            AddFiltersOnQuery(ref query, filter);
            SortingHelper.ApplySort(ref query, sortingFilter.OrderBy);

            return await PaginationHelper<Order>.PagedList(query, paginationFilter.Page);
        }

        private void AddFiltersOnQuery(ref IQueryable<Order> query, GetAllOrdersFilter filter)
        {
            if (!string.IsNullOrEmpty(filter?.CustomerName))
                query = query.Where(x => x.CustomerName.Contains(filter.CustomerName));
            if (!filter.CreatedDate.Equals(DateTime.MinValue))
                query = query.Where(x => x.CreatedDate.Equals(filter.CreatedDate));
            if (!string.IsNullOrEmpty(filter?.ProductName))
                query = query.Where(x => x.OrderDetails.Any(x => x.Product.Name.Contains(filter.ProductName)));
            if (filter?.ProductPrice != 0)
                query = query.Where(x => x.OrderDetails.Any(x => x.Product.Price == filter.ProductPrice));
            if (filter?.Quantity != 0)
                query = query.Where(x => x.OrderDetails.Any(x => x.Quantity == filter.Quantity));
        }

    }
}
