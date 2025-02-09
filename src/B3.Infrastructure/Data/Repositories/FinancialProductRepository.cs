using B3.Domain.Interfaces.Repositories;
using B3.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace B3.Infrastructure.Data.Repositories
{
    public class FinancialProductRepository : IFinancialProductRepository
    {
        private readonly DbSet<FinancialProduct> _financialProductSet;

        public FinancialProductRepository(ApplicationDbContext context)
        {
            _financialProductSet = context.Set<FinancialProduct>();
        }

        public async Task<FinancialProduct?> FirstAsync(Expression<Func<FinancialProduct, bool>> predicate) 
            => await _financialProductSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
    }
}
