using Mitigation.Repositories;

namespace Mitigation.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        Task<int> CompleteAsync();
    }

}
