using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBFirst.Models
{
    public partial class DBFirstContext : DbContext
    {
        public bool ignoredFilter{ get; set; }
        public DBFirstContext()
        {
        }

        public DBFirstContext(DbContextOptions<DBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IHMTQQ4;Database=DBFirst;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Archived).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.LastUpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("Last_updated_at")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
           // object value = modelBuilder.Entity<User>().HasQueryFilter(a => !a.Archived || ignoredFilter);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
