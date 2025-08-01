﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentRestApi.Models;

#nullable disable

namespace StudentRestApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentRestApi.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            DateOfBirth = new DateTime(1992, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "ernestoSalmantino@gmail.com",
                            FirstName = "Ernesto",
                            Gender = 0,
                            LastName = "Salmantino",
                            PhotoPath = "Images/Ernesto.png"
                        },
                        new
                        {
                            StudentId = 2,
                            DateOfBirth = new DateTime(1994, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "DeboraSalmantino@gmail.com",
                            FirstName = "Debora",
                            Gender = 1,
                            LastName = "Fuchibol",
                            PhotoPath = "Images/Debora.png"
                        },
                        new
                        {
                            StudentId = 3,
                            DateOfBirth = new DateTime(1970, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "JaviAvila@gmail.com",
                            FirstName = "Javi",
                            Gender = 0,
                            LastName = "Avila",
                            PhotoPath = "Images/Javi.png"
                        },
                        new
                        {
                            StudentId = 4,
                            DateOfBirth = new DateTime(1992, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 0,
                            Email = "NoeliaSalmantina@gmail.com",
                            FirstName = "Noelia",
                            Gender = 1,
                            LastName = "Salmantina",
                            PhotoPath = "Images/Noelia.png"
                        },
                        new
                        {
                            StudentId = 5,
                            DateOfBirth = new DateTime(1990, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentId = 1,
                            Email = "LuisSalmantino@gmail.com",
                            FirstName = "Luis",
                            Gender = 0,
                            LastName = "Salmantino",
                            PhotoPath = "Images/Luis.png"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
