using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Odds.Domain.Entities;
using Odds.Repository.Context;
using System;

namespace Odds.Repository.EntityConfigurations
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category", OddsContext.DEFAULT_SCHEMA);
            builder.HasKey(c => c.Id);
            builder.Property(b => b.Id).HasColumnName("Guid").ValueGeneratedOnAdd();
            builder.Property<string>("_name").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("Name").HasMaxLength(200).IsRequired();   
            builder.Property<Guid?>("_parentGuid").UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("ParentGuid").IsRequired(false);
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(c => c.CreatedBy).HasColumnName("CreatedByUser").IsRequired();
            builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired().HasDefaultValue(true);
            builder.HasMany(c => c.Children).WithOne(c => c.Parent).HasForeignKey("_parentGuid").IsRequired(false).OnDelete(DeleteBehavior.Restrict);
            var navigation = builder.Metadata.FindNavigation(nameof(Category.Regions));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
