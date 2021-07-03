using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class MarketTemplateEntityTypeConfiguration : IEntityTypeConfiguration<MarketTemplate>
    {
        public void Configure(EntityTypeBuilder<MarketTemplate> builder)
        {
            builder.ToTable("MarketTemplate", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("Guid").ValueGeneratedOnAdd();

            builder.Property<string>("_name").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property<string>("_friendlyName").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("FriendlyName").HasMaxLength(200);
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
        }
    }
}
