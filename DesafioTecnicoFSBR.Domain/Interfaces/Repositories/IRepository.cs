using DesafioTecnicoFSBR.Domain.Abstraction;
using System.Linq.Expressions;

namespace DesafioTecnicoFSBR.Domain.Interfaces.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default);
        Task AddAsync(List<TAggregateRoot> aggregatesRoot, CancellationToken cancellationToken = default);
        void Delete(TAggregateRoot aggregateRoot);
        void Delete(List<TAggregateRoot> aggregatesRoot);
        Task<List<TAggregateRoot>> Get(Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default);
        Task<List<TAggregateRoot>> Get(Expression<Func<TAggregateRoot, bool>> condition, Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default);
        Task<TAggregateRoot?> Get(Guid id, Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default);
        Task<bool> Exist(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken = default);
    }
}
