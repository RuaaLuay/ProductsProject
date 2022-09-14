using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace store.Model
{
    public partial class storeContext : DbContext
    {
        public storeContext()
        {
        }

        public storeContext(DbContextOptions<storeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IHMTQQ4;Database=store;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Last_updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Last_updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubCategoryId).HasColumnName("subCategory_id");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__item__subCategor__34C8D9D1");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("subCategory");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Last_updated_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__subCatego__categ__300424B4");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                      .IsUnique();

                entity.HasIndex(e => e.Email, "Email_UNIQUE")
                      .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int unsigned");

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasColumnType("varchar(255)")
                      .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasColumnType("varchar(255)")
                      .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasColumnType("varchar(255)");

                entity.Property(e => e.Image)
                      .IsRequired()
                      .HasColumnType("varchar(255)")
                      .HasDefaultValueSql("('')");

                entity.Property(e => e.Password)
                      .IsRequired()
                      .HasColumnType("varchar(255)");

                entity.Property(e => e.ConfirmPassword)
                      .IsRequired()
                      .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedDateUTC)
                      .HasColumnName("CraetedDate")
                      .HasColumnType("DateTime")
                      .HasDefaultValueSql("GetDate()");

                entity.Property(e => e.UpdatedDateUTC)
                      .HasColumnName("UpdatedDate")
                      .HasColumnType("DateTime")
                      .ValueGeneratedOnAddOrUpdate()
                      .HasDefaultValueSql("GetDate()");

                entity.Property(e => e.Archived).HasColumnType("tinyint(3)");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
