using Mitigation.Repositories;

namespace Mitigation.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PointOfSalesContext _context;
        public ICandidateRepository Candidates { get; }

        public UnitOfWork(PointOfSalesContext context, ICandidateRepository candidateRepository)
        {
            _context = context;
            Candidates = candidateRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
