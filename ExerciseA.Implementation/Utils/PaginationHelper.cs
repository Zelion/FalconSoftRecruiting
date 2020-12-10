using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExerciseA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseA.Implementation.Utils
{
    public static class PaginationHelper<T> where T : BaseEntity
    {
        public async static Task<IEnumerable<T>> PagedList(IQueryable<T> query, int page)
        {
            return await query.Skip((page - 1) * 10)
                        .Take(10)
                        .ToListAsync();
        }
    }
}
