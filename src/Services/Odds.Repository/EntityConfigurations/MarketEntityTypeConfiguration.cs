using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class MarketEntityTypeConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder.ToTable("Market", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("Guid").ValueGeneratedOnAdd();

            builder.Property<Guid>("_eventGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Event").IsRequired();
            builder.Property<string>("_label").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Label").IsRequired();
            builder.Property<DateTime>("_endDateTime").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Endtime").IsRequired();
            builder.Property<int>("_marketStatusId").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("MarketStatus").IsRequired();
            builder.Property<Guid?>("_marketTemplate").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("MarketTemplate").IsRequired(false);
            builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.UtcNow).IsRequired();
            builder.Property(m => m.IsActive).HasColumnName("IsActive").HasDefaultValue(true).IsRequired();
            builder.Property(m => m.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
            builder.HasOne(m => m.Event).WithMany(e => e.Markets).HasForeignKey(m => m.EventGuid);
            builder.HasMany(m => m.Selection).WithOne(s => s.Market).HasForeignKey(s => s.MarketGuid);
            builder.HasOne(m => m.MarketStatus).WithMany().HasForeignKey("_marketStatusId");
        }
    }
}
