﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using ExerciseA.Domain.Filters;
using ExerciseA.Domain.Respositories;
using ExerciseA.Implementation.Utils;
using ExerciseA.Implementation2.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ExerciseA.Implementation2.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly ExerciseAContext dbContext;

        public OrderRepository(ExerciseAContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAll(PaginationFilter paginationFilter, GetAllOrdersFilter filter = null)
        {
            var query = dbContext.Set<Order>()
                            .Include(x => x.OrderDetails)
                                .ThenInclude(x => x.Product)
                            .AsQueryable();

            query = AddFiltersOnQuery(query, filter);

            return await PaginationHelper<Order>.PagedList(query, paginationFilter.Page);
        }

        private IQueryable<Order> AddFiltersOnQuery(IQueryable<Order> query, GetAllOrdersFilter filter)
        {
            if (!string.IsNullOrEmpty(filter?.OrderName))
                query = query.Where(x => x.CustomerName.Equals(filter.OrderName));
            if (!filter.OrderCreatedDate.Equals(DateTime.MinValue))
                query = query.Where(x => x.CreatedDate.Equals(filter.OrderCreatedDate));
            if (!string.IsNullOrEmpty(filter?.ProductName))
                query = query.Where(x => x.OrderDetails.Any(x => x.Product.Name.Equals(filter.ProductName)));
            if (filter?.ProductPrice != 0)
                query = query.Where(x => x.OrderDetails.Any(x => x.Product.Price == filter.ProductPrice));
            if (filter?.Quantity != 0)
                query = query.Where(x => x.OrderDetails.Any(x => x.Quantity == filter.Quantity));

            return query;
        }

    }
}
