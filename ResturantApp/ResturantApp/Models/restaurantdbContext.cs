using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResturantApp.Models
{
    public partial class restaurantdbContext : DbContext
    {
        public bool IgnoreFilter { get; set; }

        public restaurantdbContext()
        {
        }

        public restaurantdbContext(DbContextOptions<restaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MenuCustomer> MenuCustomers { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenus { get; set; }
        public virtual DbSet<CsvView> CsvViews { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IHMTQQ4;Database=restaurantdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CsvView>(entity =>
            {
                
                entity.HasNoKey();
                entity.ToTable("ViewCSV");
               
                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberOfOrderedCustomer)
                .HasColumnName("NumberOfOrderedCustomer");

                entity.Property(e => e.ProfitInUsd)
                .HasColumnName("ProfitInUsd");

                entity.Property(e => e.ProfitInNis)
                .HasColumnName("ProfitInNis");

                entity.Property(e => e.TheBestSellingMeal)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MostPurchasedCustomer)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.CraetedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Archived).HasColumnType("SMALLINT");
            });

            modelBuilder.Entity<MenuCustomer>(entity =>
            {

                entity.ToTable("MenuCustomer");

                entity.Property(e => e.Cid).HasColumnName("CId");

                entity.Property(e => e.CraetedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Mid).HasColumnName("MId");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MenuCustome__CId__3E52440B");

                entity.HasOne(d => d.MidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MenuCustome__MId__3D5E1FD2");
                entity.Property(e => e.Archived).HasColumnType("SMALLINT");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurant");

                entity.Property(e => e.CraetedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.Archived).HasColumnType("SMALLINT");
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.ToTable("restaurantMenu");

                entity.Property(e => e.CraetedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rid).HasColumnName("RId");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.RestaurantMenus)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__restaurantM__RId__2F10007B");
                entity.Property(e => e.Archived).HasColumnType("SMALLINT");
            });
            modelBuilder.Entity<Customer>().HasQueryFilter(a => !a.Archived || IgnoreFilter);
            modelBuilder.Entity<MenuCustomer>().HasQueryFilter(a => !a.Archived || IgnoreFilter);
            modelBuilder.Entity<Restaurant>().HasQueryFilter(a => !a.Archived || IgnoreFilter);
            modelBuilder.Entity<RestaurantMenu>().HasQueryFilter(a => !a.Archived || IgnoreFilter);


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
