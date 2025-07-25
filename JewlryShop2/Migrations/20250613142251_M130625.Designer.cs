﻿// <auto-generated />
using JewlryShop2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewlryShop2.Migrations
{
    [DbContext(typeof(JewelryContext))]
    [Migration("20250613142251_M130625")]
    partial class M130625
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JewlryShop2.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("JewlryShop2.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ClubMembership")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("JewlryShop2.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int>("JewelryID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartID");

                    b.HasIndex("JewelryID");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("JewlryShop2.Models.Jewelry", b =>
                {
                    b.Property<int>("JewelryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JewelryID"));

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JewelryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("JewelryID");

                    b.ToTable("Jewelrys");
                });

            modelBuilder.Entity("JewlryShop2.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("JewelryID")
                        .HasColumnType("int");

                    b.Property<string>("Rewiew")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarAmount")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("JewelryID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("JewlryShop2.Models.Cart", b =>
                {
                    b.HasOne("JewlryShop2.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("JewlryShop2.Models.Item", b =>
                {
                    b.HasOne("JewlryShop2.Models.Cart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewlryShop2.Models.Jewelry", "Jewelry")
                        .WithMany("Items")
                        .HasForeignKey("JewelryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Jewelry");
                });

            modelBuilder.Entity("JewlryShop2.Models.Review", b =>
                {
                    b.HasOne("JewlryShop2.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewlryShop2.Models.Jewelry", "Jewelry")
                        .WithMany("Reviews")
                        .HasForeignKey("JewelryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Jewelry");
                });

            modelBuilder.Entity("JewlryShop2.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("JewlryShop2.Models.Customer", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("JewlryShop2.Models.Jewelry", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
