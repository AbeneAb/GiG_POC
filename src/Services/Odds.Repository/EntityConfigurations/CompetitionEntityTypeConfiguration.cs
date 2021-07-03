using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class CompetitionEntityTypeConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competition", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Guid").ValueGeneratedOnAdd();
            builder.Property<string>("_name")
                .UsePropertyAccessMode( PropertyAccessMode.Field)
                .HasColumnName("Name").HasMaxLength(200).IsRequired(true);
            builder.Property<Guid>("_regionGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Region").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.HasOne(c => c.Region).WithMany().HasForeignKey(c=>c.RegionGuid);
            builder.HasMany(c => c.Events).WithOne(e => e.Competition).HasForeignKey(e => e.competitionGuid);
        }
    }
}
