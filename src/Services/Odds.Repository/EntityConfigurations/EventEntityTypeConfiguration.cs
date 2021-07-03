using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(e => e.Id);
            builder.Property(c => c.Id).HasColumnName("Guid").ValueGeneratedOnAdd();
            builder.Property<Guid>("_categoryGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Category").IsRequired();
            builder.Property<DateTime>("_startTime").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("StartTime").IsRequired();
            builder.Property<Guid>("_competitionGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Competition").IsRequired();
            builder.Property<string>("_label").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Label").IsRequired().HasMaxLength(500);
            builder.Property<int>("_eventStatusId").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("EventStatus").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);

            builder.HasOne(e => e.EventStatus).WithMany().HasForeignKey("_eventStatusId");
            builder.HasOne(e => e.Category).WithMany().HasForeignKey("_categoryGuid");
            builder.HasOne(e => e.Competition).WithMany(e => e.Events).HasForeignKey(c => c.competitionGuid);
            builder.HasMany(e => e.Participants).WithOne(e=>e.Event).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(e => e.Markets).WithOne(e=>e.Event).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
