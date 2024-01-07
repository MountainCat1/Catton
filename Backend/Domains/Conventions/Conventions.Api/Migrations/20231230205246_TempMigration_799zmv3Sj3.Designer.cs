﻿// <auto-generated />
using System;
using Conventions.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Conventions.Api.Migrations
{
    [DbContext(typeof(ConventionDomainDbContext))]
    [Migration("20231230205246_TempMigration_799zmv3Sj3")]
    partial class TempMigration_799zmv3Sj3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Conventions.Domain.Entities.Attendee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountAvatarUri")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountUsername")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConventionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ConventionId");

                    b.ToTable("Attendees", (string)null);
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Convention", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Conventions", (string)null);
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Organizer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountAvatarUri")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountUsername")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConventionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ConventionId");

                    b.ToTable("Organizers", (string)null);
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttendeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketTemplateId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AttendeeId");

                    b.HasIndex("TicketTemplateId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Conventions.Domain.Entities.TicketTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Avaliable")
                        .HasColumnType("bit");

                    b.Property<string>("ConventionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("LastEditAuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ConventionId");

                    b.ToTable("TicketTemplates", (string)null);
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Attendee", b =>
                {
                    b.HasOne("Conventions.Domain.Entities.Convention", null)
                        .WithMany("Attendees")
                        .HasForeignKey("ConventionId");
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Organizer", b =>
                {
                    b.HasOne("Conventions.Domain.Entities.Convention", null)
                        .WithMany("Organizers")
                        .HasForeignKey("ConventionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("Conventions.Domain.Entities.Attendee", null)
                        .WithMany("Tickets")
                        .HasForeignKey("AttendeeId");

                    b.HasOne("Conventions.Domain.Entities.TicketTemplate", "TicketTemplate")
                        .WithMany()
                        .HasForeignKey("TicketTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TicketTemplate");
                });

            modelBuilder.Entity("Conventions.Domain.Entities.TicketTemplate", b =>
                {
                    b.HasOne("Conventions.Domain.Entities.Convention", null)
                        .WithMany("TicketTemplates")
                        .HasForeignKey("ConventionId");
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Attendee", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Conventions.Domain.Entities.Convention", b =>
                {
                    b.Navigation("Attendees");

                    b.Navigation("Organizers");

                    b.Navigation("TicketTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}