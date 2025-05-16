using Microsoft.EntityFrameworkCore;
using Mitigation.Models;

namespace Mitigation.Repositories
{
    public class CandidateRepository : Repository<StoreItem>, ICandidateRepository
    {
        public CandidateRepository(PointOfSalesContext context) : base(context) { }

        public async Task<IEnumerable<StoreItem>> GetCandidateById(int Id)
        {
            return await _context.Candidates.Where(c => c.Id == Id).ToListAsync();
        }
    }

}
