using System;
using System.Collections.Generic;
using Core_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Project.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<FoodGroup> FoodGroups { get; set; }

    public virtual DbSet<FoodItem> FoodItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }



    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=FoodDatabase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany);

            entity.ToTable("COMPANY");

            entity.Property(e => e.IdCompany)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnName("ID_COMPANY");

            entity.Property(e => e.Label)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABEL");
        });

        modelBuilder.Entity<FoodGroup>(entity =>
        {
            entity.HasKey(e => e.IdFoodGroup);

            entity.ToTable("FOOD_GROUP");

            entity.Property(e => e.IdFoodGroup)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnName("ID_FOOD_GROUP");

            entity.Property(e => e.Label)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABEL");
        });

        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.IdFoodItem);

            entity.ToTable("FOOD_ITEM");

            entity.HasIndex(e => e.IdFoodGroup, "HAS_FOOD_GROUP_FK");

            entity.Property(e => e.IdFoodItem)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnName("ID_FOOD_ITEM");

            

            entity.Property(e => e.IdFoodGroup).HasColumnName("ID_FOOD_GROUP");

            entity.Property(e => e.Label)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABEL");

            

            entity.HasOne(d => d.IdFoodGroupNavigation).WithMany(p => p.FoodItems)
                .HasForeignKey(d => d.IdFoodGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FOOD_ITE_HAS_FOOD__FOOD_GRO");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("PRODUCT");

            entity.HasIndex(e => e.IdCompany, "BELONG_TO_COMPANY_FK");

            entity.HasIndex(e => e.IdFoodItem, "RELATED_TO_FOOD_ITEM_FK");

            entity.Property(e => e.IdProduct)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnName("ID_PRODUCT");

            entity.Property(e => e.IdCompany).HasColumnName("ID_COMPANY");

            entity.Property(e => e.IdFoodItem).HasColumnName("ID_FOOD_ITEM");

            entity.Property(e => e.Label)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LABEL");

            entity.Property(e => e.Prix)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRIX");


            entity.Property(e => e.CarbohydratG)
                .IsUnicode(false)
                .HasColumnName("CARBOHYDRAT_G");

            entity.Property(e => e.EnergyKcal)
                .IsUnicode(false)
                .HasColumnName("ENERGY_KCAL");

            entity.Property(e => e.FatG)
                .IsUnicode(false)
                .HasColumnName("FAT_G");

            entity.Property(e => e.ProteinG)
                .IsUnicode(false)
                .HasColumnName("PROTEIN_G");

            entity.Property(e => e.SodiumMg)
                .IsUnicode(false)
                .HasColumnName("SODIUM_MG");

            entity.Property(e => e.SugarG)
                .IsUnicode(false)
                .HasColumnName("SUGAR_G");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_BELONG_TO_COMPANY");

            entity.HasOne(d => d.IdFoodItemNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdFoodItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_RELATED_T_FOOD_ITE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("USER");

            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd() // Auto-increment
                .HasColumnName("ID_USER");

            entity.Property(e => e.IsAdmin).HasColumnName("IS_ADMIN");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");


            // New foreign key for Company
            entity.Property(e => e.IdCompany).HasColumnName("ID_COMPANY");

            entity.HasOne(d => d.Company)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER_COMPANY");
        });

     

        modelBuilder.Entity<FoodGroup>().HasData(
            new FoodGroup { IdFoodGroup = 1, Label = "Vegetables" },
            new FoodGroup { IdFoodGroup = 2, Label = "Fruit" },
            new FoodGroup { IdFoodGroup = 3, Label = "Meat" },
            new FoodGroup { IdFoodGroup = 4, Label = "Chicken" },
            new FoodGroup { IdFoodGroup = 5, Label = "Fish" }
        );


        modelBuilder.Entity<Company>().HasData(
            new Company { IdCompany = 6, Label = "Fresh Farm Produce" },
            new Company { IdCompany = 1, Label = "RAYAN" },
            new Company { IdCompany = 2, Label = "Healthy Snacks Inc." },
            new Company { IdCompany = 3, Label = "Meat Lovers Co." },
            new Company { IdCompany = 4, Label = "Poultry Delight" },
            new Company { IdCompany = 5, Label = "Ocean's Finest Seafood" }
        );

        // Seed Data
        modelBuilder.Entity<User>().HasData(
            new User { IdUser = 1, Username = "admin", Password = "admin", IsAdmin = true, IdCompany = 1 },
            new User { IdUser = 2, Username = "testUser", Password = "2846", IsAdmin = false, IdCompany = 1 }
        );
        OnModelCreatingPartial(modelBuilder);
    }



    public IQueryable<FoodItem> GetFoodItemsWithNavigation()
    {
        return FoodItems
            .Include(f => f.IdFoodGroupNavigation)
            .Include(f => f.Products)
            .ThenInclude(p => p.IdCompanyNavigation);
    }

    public IQueryable<Product> GetProductsWithNavigation()
    {
        return Products
            .Include(p => p.IdCompanyNavigation)
            .Include(p => p.IdFoodItemNavigation);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
