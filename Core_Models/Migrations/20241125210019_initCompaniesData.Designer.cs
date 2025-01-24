﻿// <auto-generated />
using Core_Project.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core_Project.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241125210019_initCompaniesData")]
    partial class initCompaniesData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Core_Project.Models.Company", b =>
                {
                    b.Property<int>("IdCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_COMPANY");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("LABEL");

                    b.HasKey("IdCompany");

                    b.ToTable("COMPANY", (string)null);

                    b.HasData(
                        new
                        {
                            IdCompany = 1,
                            Label = "Fresh Farm Produce"
                        },
                        new
                        {
                            IdCompany = 2,
                            Label = "Healthy Snacks Inc."
                        },
                        new
                        {
                            IdCompany = 3,
                            Label = "Meat Lovers Co."
                        },
                        new
                        {
                            IdCompany = 4,
                            Label = "Poultry Delight"
                        },
                        new
                        {
                            IdCompany = 5,
                            Label = "Ocean's Finest Seafood"
                        });
                });

            modelBuilder.Entity("Core_Project.Models.FoodGroup", b =>
                {
                    b.Property<int>("IdFoodGroup")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_FOOD_GROUP");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("LABEL");

                    b.HasKey("IdFoodGroup");

                    b.ToTable("FOOD_GROUP", (string)null);

                    b.HasData(
                        new
                        {
                            IdFoodGroup = 1,
                            Label = "Vegetables"
                        },
                        new
                        {
                            IdFoodGroup = 2,
                            Label = "Fruit"
                        },
                        new
                        {
                            IdFoodGroup = 3,
                            Label = "Meat"
                        },
                        new
                        {
                            IdFoodGroup = 4,
                            Label = "Chicken"
                        },
                        new
                        {
                            IdFoodGroup = 5,
                            Label = "Fish"
                        });
                });

            modelBuilder.Entity("Core_Project.Models.FoodItem", b =>
                {
                    b.Property<int>("IdFoodItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_FOOD_ITEM");

                    b.Property<string>("CarbohydratG")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("CARBOHYDRAT_G");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EnergyKcal")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("ENERGY_KCAL");

                    b.Property<string>("FatG")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("FAT_G");

                    b.Property<int>("IdFoodGroup")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_FOOD_GROUP");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("LABEL");

                    b.Property<string>("ProteinG")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("PROTEIN_G");

                    b.Property<string>("SodiumMg")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("SODIUM_MG");

                    b.Property<string>("SugarG")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("SUGAR_G");

                    b.HasKey("IdFoodItem");

                    b.HasIndex(new[] { "IdFoodGroup" }, "HAS_FOOD_GROUP_FK");

                    b.ToTable("FOOD_ITEM", (string)null);
                });

            modelBuilder.Entity("Core_Project.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PRODUCT");

                    b.Property<int>("IdCompany")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_COMPANY");

                    b.Property<int>("IdFoodItem")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_FOOD_ITEM");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("LABEL");

                    b.Property<decimal>("Prix")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PRIX");

                    b.HasKey("IdProduct");

                    b.HasIndex(new[] { "IdCompany" }, "BELONG_TO_COMPANY_FK");

                    b.HasIndex(new[] { "IdFoodItem" }, "RELATED_TO_FOOD_ITEM_FK");

                    b.ToTable("PRODUCT", (string)null);
                });

            modelBuilder.Entity("Core_Project.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_USER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IS_ADMIN");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("USERNAME");

                    b.HasKey("IdUser");

                    b.ToTable("USER", (string)null);

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            IsAdmin = true,
                            Password = "admin",
                            Username = "admin"
                        },
                        new
                        {
                            IdUser = 2,
                            IsAdmin = false,
                            Password = "2846",
                            Username = "testUser"
                        });
                });

            modelBuilder.Entity("Core_Project.Models.FoodItem", b =>
                {
                    b.HasOne("Core_Project.Models.FoodGroup", "IdFoodGroupNavigation")
                        .WithMany("FoodItems")
                        .HasForeignKey("IdFoodGroup")
                        .IsRequired()
                        .HasConstraintName("FK_FOOD_ITE_HAS_FOOD__FOOD_GRO");

                    b.Navigation("IdFoodGroupNavigation");
                });

            modelBuilder.Entity("Core_Project.Models.Product", b =>
                {
                    b.HasOne("Core_Project.Models.Company", "IdCompanyNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdCompany")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCT_BELONG_TO_COMPANY");

                    b.HasOne("Core_Project.Models.FoodItem", "IdFoodItemNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdFoodItem")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCT_RELATED_T_FOOD_ITE");

                    b.Navigation("IdCompanyNavigation");

                    b.Navigation("IdFoodItemNavigation");
                });

            modelBuilder.Entity("Core_Project.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core_Project.Models.FoodGroup", b =>
                {
                    b.Navigation("FoodItems");
                });

            modelBuilder.Entity("Core_Project.Models.FoodItem", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
