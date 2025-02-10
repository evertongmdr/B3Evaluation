using B3.Domain.Interfaces;
using B3.Domain.Models;

namespace B3.Domain.Interfaces.Repositories
{
    public interface IBankRepository
    {
        public Task<Bank?> GetByIdAsync(Guid id);
    }
}
