using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PostApi.Models
{
    public partial class PO_DBContext : DbContext
    {
        public PO_DBContext()
        {
        }

        public PO_DBContext(DbContextOptions<PO_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LetterBag> LetterBags { get; set; }
        public virtual DbSet<Parcel> Parcels { get; set; }
        public virtual DbSet<ParcelBag> ParcelBags { get; set; }
        public virtual DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PO_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LetterBag>(entity =>
            {
                entity.HasKey(e => e.LbagId)
                    .HasName("PK__LetterBa__9901299B1AF5CD33");

                entity.ToTable("LetterBag");

                entity.HasIndex(e => e.BagNumber, "UQ__LetterBa__6DB6962428013E4C")
                    .IsUnique();

                entity.Property(e => e.LbagId).HasColumnName("LBagId");

                entity.Property(e => e.BagNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('LBAG'+right('00000000'+CONVERT([varchar](8),[LBagId]),(10)))", true);

                entity.Property(e => e.FkShipmentId).HasColumnName("FK_ShipmentId");

                entity.HasOne(d => d.FkShipment)
                    .WithMany(p => p.LetterBags)
                    .HasForeignKey(d => d.FkShipmentId)
                    .HasConstraintName("FK__LetterBag__FK_Sh__3DE82FB7");
            });

            modelBuilder.Entity<Parcel>(entity =>
            {
                entity.ToTable("Parcel");

                entity.HasIndex(e => e.ParcelNumber, "UQ__Parcel__4CFD427DCDB5D1D0")
                    .IsUnique();

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FkPbagId).HasColumnName("FK_PBagId");

                entity.Property(e => e.ParcelNumber)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('AB'+right(('00000'+CONVERT([varchar](5),[ParcelId]))+'CD',(7)))", true);

                entity.Property(e => e.RecipientName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.FkPbag)
                    .WithMany(p => p.Parcels)
                    .HasForeignKey(d => d.FkPbagId)
                    .HasConstraintName("FK__Parcel__FK_PBagI__3A179ED3");
            });

            modelBuilder.Entity<ParcelBag>(entity =>
            {
                entity.HasKey(e => e.PbagId)
                    .HasName("PK__ParcelBa__ADE3CE82914FDE7C");

                entity.ToTable("ParcelBag");

                entity.HasIndex(e => e.BagNumber, "UQ__ParcelBa__6DB696242AFE0E3E")
                    .IsUnique();

                entity.Property(e => e.PbagId).HasColumnName("PBagId");

                entity.Property(e => e.BagNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('PBAG'+right('00000000'+CONVERT([varchar](8),[PBagId]),(10)))", true);

                entity.Property(e => e.FkShipmentId).HasColumnName("FK_ShipmentId");

                entity.HasOne(d => d.FkShipment)
                    .WithMany(p => p.ParcelBags)
                    .HasForeignKey(d => d.FkShipmentId)
                    .HasConstraintName("FK__ParcelBag__FK_Sh__36470DEF");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.HasIndex(e => e.ShipmentNumber, "UQ__Shipment__E9244DF5FA8D5114")
                    .IsUnique();

                entity.Property(e => e.Airport)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.FlightDate).HasColumnType("date");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ShipmentNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasComputedColumnSql("('ABC-'+right('00000'+CONVERT([varchar](5),[ShipmentId]),(7)))", true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
