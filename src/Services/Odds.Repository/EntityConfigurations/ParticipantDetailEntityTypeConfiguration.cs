using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class ParticipantDetailEntityTypeConfiguration : IEntityTypeConfiguration<ParticipantDetail>
    {
        public void Configure(EntityTypeBuilder<ParticipantDetail> builder)
        {
            builder.ToTable("ParticipantDetail", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(P => P.Id);
            builder.Property(p => p.Id).HasColumnName("Guid").ValueGeneratedOnAdd();

            builder.Property<Guid>("_participantGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("ParticipantId").IsRequired();
            builder.Property<int>("_index").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Index").IsRequired();
            builder.Property<Guid>("_eventGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("EventId").IsRequired();
            builder.Property<string>("_description").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Description").IsRequired();
            builder.Property(p => p.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false);
            builder.Property(p => p.LastModifiedDate).HasColumnName("LastModOn").IsRequired(false);
            builder.HasOne(p => p.Event).WithMany(e => e.Participants).HasForeignKey("_eventGuid");
            builder.HasOne(p => p.Participant).WithMany(p=>p.ParticipantDetails).HasForeignKey("_participantGuid");

        }
    }
}
