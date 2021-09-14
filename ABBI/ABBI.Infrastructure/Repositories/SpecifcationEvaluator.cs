using ABBI.Domain.Seeds;
using ABBI.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ABBI.Infrastructure.Repositories
{
    class SpecifcationEvaluator<TEntity> where TEntity : BaseAuditModel
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;
            if (spec.Criteria != null)
            {
                query =  query.Where(spec.Criteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
