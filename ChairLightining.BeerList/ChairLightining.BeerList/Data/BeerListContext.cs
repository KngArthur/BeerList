using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ChairLightining.BeerList.Data
{
    public partial class BeerListContext : DbContext
    {
        public BeerListContext()
        {
        }

        public BeerListContext(DbContextOptions<BeerListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BeerListing> BeerListings { get; set; }
        public virtual DbSet<BeerStyle> BeerStyles { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ChairLightining.BeerList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BeerListing>(entity =>
            {
                entity.ToTable("BeerListing");

                entity.Property(e => e.Abv).HasColumnName("ABV");

                entity.Property(e => e.BeerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Ibu).HasColumnName("IBU");

                entity.HasOne(d => d.BeerStyleNavigation)
                    .WithMany(p => p.BeerListings)
                    .HasForeignKey(d => d.BeerStyle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BeerListi__BeerT__4316F928");

                entity.HasOne(d => d.BreweryNavigation)
                    .WithMany(p => p.BeerListings)
                    .HasForeignKey(d => d.Brewery)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BeerListi__Brewe__4222D4EF");

                entity.HasOne(d => d.PackageTypeNavigation)
                    .WithMany(p => p.BeerListings)
                    .HasForeignKey(d => d.PackageType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BeerListi__Packa__440B1D61");
            });

            modelBuilder.Entity<BeerStyle>(entity =>
            {
                entity.ToTable("BeerStyle");

                entity.Property(e => e.BeerStyle1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BeerStyle");

                entity.Property(e => e.BeerStyleAbriviation)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("Brewery");

                entity.Property(e => e.BreweryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.HasKey(e => e.PackagingId)
                    .HasName("PK__tmp_ms_x__BD507F781CB1F005");

                entity.ToTable("PackageType");

                entity.Property(e => e.Packaging)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
