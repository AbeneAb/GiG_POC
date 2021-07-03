using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;

namespace Odds.Repository.EntityConfigurations
{
    internal class MarketStatusEntityTypeConfiguration : IEntityTypeConfiguration<MarketStatus>
    {
        public void Configure(EntityTypeBuilder<MarketStatus> builder)
        {
            builder.ToTable("MarketStatus", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(m => m.Name).HasMaxLength(200).IsRequired();

        }
    }
}
