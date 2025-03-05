using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace N5.System.Infraestructure;

public partial class Entities : IdentityDbContext
{
    #region Ctor
    private readonly IHttpContextAccessor _contextAccessor;
    public Entities()
    {
    }

    public Entities(DbContextOptions<Entities> options, IHttpContextAccessor contextAccessor = null) : base(options)
    {
        _contextAccessor = contextAccessor;
    }

    #endregion

    #region Utilities

    /// <summary>
    /// Further configuration the model
    /// </summary>
    /// <param name="builder">The builder being used to construct the model for this context</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var implementedConfigTypes = Assembly.GetExecutingAssembly()
           .GetTypes().Where(t => !t.IsAbstract
           && !t.IsGenericTypeDefinition
           && t.GetTypeInfo().ImplementedInterfaces.Any(i =>
           i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

        if (implementedConfigTypes.Any())
            foreach (var configType in implementedConfigTypes)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                dynamic config = Activator.CreateInstance(configType);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                builder.ApplyConfiguration(config);
            }
        //builder.ApplyConfiguration(new UserPermissionEntityConfiguration());
        base.OnModelCreating(builder);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates a DbSet that can be used to query and save instances of entity
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A set for the given entity type</returns>
    public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }
    #endregion
}
