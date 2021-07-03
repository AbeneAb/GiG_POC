using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class SelectionEntityConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            builder.ToTable("Selection", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("Guid").ValueGeneratedOnAdd();
            builder.Property<Guid>("_marketGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("MarketId").IsRequired();
            builder.Property<decimal>("_odds").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Odds").IsRequired();
            builder.Property<int>("_index").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Index").IsRequired();
            builder.Property<string>("_participantLabel").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("ParticipantLabel").IsRequired();
            builder.Property<int>("_selectionStatusStatusId").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("SelectionStatus").IsRequired();

            builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(s => s.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(s => s.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
            builder.HasOne(s => s.Market).WithMany(m => m.Selection).HasForeignKey(s => s.MarketGuid);
            builder.HasOne(m => m.SelectionStatus).WithMany().HasForeignKey("_selectionStatusStatusId");

        }
    }
}
