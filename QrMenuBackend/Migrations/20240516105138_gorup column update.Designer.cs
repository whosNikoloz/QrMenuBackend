﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QrMenuBackend.Data;

#nullable disable

namespace QrMenuBackend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240516105138_gorup column update")]
    partial class gorupcolumnupdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QrMenuBackend.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("QrMenuBackend.Models.OptionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Option_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(22, 5)
                        .HasColumnType("decimal(22,5)");

                    b.HasKey("Id");

                    b.HasIndex("Option_Id");

                    b.ToTable("OptionValues");
                });

            modelBuilder.Entity("QrMenuBackend.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description_Ka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Group_Id")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(22, 5)
                        .HasColumnType("decimal(22,5)");

                    b.HasKey("Id");

                    b.HasIndex("Group_Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QrMenuBackend.Models.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Ka")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("QrMenuBackend.Models.Option", b =>
                {
                    b.HasOne("QrMenuBackend.Models.Product", "Product")
                        .WithMany("Options")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("QrMenuBackend.Models.OptionValue", b =>
                {
                    b.HasOne("QrMenuBackend.Models.Option", "Option")
                        .WithMany("OptionValues")
                        .HasForeignKey("Option_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");
                });

            modelBuilder.Entity("QrMenuBackend.Models.Product", b =>
                {
                    b.HasOne("QrMenuBackend.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("Group_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("QrMenuBackend.Models.Option", b =>
                {
                    b.Navigation("OptionValues");
                });

            modelBuilder.Entity("QrMenuBackend.Models.Product", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("QrMenuBackend.Models.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
