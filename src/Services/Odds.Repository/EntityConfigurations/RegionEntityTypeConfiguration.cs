using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class RegionEntityTypeConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Region", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(r => r.Id);
            builder.Property(p => p.Id).HasColumnName("Guid").ValueGeneratedOnAdd();

            builder.Property<string>("_name").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Name").HasMaxLength(200).IsRequired();
            builder.HasMany(r => r.Competitions).WithOne().HasForeignKey(c => c.RegionGuid);
            builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(r => r.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(r => r.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
        }
    }
}
