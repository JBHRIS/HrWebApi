using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JBAppService.Api.Dal.Models.AppDBContext
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppRegistryKey_Bind> AppRegistryKey_Bind { get; set; }
        public virtual DbSet<AppSetting_Configuration> AppSetting_Configuration { get; set; }
        public virtual DbSet<CardAppDetails> CardAppDetails { get; set; }
        public virtual DbSet<CardAppImages> CardAppImages { get; set; }
        public virtual DbSet<EmpConfiguration> EmpConfiguration { get; set; }
        public virtual DbSet<FencePoints> FencePoints { get; set; }
        public virtual DbSet<FencePointsOrigin> FencePointsOrigin { get; set; }
        public virtual DbSet<PunchCardType> PunchCardType { get; set; }
        public virtual DbSet<QRCode_Verification> QRCode_Verification { get; set; }
        public virtual DbSet<SSID_Identifier> SSID_Identifier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=40.83.116.158;Initial Catalog=YOSYUAN_AppSetting;Persist Security Info=True;User ID=yosyuan_owner;Password=v84Axu@7hns0mXtG;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppRegistryKey_Bind>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.APP_RegistryKey).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Nobr).HasMaxLength(50);
            });

            modelBuilder.Entity<AppSetting_Configuration>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Group).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.SettingItem).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(50);
            });

            modelBuilder.Entity<CardAppDetails>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.APP_RegistryKey).HasMaxLength(50);

                entity.Property(e => e.BSSID).HasMaxLength(50);

                entity.Property(e => e.CardProcess).HasColumnType("datetime");

                entity.Property(e => e.CardSend).HasColumnType("datetime");

                entity.Property(e => e.CardStart).HasColumnType("datetime");

                entity.Property(e => e.CardTypeCode).HasMaxLength(50);

                entity.Property(e => e.IP_Address).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.MAC).HasMaxLength(50);

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.QRCODE).HasMaxLength(50);

                entity.Property(e => e.SSID).HasMaxLength(50);
            });

            modelBuilder.Entity<CardAppImages>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.UploadDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmpConfiguration>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Nobr).HasMaxLength(50);

                entity.Property(e => e.SettingItem).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(50);
            });

            modelBuilder.Entity<FencePoints>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Note).HasMaxLength(50);

                entity.Property(e => e.PointsGroup).HasMaxLength(50);

                entity.Property(e => e.oLatitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.oLongitude).HasColumnType("decimal(11, 8)");
            });

            modelBuilder.Entity<FencePointsOrigin>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Latitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Note).HasMaxLength(50);
            });

            modelBuilder.Entity<PunchCardType>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_PunchCardType]");

                entity.Property(e => e.KeyDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.KeyMan)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<QRCode_Verification>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.GUID).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.QRCode).HasMaxLength(50);
            });

            modelBuilder.Entity<SSID_Identifier>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.BSSID).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.SSID).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
