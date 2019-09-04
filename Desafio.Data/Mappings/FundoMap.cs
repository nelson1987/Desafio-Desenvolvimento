using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class FundoMap : IEntityTypeConfiguration<Fundo>
    {
        public void Configure(EntityTypeBuilder<Fundo> builder)
        {
            builder.ToTable("CAD_FUNDO", "dbo");

            builder.Property(x => x.Id)
                .HasColumnName("IDT_FUNDO")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .HasColumnName("NOM_FUNDO")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
