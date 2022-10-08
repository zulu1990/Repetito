﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repetito.Infrastructure.Persistance;

#nullable disable

namespace Repetito.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PupilTeacher", b =>
                {
                    b.Property<Guid>("PupilsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeachersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PupilsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("PupilTeacher");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.CalendarEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PupilId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PupilId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CalendarEntries");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Feedback", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Pupil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pupils");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("PupilTeacher", b =>
                {
                    b.HasOne("Repetito.Domain.Entities.Pupil", null)
                        .WithMany()
                        .HasForeignKey("PupilsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repetito.Domain.Entities.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repetito.Domain.Entities.CalendarEntry", b =>
                {
                    b.HasOne("Repetito.Domain.Entities.Pupil", null)
                        .WithMany("Calendar")
                        .HasForeignKey("PupilId");

                    b.HasOne("Repetito.Domain.Entities.Teacher", null)
                        .WithMany("CalendarEntries")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Feedback", b =>
                {
                    b.HasOne("Repetito.Domain.Entities.Teacher", null)
                        .WithMany("Feedbacks")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Pupil", b =>
                {
                    b.Navigation("Calendar");
                });

            modelBuilder.Entity("Repetito.Domain.Entities.Teacher", b =>
                {
                    b.Navigation("CalendarEntries");

                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
