using DesafioTecnicoFSBR.Domain.Abstraction;
using DesafioTecnicoFSBR.Domain.Interfaces.Repositories;
using DesafioTecnicoFSBR.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesafioTecnicoFSBR.Infra.Persistence.Repositories
{
    public class Repository<TAggregateRoot>(AppDbContext context)
    : IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        private readonly AppDbContext _context = context;

        public async Task AddAsync(TAggregateRoot aggregateRoot, CancellationToken cancellationToken = default)
        {
            await _context.Set<TAggregateRoot>().AddAsync(aggregateRoot, cancellationToken);
        }

        public async Task AddAsync(List<TAggregateRoot> aggregatesRoot, CancellationToken cancellationToken = default)
        {
            await _context.Set<TAggregateRoot>().AddRangeAsync(aggregatesRoot, cancellationToken);
        }

        public void Delete(TAggregateRoot aggregateRoot)
        {
            _context.Set<TAggregateRoot>().Remove(aggregateRoot);
        }

        public void Delete(List<TAggregateRoot> aggregatesRoot)
        {
            _context.Set<TAggregateRoot>().RemoveRange(aggregatesRoot);
        }

        public async Task<List<TAggregateRoot>> Get(Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TAggregateRoot>().AsQueryable();

            if (tracking)
            {
                query = query.AsTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<List<TAggregateRoot>> Get(Expression<Func<TAggregateRoot, bool>> condition, Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TAggregateRoot>().Where(condition);

            if (tracking)
            {
                query = query.AsTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TAggregateRoot?> Get(Guid id, Func<IQueryable<TAggregateRoot>, IQueryable<TAggregateRoot>>? include = null, bool tracking = false, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TAggregateRoot>().Where(aggregate => aggregate.Id == id);

            if (tracking)
            {
                query = query.AsTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> Exist(Expression<Func<TAggregateRoot, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await _context.Set<TAggregateRoot>().AnyAsync(condition, cancellationToken);
        }
    }
}
