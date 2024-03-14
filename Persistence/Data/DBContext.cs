
using System.Reflection;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;
public class DBContext(DbContextOptions<DbContext> options) : DbContext(options)
{
    public DbSet<Producto> Productos {get; set;}
    public DbSet<Rol> Roles {get; set;}
    public DbSet<Tipo> Tipos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
