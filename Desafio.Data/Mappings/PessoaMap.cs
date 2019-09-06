using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("CAD_PESSOA", "dbo");

            builder.Property(x => x.Id)
                .HasColumnName("IDT_PESSOA")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            //builder.Property(e => e.Movimentacoes)
            //    .HasColumnName("NOM_FUNDO")
            //    .HasMaxLength(50)
            //    .IsRequired();

            //builder.Property(x => x.MinimoExigido)
            //    .HasColumnName("VLR_INICIAL")
            //    .HasColumnType("decimal(18,2)")
            //    .IsRequired();

        }
    }
}
