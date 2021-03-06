﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("13990629100817_initial20")]
    partial class initial20
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entites.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<string>("BankComment");

                    b.Property<DateTime>("DateTimeCreate");

                    b.Property<DateTime>("DateTimeUpdate");

                    b.Property<int>("IdCity");

                    b.Property<int>("IdCompany");

                    b.Property<int>("IdOrder");

                    b.Property<int>("IdServant");

                    b.Property<int>("IdService");

                    b.Property<int>("IdSession");

                    b.Property<int>("IsSend");

                    b.Property<string>("RRN");

                    b.Property<string>("ServiceCode")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ShabaId")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("SpecialCode")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("StatusPay");

                    b.Property<string>("TrackingCode")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("TypeAccountPay");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Entites.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<DateTimeOffset?>("LastLoginDate");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("RoleId");

                    b.Property<Guid>("SecurityStamp");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entites.User", b =>
                {
                    b.HasOne("Entites.Role", "RoleUser")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
