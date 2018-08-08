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
    [DbContext(typeof(BiesterlanDbContext))]
    [Migration("20180807101131_Images")]
    partial class Images
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BiesterlanOrders.Models.Article", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArticleGroup");

                    b.Property<string>("ImageName")
                        .HasMaxLength(250);

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("SalesPrice");

                    b.HasKey("ID");

                    b.HasIndex("Name");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("BiesterlanOrders.Models.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BiesterlanOrders.Models.Orderline", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<Guid>("ArticleID");

                    b.Property<string>("ArticleName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid>("OrderID");

                    b.Property<decimal>("SalesPrice");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("Orderlines");
                });

            modelBuilder.Entity("BiesterlanOrders.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("ImageName")
                        .HasMaxLength(250);

                    b.Property<string>("ImagePath")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BiesterlanOrders.Models.Order", b =>
                {
                    b.HasOne("BiesterlanOrders.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BiesterlanOrders.Models.Orderline", b =>
                {
                    b.HasOne("BiesterlanOrders.Models.Order", "Order")
                        .WithMany("Orderlines")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}