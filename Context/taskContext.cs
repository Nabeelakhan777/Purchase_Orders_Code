
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Purchase_Order.Models;
using Purchase_Order.Models.DbDTOs.Responses;

namespace Purchase_Order.Context;

public partial class taskContext : DbContext
{
    private readonly string Connectionstring;
    public taskContext(IConfiguration configuration)
    {
        Connectionstring = configuration.GetConnectionString("TaskConnection");
    }

    public taskContext(DbContextOptions<taskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMaterial> TblMaterials { get; set; }

    public virtual DbSet<TblPurDetail> TblPurDetails { get; set; }

    public virtual DbSet<TblPurHeader> TblPurHeaders { get; set; }

    public virtual DbSet<TblVendor> TblVendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Connectionstring);


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMaterial>(entity =>
        {
            entity.HasKey(e => e.MatId);

            entity.ToTable("tblMaterial");

            entity.Property(e => e.MatId).HasColumnName("matID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.MatDesc)
                .HasMaxLength(200)
                .HasColumnName("matDesc");
            entity.Property(e => e.MatRef)
                .HasMaxLength(50)
                .HasColumnName("matRef");
            entity.Property(e => e.MatStandardCost)
                .HasColumnType("money")
                .HasColumnName("matStandardCost");
            entity.Property(e => e.MatUom)
                .HasMaxLength(50)
                .HasColumnName("matUOM");
        });

        modelBuilder.Entity<TblPurDetail>(entity =>
        {
            entity.HasKey(e => e.PurDetailId);

            entity.ToTable("tblPurDetail");

            entity.Property(e => e.PurDetailId).HasColumnName("purDetailID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PurAmountExclVat)
                .HasColumnType("money")
                .HasColumnName("purAmountExclVAT");
            entity.Property(e => e.PurAmountInclVat)
                .HasColumnType("money")
                .HasColumnName("purAmountInclVAT");
            entity.Property(e => e.PurAmountVat)
                .HasColumnType("money")
                .HasColumnName("purAmountVAT");
            entity.Property(e => e.PurExpectedArrivalDate)
                .HasColumnType("datetime")
                .HasColumnName("purExpectedArrivalDate");
            entity.Property(e => e.PurHeaderId).HasColumnName("purHeaderID");
            entity.Property(e => e.PurMatId).HasColumnName("purMatID");
            entity.Property(e => e.PurQty).HasColumnName("purQty");
            entity.Property(e => e.PurUnitPrice)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("purUnitPrice");
            entity.Property(e => e.PurUoM).HasColumnName("purUoM");

            entity.HasOne(d => d.PurHeader).WithMany(p => p.TblPurDetails)
                .HasForeignKey(d => d.PurHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPurDetail_tblPurHeader");

            entity.HasOne(d => d.PurMat).WithMany(p => p.TblPurDetails)
                .HasForeignKey(d => d.PurMatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPurDetail_tblMaterial");
        });

        modelBuilder.Entity<TblPurHeader>(entity =>
        {
            entity.HasKey(e => e.PurHeaderId);

            entity.ToTable("tblPurHeader");

            entity.Property(e => e.PurHeaderId).HasColumnName("purHeaderID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.PurAmountExclVat)
                .HasColumnType("money")
                .HasColumnName("purAmountExclVAT");
            entity.Property(e => e.PurAmountInclVat)
                .HasColumnType("money")
                .HasColumnName("purAmountInclVAT");
            entity.Property(e => e.PurAmountVat)
                .HasColumnType("money")
                .HasColumnName("purAmountVAT");
            entity.Property(e => e.PurCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("purCreatedDate");
            entity.Property(e => e.PurExpectedArrivalDate)
                .HasColumnType("datetime")
                .HasColumnName("purExpectedArrivalDate");
            entity.Property(e => e.PurReference)
                .HasMaxLength(50)
                .HasColumnName("purReference");
            entity.Property(e => e.PurSourceReference)
                .HasMaxLength(50)
                .HasColumnName("purSourceReference");
            entity.Property(e => e.VendorId).HasColumnName("vendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblPurHeaders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPurHeader_tblVendor");
        });

        modelBuilder.Entity<TblVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId);

            entity.ToTable("tblVendor");

            entity.Property(e => e.VendorId).HasColumnName("vendorID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Contact).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.ExtAccNo).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(10);
            entity.Property(e => e.RegNo).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(100);
            entity.Property(e => e.Suburb).HasMaxLength(50);
            entity.Property(e => e.Tel).HasMaxLength(50);
            entity.Property(e => e.Vatno)
                .HasMaxLength(50)
                .HasColumnName("VATNo");
            entity.Property(e => e.Vatperc)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("VATPerc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
