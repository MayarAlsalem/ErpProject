using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ev> Ev { get; set; }
        public virtual DbSet<EvRef> EvRef { get; set; }
        public virtual DbSet<Pe> Pe { get; set; }
        public virtual DbSet<PeCat> PeCat { get; set; }
        public virtual DbSet<PeEv> PeEv { get; set; }
        public virtual DbSet<PeWo> PeWo { get; set; }
        public virtual DbSet<Pr> Pr { get; set; }
        public virtual DbSet<PrTy> PrTy { get; set; }
        public virtual DbSet<Ta> Ta { get; set; }
        public virtual DbSet<TaCat> TaCat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DIHDC2K\\SQLEXPRESS;Initial Catalog=ERP;Persist Security Info=True;User ID=sa;Password=123456789");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ev>(entity =>
            {
                entity.HasKey(e => e.IdEv)
                    .HasName("Ev$PrimaryKey");

                entity.HasIndex(e => e.IdEv)
                    .HasName("Ev$ID");

                entity.HasIndex(e => e.IdEvRef)
                    .HasName("Ev$IdEvRef");

                entity.HasIndex(e => e.IdPe)
                    .HasName("Ev$IdPe");

                entity.Property(e => e.ArEv).HasDefaultValueSql("((0))");

                entity.Property(e => e.CoPr).HasMaxLength(255);

                entity.Property(e => e.DaEv)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.DaNev)
                    .HasColumnName("DaNEv")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ExEv).HasMaxLength(255);

                entity.Property(e => e.IdEvRef).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdPe).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotEv).HasMaxLength(255);

                entity.Property(e => e.PlEv).HasMaxLength(50);

              

                entity.Property(e => e.Ti1Ev).HasColumnType("datetime2(0)");

                entity.Property(e => e.Ti2Ev).HasColumnType("datetime2(0)");

                entity.Property(e => e.TitEv).HasMaxLength(255);
            });

            modelBuilder.Entity<EvRef>(entity =>
            {
                entity.HasKey(e => e.IdEvRef)
                    .HasName("EvRef$PrimaryKey");

                entity.Property(e => e.NaEvRef)
                    .IsRequired()
                    .HasMaxLength(50);

                
            });

            modelBuilder.Entity<Pe>(entity =>
            {
                entity.HasKey(e => e.IdPe)
                    .HasName("Pe$PrimaryKey");

                entity.HasIndex(e => e.IdPeCat)
                    .HasName("Pe$IDPCat");

                entity.Property(e => e.CerPe)
                    .HasMaxLength(255)
                    .HasComment(" الشهادة");

                entity.Property(e => e.CiPe)
                    .HasMaxLength(50)
                    .HasComment("المنطقة");

                entity.Property(e => e.DaEnPe)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.DaNpe)
                    .HasColumnName("DaNPe")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.DaPe)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))")
                    .HasComment("التاريخ");

                entity.Property(e => e.EmPe)
                    .HasMaxLength(255)
                    .HasComment("الإيميل");

                entity.Property(e => e.Id1Pe)
                    .HasDefaultValueSql("((0))")
                    .HasComment("المعرّف");

                entity.Property(e => e.IdPeCat)
                    .HasDefaultValueSql("((0))")
                    .HasComment("تصنيف الشخص");

                entity.Property(e => e.JoPe)
                    .HasMaxLength(50)
                    .HasComment("المهنة");

                entity.Property(e => e.MetPe).HasMaxLength(255);

                entity.Property(e => e.NaPe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("الاسم");

                entity.Property(e => e.NatPe)
                    .HasMaxLength(255)
                    .HasComment("الجنسية");

                entity.Property(e => e.NotPe)
                    .HasMaxLength(255)
                    .HasComment("الملاحظات");

                entity.Property(e => e.PhoPe)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasComment("الهاتف");

                entity.Property(e => e.TyPe).HasMaxLength(255);

                entity.HasOne(d => d.Id1PeNavigation)
                    .WithMany(p => p.InverseId1PeNavigation)
                    .HasForeignKey(d => d.Id1Pe)
                    .HasConstraintName("FK_Pe_Pe");

                entity.HasOne(d => d.IdPeCatNavigation)
                    .WithMany(p => p.Pe)
                    .HasForeignKey(d => d.IdPeCat)
                    .HasConstraintName("FK_Pe_PeCat");
            });

            modelBuilder.Entity<PeCat>(entity =>
            {
                entity.HasKey(e => e.IdPeCat)
                    .HasName("PeCat$PrimaryKey");

                entity.Property(e => e.PeCat1)
                    .HasColumnName("PeCat")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PeEv>(entity =>
            {
                entity.HasKey(e => e.IdPeEv)
                    .HasName("PeEv$PrimaryKey");

                entity.HasIndex(e => e.IdPeEv)
                    .HasName("PeEv$IDEO");

                entity.Property(e => e.DaNpe)
                    .HasColumnName("DaNPe")
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.IdEv).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdPe).HasComment("الشخص");

                entity.Property(e => e.RelPeEv)
                    .HasMaxLength(255)
                    .HasComment("العلاقة");

                entity.HasOne(d => d.IdPeNavigation)
                    .WithMany(p => p.PeEv)
                    .HasForeignKey(d => d.IdPe)
                    .HasConstraintName("FK_PeEv_Pe");
            });

            modelBuilder.Entity<PeWo>(entity =>
            {
                entity.HasKey(e => e.IdPeWo)
                    .HasName("PeWo$PrimaryKey");

                entity.HasIndex(e => e.IdPe)
                    .HasName("PeWo$IDPr");

                entity.Property(e => e.DaPeWo)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.IdPe).HasDefaultValueSql("((0))");

                entity.Property(e => e.JoDePeWo).HasMaxLength(255);

                entity.Property(e => e.OrPeWo).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdPeNavigation)
                    .WithMany(p => p.PeWo)
                    .HasForeignKey(d => d.IdPe)
                    .HasConstraintName("FK_PeWo_Pe");
            });

            modelBuilder.Entity<Pr>(entity =>
            {
                entity.HasKey(e => e.CoPr)
                    .HasName("Pr$PrimaryKey");

                entity.Property(e => e.CoPr)
                    .HasMaxLength(25)
                    .HasDefaultValueSql("('A00A0')");

                entity.Property(e => e.DaPr)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.DesPr).HasMaxLength(255);

                entity.Property(e => e.IdPrTy).HasDefaultValueSql("((0))");

                entity.Property(e => e.Idpr)
                    .HasColumnName("IDPr")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StPr)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('??? ?????')");
            });

            modelBuilder.Entity<PrTy>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PrTy1)
                    .HasColumnName("PrTy")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Ta>(entity =>
            {
                entity.HasKey(e => e.IdTa)
                    .HasName("Ta$PrimaryKey");

                entity.HasIndex(e => e.IdTa)
                    .HasName("Ta$IDDuty1");

                entity.HasIndex(e => e.Ta1)
                    .HasName("Ta$الواجب")
                    .IsUnique();

                entity.Property(e => e.DaNta)
                    .HasColumnName("DaNTa")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.DaTa)
                    .HasColumnType("datetime2(0)")
                    .HasDefaultValueSql("(CONVERT([datetime],CONVERT([varchar],getdate(),(1)),(1)))");

                entity.Property(e => e.IdCat).HasDefaultValueSql("((3))");

                entity.Property(e => e.IdPe).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotTa).HasMaxLength(255);

                entity.Property(e => e.Ta1)
                    .HasColumnName("Ta")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdPeNavigation)
                    .WithMany(p => p.Ta)
                    .HasForeignKey(d => d.IdPe)
                    .HasConstraintName("FK_Ta_Pe");
            });

            modelBuilder.Entity<TaCat>(entity =>
            {
                entity.HasKey(e => e.Idcat)
                    .HasName("TaCat$PrimaryKey");

                entity.Property(e => e.Idcat).HasColumnName("IDCat");

                entity.Property(e => e.Cat).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
