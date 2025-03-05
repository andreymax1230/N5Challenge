using N5.System.Domain.UnitOfWork;

namespace N5.System.Infraestructure;

public class UnitOfWork(Entities _dbContext) : IUnitOfWork
{
    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}