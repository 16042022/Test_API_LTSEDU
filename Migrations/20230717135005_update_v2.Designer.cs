﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_API_LTSEDU.Model.Entity;

#nullable disable

namespace Test_API_LTSEDU.Migrations
{
    [DbContext(typeof(AppDbConext))]
    [Migration("20230717135005_update_v2")]
    partial class update_v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.ProductDetailPropertyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductDetailsId");

                    b.HasIndex("ProductsId");

                    b.HasIndex("PropertyDetailsId");

                    b.ToTable("ProductDetailPropertyDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.ProductDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductPropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("ShellPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.Properties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertySort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.PropertyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDetailCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropertyDetailDetail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PropertiesId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.ProductDetailPropertyDetails", b =>
                {
                    b.HasOne("Test_API_LTSEDU.Model.Entity.ProductDetails", "ProductDetails")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("ProductDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_API_LTSEDU.Model.Entity.Products", "Products")
                        .WithMany("Details")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_API_LTSEDU.Model.Entity.PropertyDetails", "PropertyDetails")
                        .WithMany("ProductDetailPropertyDetails")
                        .HasForeignKey("PropertyDetailsId")
                        .IsRequired();

                    b.Navigation("ProductDetails");

                    b.Navigation("Products");

                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.ProductDetails", b =>
                {
                    b.HasOne("Test_API_LTSEDU.Model.Entity.ProductDetails", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.Properties", b =>
                {
                    b.HasOne("Test_API_LTSEDU.Model.Entity.Products", "Products")
                        .WithMany("Properties")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.PropertyDetails", b =>
                {
                    b.HasOne("Test_API_LTSEDU.Model.Entity.Properties", "Properties")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.ProductDetails", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.Products", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.Properties", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("Test_API_LTSEDU.Model.Entity.PropertyDetails", b =>
                {
                    b.Navigation("ProductDetailPropertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
