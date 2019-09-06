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
        }
    }
}
