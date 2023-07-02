using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Core.Domain.Entities.Catalog;
using System;

public class CategoryConfiguration : IEntityTypeConfiguration<Category> {
    public CategoryConfiguration() {
    }

    public void Configure(EntityTypeBuilder<Category> builder) {
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Title).HasMaxLength(250);
    }
}
