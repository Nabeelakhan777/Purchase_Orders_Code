﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Purchase_Order.Context;

#nullable disable

namespace PurchaseOrder.Migrations
{
    [DbContext(typeof(taskContext))]
    [Migration("20231225120627_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Purchase_Order.Models.TblMaterial", b =>
                {
                    b.Property<int>("MatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("matID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastUpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MatDesc")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("matDesc");

                    b.Property<string>("MatRef")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("matRef");

                    b.Property<decimal>("MatStandardCost")
                        .HasColumnType("money")
                        .HasColumnName("matStandardCost");

                    b.Property<string>("MatUom")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("matUOM");

                    b.HasKey("MatId");

                    b.ToTable("tblMaterial", (string)null);
                });

            modelBuilder.Entity("Purchase_Order.Models.TblPurDetail", b =>
                {
                    b.Property<int>("PurDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("purDetailID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurDetailId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("PurAmountExclVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountExclVAT");

                    b.Property<decimal?>("PurAmountInclVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountInclVAT");

                    b.Property<decimal?>("PurAmountVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountVAT");

                    b.Property<DateTime?>("PurExpectedArrivalDate")
                        .HasColumnType("datetime")
                        .HasColumnName("purExpectedArrivalDate");

                    b.Property<int>("PurHeaderId")
                        .HasColumnType("int")
                        .HasColumnName("purHeaderID");

                    b.Property<int>("PurMatId")
                        .HasColumnType("int")
                        .HasColumnName("purMatID");

                    b.Property<int>("PurQty")
                        .HasColumnType("int")
                        .HasColumnName("purQty");

                    b.Property<decimal?>("PurUnitPrice")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("purUnitPrice");

                    b.Property<int?>("PurUoM")
                        .HasColumnType("int")
                        .HasColumnName("purUoM");

                    b.HasKey("PurDetailId");

                    b.HasIndex("PurHeaderId");

                    b.HasIndex("PurMatId");

                    b.ToTable("tblPurDetail", (string)null);
                });

            modelBuilder.Entity("Purchase_Order.Models.TblPurHeader", b =>
                {
                    b.Property<int>("PurHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("purHeaderID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurHeaderId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal?>("PurAmountExclVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountExclVAT");

                    b.Property<decimal?>("PurAmountInclVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountInclVAT");

                    b.Property<decimal?>("PurAmountVat")
                        .HasColumnType("money")
                        .HasColumnName("purAmountVAT");

                    b.Property<DateTime>("PurCreatedDate")
                        .HasColumnType("datetime")
                        .HasColumnName("purCreatedDate");

                    b.Property<DateTime?>("PurExpectedArrivalDate")
                        .HasColumnType("datetime")
                        .HasColumnName("purExpectedArrivalDate");

                    b.Property<string>("PurReference")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("purReference");

                    b.Property<string>("PurSourceReference")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("purSourceReference");

                    b.Property<int>("VendorId")
                        .HasColumnType("int")
                        .HasColumnName("vendorID");

                    b.HasKey("PurHeaderId");

                    b.HasIndex("VendorId");

                    b.ToTable("tblPurHeader", (string)null);
                });

            modelBuilder.Entity("Purchase_Order.Models.TblVendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("vendorID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendorId"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Contact")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ExtAccNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fax")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RegNo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Suburb")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tel")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Vatno")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VATNo");

                    b.Property<decimal?>("Vatperc")
                        .HasColumnType("decimal(6, 2)")
                        .HasColumnName("VATPerc");

                    b.HasKey("VendorId");

                    b.ToTable("tblVendor", (string)null);
                });

            modelBuilder.Entity("Purchase_Order.Models.TblPurDetail", b =>
                {
                    b.HasOne("Purchase_Order.Models.TblPurHeader", "PurHeader")
                        .WithMany("TblPurDetails")
                        .HasForeignKey("PurHeaderId")
                        .IsRequired()
                        .HasConstraintName("FK_tblPurDetail_tblPurHeader");

                    b.HasOne("Purchase_Order.Models.TblMaterial", "PurMat")
                        .WithMany("TblPurDetails")
                        .HasForeignKey("PurMatId")
                        .IsRequired()
                        .HasConstraintName("FK_tblPurDetail_tblMaterial");

                    b.Navigation("PurHeader");

                    b.Navigation("PurMat");
                });

            modelBuilder.Entity("Purchase_Order.Models.TblPurHeader", b =>
                {
                    b.HasOne("Purchase_Order.Models.TblVendor", "Vendor")
                        .WithMany("TblPurHeaders")
                        .HasForeignKey("VendorId")
                        .IsRequired()
                        .HasConstraintName("FK_tblPurHeader_tblVendor");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Purchase_Order.Models.TblMaterial", b =>
                {
                    b.Navigation("TblPurDetails");
                });

            modelBuilder.Entity("Purchase_Order.Models.TblPurHeader", b =>
                {
                    b.Navigation("TblPurDetails");
                });

            modelBuilder.Entity("Purchase_Order.Models.TblVendor", b =>
                {
                    b.Navigation("TblPurHeaders");
                });
#pragma warning restore 612, 618
        }
    }
}
