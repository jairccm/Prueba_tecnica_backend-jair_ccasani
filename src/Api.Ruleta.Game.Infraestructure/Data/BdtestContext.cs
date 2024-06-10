using System.Reflection;
using Api.Ruleta.Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Ruleta.Game.Infraestructure.Data;

public partial class BdtestContext : DbContext
{
    public BdtestContext()
    {
    }

    public BdtestContext(DbContextOptions<BdtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RuletaUsuario> RuletaUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
