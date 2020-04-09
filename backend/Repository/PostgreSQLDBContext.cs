using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Repository
{
    public partial class PostgreSQLDBContext : DbContext
    {
        public PostgreSQLDBContext()
        {
        }

        public PostgreSQLDBContext(DbContextOptions<PostgreSQLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupTypes> GroupTypes { get; set; }
        public virtual DbSet<Infoshop> Infoshop { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("host=localhost;Database=dudevs;user id=dudevs;Password=dudevs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupTypes>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("group_types_pkey");

                entity.ToTable("group_types", "supermarket");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Infoshop>(entity =>
            {
                entity.HasKey(e => new { e.Idshop, e.Groupname, e.Unixtime })
                    .HasName("infoshop_pkey");

                entity.ToTable("infoshop", "supermarket");

                entity.Property(e => e.Idshop)
                    .HasColumnName("idshop")
                    .HasMaxLength(250);

                entity.Property(e => e.Groupname)
                    .HasColumnName("groupname")
                    .HasMaxLength(250);

                entity.Property(e => e.Unixtime)
                    .HasColumnName("unixtime")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.Negatives)
                    .HasColumnName("negatives")
                    .HasColumnType("numeric(4,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Positives)
                    .HasColumnName("positives")
                    .HasColumnType("numeric(4,0)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.GroupnameNavigation)
                    .WithMany(p => p.Infoshop)
                    .HasForeignKey(d => d.Groupname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("groupname_group_types");

                entity.HasOne(d => d.IdshopNavigation)
                    .WithMany(p => p.Infoshop)
                    .HasForeignKey(d => d.Idshop)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idshop_shop");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("shop", "supermarket");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(40);

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(250);

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("numeric(8,6)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("numeric(9,6)");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
