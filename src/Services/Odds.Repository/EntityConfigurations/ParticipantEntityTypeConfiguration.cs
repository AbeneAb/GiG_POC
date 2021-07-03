using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class ParticipantEntityTypeConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participant", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Guid").ValueGeneratedOnAdd();

            builder.Property<string>("_name").UsePropertyAccessMode(PropertyAccessMode.Field).HasMaxLength(500).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(p => p.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
        }
    }
}
