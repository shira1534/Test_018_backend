using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dal.Models
{
    public partial class ClothesContext : DbContext
    {
        public ClothesContext()
        {
        }

        public ClothesContext(DbContextOptions<ClothesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-73P1GSA\\SQLEXPRESS ;Database= Clothes;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Category");

            //    entity.Property(e => e.CategoryId)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Name)
            //        .HasMaxLength(50)
            //        .HasColumnName("name");
            //});

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdClothe).HasColumnName("id_clothe");

                entity.Property(e => e.Routing).HasColumnName("routing");

                entity.HasOne(d => d.IdClotheNavigation)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.IdClothe)
                    .HasConstraintName("FK_photos_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Mail).HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
