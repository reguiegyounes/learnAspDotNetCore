﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using learnAspDotNetCore.Models;

namespace learnAspDotNetCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("learnAspDotNetCore.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Departement")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Empployees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Departement = 5,
                            Email = "ali@email.com",
                            ImageUrl = "/Images/1.jpg",
                            Name = "ali"
                        },
                        new
                        {
                            Id = 2,
                            Departement = 4,
                            Email = "youcef@email.com",
                            ImageUrl = "/Images/2.jpg",
                            Name = "youcef"
                        },
                        new
                        {
                            Id = 3,
                            Departement = 0,
                            Email = "mohamed@email.com",
                            ImageUrl = "/Images/3.jpg",
                            Name = "mohamed"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
