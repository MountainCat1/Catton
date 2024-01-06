﻿// <auto-generated />
using System;
using Accounts.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accounts.Application.Migrations
{
    [DbContext(typeof(AccountDbContext))]
    [Migration("20231230204314_TempMigration_MetFodYyMX")]
    partial class TempMigration_MetFodYyMX
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Accounts.Domain.Entities.AccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("discriminator").HasValue("AccountEntity");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Accounts.Domain.Entities.GoogleAccountEntity", b =>
                {
                    b.HasBaseType("Accounts.Domain.Entities.AccountEntity");

                    b.HasDiscriminator().HasValue("google");
                });

            modelBuilder.Entity("Accounts.Domain.Entities.PasswordAccountEntity", b =>
                {
                    b.HasBaseType("Accounts.Domain.Entities.AccountEntity");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("passwordemail");
                });
#pragma warning restore 612, 618
        }
    }
}
