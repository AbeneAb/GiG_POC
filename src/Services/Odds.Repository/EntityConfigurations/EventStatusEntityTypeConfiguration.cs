using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;

namespace Odds.Repository.EntityConfigurations
{
    internal class EventStatusEntityTypeConfiguration : IEntityTypeConfiguration<EventStatus>
    {
        public void Configure(EntityTypeBuilder<EventStatus> builder)
        {
            builder.ToTable("EventStatus", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(e => e.Name).HasMaxLength(200).IsRequired();
        }
    }
}
