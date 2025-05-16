using Mitigation.Models;

namespace Mitigation.Repositories
{
    public interface ICandidateRepository : IRepository<StoreItem>
    {
        Task<IEnumerable<StoreItem>> GetCandidateById(int Id);
    }
}
