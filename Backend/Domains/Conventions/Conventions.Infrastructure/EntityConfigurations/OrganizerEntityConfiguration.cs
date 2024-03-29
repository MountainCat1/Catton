﻿using Conventions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conventions.Infrastructure.EntityConfigurations;

public class OrganizerEntityConfiguration : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.ToTable("Organizers");

        builder.HasKey(o => new {o.Id});

        builder.HasIndex(o => o.AccountId);

        builder.Property(o => o.CreatedDate)
            .IsRequired();

        builder.Property(o => o.Role)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(o => o.AccountUsername)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(o => o.AccountAvatarUri)
            .HasMaxLength(500);

        // Configure relationships, indexes, etc.
    }
}