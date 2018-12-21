using LabFlow.Domain.Protocol.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabFlow.Infra.Data.Mappings
{
    public class TigerMap : IEntityTypeConfiguration<Tiger>
    {
        public void Configure(EntityTypeBuilder<Tiger> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
