﻿// <auto-generated />
using System;
using MicroServiceTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MicroServiceTest.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230331180113_Init_1")]
    partial class Init_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("MicroServiceTest.Models.ClassRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("MicroServiceTest.Models.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClassRoomId")
                        .HasColumnType("TEXT");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassRoomId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("MicroServiceTest.Models.StudentProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FatherName")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MotherName")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentProfile");
                });

            modelBuilder.Entity("MicroServiceTest.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.Property<Guid>("StudentsStudentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentsStudentId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("MicroServiceTest.Models.Student", b =>
                {
                    b.HasOne("MicroServiceTest.Models.ClassRoom", "ClassRoom")
                        .WithMany("Students")
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");
                });

            modelBuilder.Entity("MicroServiceTest.Models.StudentProfile", b =>
                {
                    b.HasOne("MicroServiceTest.Models.Student", "Student")
                        .WithOne("StudentProfile")
                        .HasForeignKey("MicroServiceTest.Models.StudentProfile", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.HasOne("MicroServiceTest.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsStudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MicroServiceTest.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicroServiceTest.Models.ClassRoom", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("MicroServiceTest.Models.Student", b =>
                {
                    b.Navigation("StudentProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
