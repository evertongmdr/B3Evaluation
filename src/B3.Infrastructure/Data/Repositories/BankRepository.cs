using B3.Domain.Interfaces.Repositories;
using B3.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace B3.Infrastructure.Data.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly DbSet<Bank> _bankSet;

        public BankRepository(ApplicationDbContext context)
        {
            _bankSet = context.Set<Bank>();
        }
        public async Task<Bank?> GetByIdAsync(Guid id)
        {
            return await _bankSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
