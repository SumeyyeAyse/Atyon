using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Atyon.Entities
{
    public partial class AtyonDataContext : DbContext
    {
        public AtyonDataContext()
        {
        }

        public AtyonDataContext(DbContextOptions<AtyonDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAtik> TblAtiks { get; set; } = null!;
        public virtual DbSet<TblAtikStokHareket> TblAtikStokHarekets { get; set; } = null!;
        public virtual DbSet<TblAtikTip> TblAtikTips { get; set; } = null!;
        public virtual DbSet<TblFirma> TblFirmas { get; set; } = null!;
        public virtual DbSet<TblIl> TblIls { get; set; } = null!;
        public virtual DbSet<TblIlce> TblIlces { get; set; } = null!;
        public virtual DbSet<TblTesis> TblTesis { get; set; } = null!;
        public virtual DbSet<TblTesisNitelikTip> TblTesisNitelikTips { get; set; } = null!;
        public virtual DbSet<TblTesisTip> TblTesisTips { get; set; } = null!;
        public virtual DbSet<TblUretim> TblUretims { get; set; } = null!;
        public virtual DbSet<TblUrun> TblUruns { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Atyon;Trusted_Connection=false;User Id=atyon_app;Password=123456;", x => x.UseNetTopologySuite());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAtik>(entity =>
            {
                entity.HasKey(e => e.AtikId)
                    .HasName("TblAtik_PK");

                entity.Property(e => e.KayitTarih).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AtikTipKodNavigation)
                    .WithMany(p => p.TblAtiks)
                    .HasPrincipalKey(p => p.AtikTipKod)
                    .HasForeignKey(d => d.AtikTipKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblAtik_TblAtikTip_FK");
            });

            modelBuilder.Entity<TblAtikStokHareket>(entity =>
            {
                entity.HasKey(e => e.AtikStokHareketId)
                    .HasName("TblTransfer_PK");

                //entity.Property(e => e.AtikStokHareketId).ValueGeneratedNever();

                entity.Property(e => e.AtikStokHareketTip).HasComment("1 Çıkıiş\r\n2 Giriş\r\n3 Üretim\r\n4 Geri Dönüşüm");

                entity.Property(e => e.KayitTarihi).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AtikKodNavigation)
                    .WithMany(p => p.TblAtikStokHarekets)
                    .HasPrincipalKey(p => p.AtikKod)
                    .HasForeignKey(d => d.AtikKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblTransfer_TblAtik_FK");

                entity.HasOne(d => d.TesisKodNavigation)
                    .WithMany(p => p.TblAtikStokHarekets)
                    //.HasPrincipalKey(p => p.TesisKod)
                    .HasForeignKey(d => d.TesisKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblAtikStokHareket_TblTesis_FK");
            });

            modelBuilder.Entity<TblAtikTip>(entity =>
            {
                entity.HasKey(e => e.AtikTipId)
                    .HasName("TblAtikTip_PK");

                //entity.Property(e => e.AtikTipId).ValueGeneratedNever();

                entity.Property(e => e.KayıtTarih).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AtikTipKodNavigation)
                    .WithOne(p => p.InverseAtikTipKodNavigation)
                    .HasForeignKey<TblAtikTip>(d => d.AtikTipKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblAtikTip_TblAtikTip_FK");
            });

            modelBuilder.Entity<TblFirma>(entity =>
            {
                entity.HasKey(e => e.FirmaId)
                    .HasName("TblNakliyeFirma_PK");

                //entity.Property(e => e.FirmaId).ValueGeneratedNever();

                entity.Property(e => e.KayitTarihi).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblIl>(entity =>
            {
                entity.HasKey(e => e.IlId)
                    .HasName("Tbl_Il_PK");

                entity.Property(e => e.KayitTarih).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblIlce>(entity =>
            {
                entity.HasKey(e => e.IlceId)
                    .HasName("Tbl_Ilce_PK");

                //entity.Property(e => e.IlceId).ValueGeneratedNever();

                entity.Property(e => e.IlceKod).HasComment("mernis kodu");

                entity.Property(e => e.KayitTarihi).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IlKodNavigation)
                    .WithOne(p => p.TblIlce)
                    .HasPrincipalKey<TblIl>(p => p.IlKod)
                    .HasForeignKey<TblIlce>(d => d.IlKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tbl_Ilce_Tbl_Il_FK");
            });

            modelBuilder.Entity<TblTesis>(entity =>
            {
                entity.HasKey(e => e.TesisId)
                    .HasName("Tbl_Tesis_PK");

                //entity.Property(e => e.TesisId).ValueGeneratedNever();

                entity.Property(e => e.KayitTarih).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FirmaKodNavigation)
                    .WithMany(p => p.TblTesis)
                    .HasPrincipalKey(p => p.FirmaKod)
                    .HasForeignKey(d => d.FirmaKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblTesis_TblFirma_FK");

                entity.HasOne(d => d.IlceKodNavigation)
                    .WithMany(p => p.TblTesis)
                    .HasPrincipalKey(p => p.IlceKod)
                    .HasForeignKey(d => d.IlceKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Tbl_Tesis_ilcekod");
            });

            modelBuilder.Entity<TblTesisNitelikTip>(entity =>
            {
                entity.HasKey(e => e.TesisNitelikTipId)
                    .HasName("Tbl_Tesis_Nitelik_Tip_PK");

                //entity.Property(e => e.TesisNitelikTipId).ValueGeneratedNever();

                entity.Property(e => e.KayıtTarih).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TesisKodNavigation)
                    .WithMany(p => p.TblTesisNitelikTips)
                    //.HasPrincipalKey(p => p.TesisKod)
                    .HasForeignKey(d => d.TesisKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tbl_Tesis_Nitelik_Tip_Tbl_Tesis_FK");

                entity.HasOne(d => d.TesisTipKodNavigation)
                    .WithMany(p => p.TblTesisNitelikTips)
                    .HasPrincipalKey(p => p.TesisTipKod)
                    .HasForeignKey(d => d.TesisTipKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tbl_Tesis_Nitelik_Tip_Tbl_TesisTip_FK");
            });

            modelBuilder.Entity<TblTesisTip>(entity =>
            {
                entity.HasKey(e => e.TesisTipId)
                    .HasName("Tbl_Uretici_PK");

                //entity.Property(e => e.TesisTipId).ValueGeneratedNever();

                entity.Property(e => e.TesisTipKayıtTarih).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblUretim>(entity =>
            {
                entity.HasKey(e => e.UretimId)
                    .HasName("TblUretim_PK");

                //entity.Property(e => e.UretimId).ValueGeneratedNever();

                entity.Property(e => e.KayıtTarih).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.TesisKodNavigation)
                    .WithMany(p => p.TblUretims)
                    //.HasPrincipalKey(p => p.TesisKod)
                    .HasForeignKey(d => d.TesisKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblUretim_TblTesis_FK");

                entity.HasOne(d => d.UrunKodNavigation)
                    .WithMany(p => p.TblUretims)
                    .HasPrincipalKey(p => p.UrunKod)
                    .HasForeignKey(d => d.UrunKod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TblUretim_TblUrun_FK");
            });

            modelBuilder.Entity<TblUrun>(entity =>
            {
                entity.HasKey(e => e.UrunId)
                    .HasName("TblUrunler_PK");

                //entity.Property(e => e.UrunId).ValueGeneratedNever();

                entity.Property(e => e.KayitTarih).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
