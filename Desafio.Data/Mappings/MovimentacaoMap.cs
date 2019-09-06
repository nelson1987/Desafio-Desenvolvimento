using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Data.Mappings
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("CAD_MOVIMENTACAO", "dbo");

            builder.Property(x => x.Id)
                .HasColumnName("IDT_MOVIMENTACAO")
                .HasColumnType("uniqueidentifier")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ValorInvestido)
                .HasColumnName("VLR_MOVIMENTACAO")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(x => x.Pessoa)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey("IDT_PESSOA");

            builder.HasOne(x => x.Fundo)
                .WithMany(x=>x.Movimentacoes)
                .HasForeignKey("IDT_FUNDO");
        }
    }
}
