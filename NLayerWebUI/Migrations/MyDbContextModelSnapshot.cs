﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayerWebUI.Context;

#nullable disable

namespace NLayerWebUI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayerWebUI.Entity.FatKalem", b =>
                {
                    b.Property<int>("FaturaKalemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaturaKalemId"), 1L, 1);

                    b.Property<int>("DEPO_KODU")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("FaturaId")
                        .HasColumnType("int");

                    b.Property<string>("ProjeKodu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("STra_BF")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<double>("STra_GCMIK")
                        .HasMaxLength(15)
                        .HasColumnType("float");

                    b.Property<double>("STra_NF")
                        .HasMaxLength(10)
                        .HasColumnType("float");

                    b.Property<string>("StokKodu")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("FaturaKalemId");

                    b.HasIndex("FaturaId");

                    b.ToTable("FatKalems");
                });

            modelBuilder.Entity("NLayerWebUI.Entity.FaturaUst", b =>
                {
                    b.Property<int>("FaturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FaturaId"), 1L, 1);

                    b.Property<string>("CariKod")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FATIRS_NO")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<bool>("KDV_DAHILMI")
                        .HasColumnType("bit");

                    b.Property<string>("PLA_KODU")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Proje_Kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SIPARIS_TEST")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TIPI")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<string>("Tarih")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tip")
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.HasKey("FaturaId");

                    b.ToTable("FaturaUsts");
                });

            modelBuilder.Entity("NLayerWebUI.Entity.FatKalem", b =>
                {
                    b.HasOne("NLayerWebUI.Entity.FaturaUst", "Fatura")
                        .WithMany("FaturaKalems")
                        .HasForeignKey("FaturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fatura");
                });

            modelBuilder.Entity("NLayerWebUI.Entity.FaturaUst", b =>
                {
                    b.Navigation("FaturaKalems");
                });
#pragma warning restore 612, 618
        }
    }
}
