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

            //builder.Property(x => x.Pessoa.Id)
            //    .HasColumnName("IDT_PESSOA")
            //    .HasColumnType("uniqueidentifier")
            //    .IsRequired();

            //builder.Property(x => x.Fundo.Id)
            //    .HasColumnName("IDT_FUNDO")
            //    .HasColumnType("uniqueidentifier")
            //    .IsRequired();

            builder.HasOne(x => x.Pessoa)
                .WithMany(x => x.Movimentacoes)
                .HasForeignKey("IDT_PESSOA");
            builder.HasOne(x => x.Fundo)
                .WithMany(x=>x.Movimentacoes)
                .HasForeignKey("IDT_FUNDO");

            //builder.HasOne(x => x.Fundo)
            //    .WithMany(x => x.Movimentacoes);

            //builder.HasOne(x => x.Fundo)
            //    .WithMany(x=>x.Id)
            //    .WithOne();

            //builder.Property(x => x.MinimoExigido)
            //    .HasColumnName("VLR_INICIAL")
            //    .HasColumnType("decimal(18,2)")
            //    .IsRequired();

        }
    }
}
