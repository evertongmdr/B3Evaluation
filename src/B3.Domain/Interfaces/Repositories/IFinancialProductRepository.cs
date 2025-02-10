using B3.Domain.Models;
using System.Linq.Expressions;

namespace B3.Domain.Interfaces
{
    public interface IFinancialProductRepository
    {
        public Task<FinancialProduct?> FirstAsync(Expression<Func<FinancialProduct, bool>> predicate);

    }
}
