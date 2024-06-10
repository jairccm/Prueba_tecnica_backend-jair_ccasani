using Api.Ruleta.Game.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Ruleta.Game.Infraestructure.Data.Configuration
{
    public class RuletaUsuarioConfiguration : IEntityTypeConfiguration<RuletaUsuario>
    {
        public void Configure(EntityTypeBuilder<RuletaUsuario> entity)
        {
            entity.HasKey(e => e.Nombre).HasName("PK__tblRulet__72AFBCC71158927E");

            entity.ToTable("tblRuletaUsuario");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("monto");
        }
    }
}
