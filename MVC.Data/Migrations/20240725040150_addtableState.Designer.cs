﻿// <auto-generated />
using System;
using MVC.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240725040150_addtableState")]
    partial class addtableState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC.Data.Entity.CategoryEntity", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"));

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdCategory");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("MVC.Data.Entity.ImageProductEntity", b =>
                {
                    b.Property<int>("IdImageProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdImageProduct"));

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdImageProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("ImageProduct");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceDetailEntity", b =>
                {
                    b.Property<int>("IdInvoiceDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvoiceDetail"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("IdInvoice")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdInvoiceDetail");

                    b.HasIndex("IdInvoice");

                    b.HasIndex("IdProduct");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceEntity", b =>
                {
                    b.Property<int>("IdInvoice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvoice"));

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdInvoiceType")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdInvoice");

                    b.HasIndex("IdInvoiceType");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceTypeEntity", b =>
                {
                    b.Property<int>("IdInvoiceType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInvoiceType"));

                    b.Property<string>("InvoiceType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdInvoiceType");

                    b.ToTable("InvoiceType");
                });

            modelBuilder.Entity("MVC.Data.Entity.ProductEntity", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegister")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdState");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("MVC.Data.Entity.StateEntity", b =>
                {
                    b.Property<int>("IdState")
                        .HasColumnType("int");

                    b.Property<string>("Ambit")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdState");

                    b.ToTable("State");
                });

            modelBuilder.Entity("MVC.Data.Entity.ImageProductEntity", b =>
                {
                    b.HasOne("MVC.Data.Entity.ProductEntity", "ProductEntity")
                        .WithMany("ImageProductEntities")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductEntity");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceDetailEntity", b =>
                {
                    b.HasOne("MVC.Data.Entity.InvoiceEntity", "InvoiceEntity")
                        .WithMany("InvoiceDetailEntities")
                        .HasForeignKey("IdInvoice")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Data.Entity.ProductEntity", "ProductEntity")
                        .WithMany("InvoiceDetailEntities")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceEntity");

                    b.Navigation("ProductEntity");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceEntity", b =>
                {
                    b.HasOne("MVC.Data.Entity.InvoiceTypeEntity", "InvoiceTypeEntity")
                        .WithMany("InvoiceEntities")
                        .HasForeignKey("IdInvoiceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvoiceTypeEntity");
                });

            modelBuilder.Entity("MVC.Data.Entity.ProductEntity", b =>
                {
                    b.HasOne("MVC.Data.Entity.CategoryEntity", "CategoryEntity")
                        .WithMany("ProductEntities")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC.Data.Entity.StateEntity", "StateEntity")
                        .WithMany("ProductEntities")
                        .HasForeignKey("IdState")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryEntity");

                    b.Navigation("StateEntity");
                });

            modelBuilder.Entity("MVC.Data.Entity.CategoryEntity", b =>
                {
                    b.Navigation("ProductEntities");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceEntity", b =>
                {
                    b.Navigation("InvoiceDetailEntities");
                });

            modelBuilder.Entity("MVC.Data.Entity.InvoiceTypeEntity", b =>
                {
                    b.Navigation("InvoiceEntities");
                });

            modelBuilder.Entity("MVC.Data.Entity.ProductEntity", b =>
                {
                    b.Navigation("ImageProductEntities");

                    b.Navigation("InvoiceDetailEntities");
                });

            modelBuilder.Entity("MVC.Data.Entity.StateEntity", b =>
                {
                    b.Navigation("ProductEntities");
                });
#pragma warning restore 612, 618
        }
    }
}