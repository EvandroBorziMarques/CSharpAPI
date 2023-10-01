using Cadastro.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
                builder.HasKey(u=> u.Id);
                builder.Property(u=> u.Id)
                .HasColumnType("INT").UseIdentityColumn();
                builder.Property(u => u.Nome).HasColumnType("VARCHAR(100)");
                builder.HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}