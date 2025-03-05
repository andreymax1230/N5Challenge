using N5.System.Domain.UnitOfWork;

namespace N5.System.Infraestructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly Entities _dbContext;

    public UnitOfWork(Entities entities)
    {
        _dbContext = entities;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}