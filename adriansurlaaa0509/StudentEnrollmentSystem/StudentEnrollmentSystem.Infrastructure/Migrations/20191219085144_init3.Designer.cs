﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentEnrollmentSystem.Infrastructure.Persistence;

namespace StudentEnrollmentSystem.Infrastructure.Migrations
{
    [DbContext(typeof(StudentEnrollmentSystemDbContext))]
    [Migration("20191219085144_init3")]
    partial class init3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.EnrollmentDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("enrollmentSemester")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enrollmentYear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EnrollmentDetails");
                });

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.StudentBasicInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudentAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentAge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentMiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentSubjects")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StudentSubjects");

                    b.ToTable("StudentBasicInfos");
                });

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.StudentSubjectList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("_enrollmentDetailsIDID")
                        .HasColumnType("int");

                    b.Property<int?>("_studentBasicInfoIDID")
                        .HasColumnType("int");

                    b.Property<int?>("_studentSubjectsIDID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("_enrollmentDetailsIDID");

                    b.HasIndex("_studentBasicInfoIDID");

                    b.HasIndex("_studentSubjectsIDID");

                    b.ToTable("StudentSubjectLists");
                });

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.StudentSubjects", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.StudentBasicInfo", b =>
                {
                    b.HasOne("StudentEnrollmentSystem.Domain.Entities.StudentSubjects", "_studentSubjects")
                        .WithMany()
                        .HasForeignKey("StudentSubjects");
                });

            modelBuilder.Entity("StudentEnrollmentSystem.Domain.Entities.StudentSubjectList", b =>
                {
                    b.HasOne("StudentEnrollmentSystem.Domain.Entities.EnrollmentDetails", "_enrollmentDetailsID")
                        .WithMany()
                        .HasForeignKey("_enrollmentDetailsIDID");

                    b.HasOne("StudentEnrollmentSystem.Domain.Entities.StudentBasicInfo", "_studentBasicInfoID")
                        .WithMany()
                        .HasForeignKey("_studentBasicInfoIDID");

                    b.HasOne("StudentEnrollmentSystem.Domain.Entities.StudentSubjects", "_studentSubjectsID")
                        .WithMany()
                        .HasForeignKey("_studentSubjectsIDID");
                });
#pragma warning restore 612, 618
        }
    }
}
