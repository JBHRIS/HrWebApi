using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.Share
{
    public partial class ShareContext : DbContext
    {
        public ShareContext()
        {
        }

        public ShareContext(DbContextOptions<ShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppBSSID> AppBSSIDs { get; set; }
        public virtual DbSet<AppBSSIDAndUserBind> AppBSSIDAndUserBinds { get; set; }
        public virtual DbSet<AppBSSIDAndUserGroupBind> AppBSSIDAndUserGroupBinds { get; set; }
        public virtual DbSet<AppMapScope> AppMapScopes { get; set; }
        public virtual DbSet<AppMapScopeAndUserBind> AppMapScopeAndUserBinds { get; set; }
        public virtual DbSet<AppMapScopeAndUserGroupBind> AppMapScopeAndUserGroupBinds { get; set; }
        public virtual DbSet<AppNotification> AppNotifications { get; set; }
        public virtual DbSet<AppQRCode> AppQRCodes { get; set; }
        public virtual DbSet<AppQRCodeAndUserBind> AppQRCodeAndUserBinds { get; set; }
        public virtual DbSet<AppQRCodeAndUserGroupBind> AppQRCodeAndUserGroupBinds { get; set; }
        public virtual DbSet<AppUserAndRegistryKeyBind> AppUserAndRegistryKeyBinds { get; set; }
        public virtual DbSet<AppUserGroup> AppUserGroups { get; set; }
        public virtual DbSet<AppUserGroupBind> AppUserGroupBinds { get; set; }
        public virtual DbSet<AppUserGroupSetting> AppUserGroupSettings { get; set; }
        public virtual DbSet<AppUserSetting> AppUserSettings { get; set; }
        public virtual DbSet<QuestionDefaultMessage> QuestionDefaultMessages { get; set; }
        public virtual DbSet<QuestionMain> QuestionMains { get; set; }
        public virtual DbSet<QuestionReply> QuestionReplies { get; set; }
        public virtual DbSet<QuestionUserInfo> QuestionUserInfos { get; set; }
        public virtual DbSet<ShareCode> ShareCodes { get; set; }
        public virtual DbSet<ShareCompany> ShareCompanies { get; set; }
        public virtual DbSet<ShareDefault> ShareDefaults { get; set; }
        public virtual DbSet<ShareDictionary> ShareDictionaries { get; set; }
        public virtual DbSet<ShareDisplayMessage> ShareDisplayMessages { get; set; }
        public virtual DbSet<ShareFormsExtend> ShareFormsExtends { get; set; }
        public virtual DbSet<ShareIssue> ShareIssues { get; set; }
        public virtual DbSet<ShareMailTpl> ShareMailTpls { get; set; }
        public virtual DbSet<ShareMessage> ShareMessages { get; set; }
        public virtual DbSet<ShareSendQueue> ShareSendQueues { get; set; }
        public virtual DbSet<ShareTag> ShareTags { get; set; }
        public virtual DbSet<ShareUpload> ShareUploads { get; set; }
        public virtual DbSet<ShareValidate> ShareValidates { get; set; }
        public virtual DbSet<SystemColumn> SystemColumns { get; set; }
        public virtual DbSet<SystemPage> SystemPages { get; set; }
        public virtual DbSet<SystemTable> SystemTables { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<SystemUserAccountBind> SystemUserAccountBinds { get; set; }
        public virtual DbSet<SystemUserGroup> SystemUserGroups { get; set; }
        public virtual DbSet<SystemUserInfo> SystemUserInfos { get; set; }
        public virtual DbSet<SystemUserNotify> SystemUserNotifies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =192.168.1.12;Initial Catalog =Share; User ID = jb;Password =^Hsx9bu5t@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<AppBSSID>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppBSSID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.Bssid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Ssid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppBSSIDAndUserBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppBSSIDAndUserBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppBSSIDCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppBSSIDAndUserGroupBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppBSSIDAndUserGroupBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppBSSIDCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppUserGroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppMapScope>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppMapScope");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Altitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Distance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Latitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Longitude)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppMapScopeAndUserBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppMapScopeAndUserBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppMapScopeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppMapScopeAndUserGroupBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppMapScopeAndUserGroupBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppMapScopeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppUserGroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppNotification>(entity =>
            {
                entity.HasKey(e => e.iAutoKey)
                    .HasName("PK_APP_NOTIFICATIONS");

                entity.Property(e => e.BODY)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.COMP)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EMPID).HasMaxLength(50);

                entity.Property(e => e.FREEZE_TIME).HasColumnType("datetime");

                entity.Property(e => e.KEY_DATE).HasColumnType("datetime");

                entity.Property(e => e.KEY_MAN)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NOTE).HasMaxLength(50);

                entity.Property(e => e.NOTE1).HasMaxLength(50);

                entity.Property(e => e.NOTE2).HasMaxLength(50);

                entity.Property(e => e.SUBJECT)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SUCCESS_TIME).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppQRCode>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppQRCode");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.KeyCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppQRCodeAndUserBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppQRCodeAndUserBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppQRCodeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppQRCodeAndUserGroupBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppQRCodeAndUserGroupBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppQRCodeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppUserGroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppUserAndRegistryKeyBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppUserAndRegistryKeyBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.RegistryKey)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppUserGroup>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppUserGroup");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppUserGroupBind>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppUserGroupBind");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppUserGroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppUserGroupSetting>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppUserGroupSetting");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AppUserGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<AppUserSetting>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("AppUserSetting");

                entity.HasIndex(e => e.AutoKey, "IX_AppUserSetting")
                    .IsUnique();

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.AutoKey).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionDefaultMessage>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("QuestionDefaultMessage");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contents).IsRequired();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionMain>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("QuestionMain");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QuestionCategoryCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SystemCategoryCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TitleContent)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionReply>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("QuestionReply");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ParentCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.QuestionMainCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ReplyToCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<QuestionUserInfo>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("QuestionUserInfo");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccountPassword).HasMaxLength(200);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Key1).HasMaxLength(50);

                entity.Property(e => e.Key2).HasMaxLength(50);

                entity.Property(e => e.Key3).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareCode>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareCode");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Column1).HasMaxLength(50);

                entity.Property(e => e.Column2).HasMaxLength(50);

                entity.Property(e => e.Column3).HasMaxLength(50);

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.SystemUse)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareCompany>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareCompany");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColumnTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareDefault>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_ShareDefault_1");

                entity.ToTable("ShareDefault");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ColumnTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FieldKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareDictionary>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareDictionary");

                entity.HasIndex(e => new { e.GroupCode, e.Code }, "IX_ShareDictionary")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GroupCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sort).HasDefaultValueSql("((9))");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareDisplayMessage>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareDisplayMessage");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contents).IsRequired();

                entity.Property(e => e.DisplayTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.TitleContents).IsRequired();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareFormsExtend>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_FormsExtend");

                entity.ToTable("ShareFormsExtend");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Column1).HasMaxLength(50);

                entity.Property(e => e.Column2).HasMaxLength(50);

                entity.Property(e => e.Column3).HasMaxLength(50);

                entity.Property(e => e.FormsCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareIssue>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareIssue");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.IssueContent).IsRequired();

                entity.Property(e => e.IssueTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Serial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sort).HasDefaultValueSql("((9))");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareMailTpl>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_MailSend");

                entity.ToTable("ShareMailTpl");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Statement).IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Subject).IsRequired();

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareMessage>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_ShareException");

                entity.ToTable("ShareMessage");

                entity.Property(e => e.AppName).HasMaxLength(500);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HandleStatusCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.IpAddress).HasMaxLength(50);

                entity.Property(e => e.MessageTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareSendQueue>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareSendQueue");

                entity.Property(e => e.Body).IsRequired();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateSend).HasColumnType("datetime");

                entity.Property(e => e.FromAddr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FromName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.SendTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Subject).IsRequired();

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToAddr)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToAddrConfidential)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToAddrCopy)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ToName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToNameConfidential)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ToNameCopy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareTag>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareTag");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TagCategoryCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<ShareUpload>(entity =>
            {
                entity.HasKey(e => e.AutoKey)
                    .HasName("PK_ShareUploadFiles");

                entity.ToTable("ShareUpload");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CompanyId).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ServerName).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.SystemUse)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UploadName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ShareValidate>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("ShareValidate");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.DateOpen).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Param).IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemColumn>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ColumnTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DefaultValue)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Related)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TablesCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemPage>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemPage");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FileName).HasMaxLength(500);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.FileTitle).HasMaxLength(200);

                entity.Property(e => e.Href)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.ParentCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Share')");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemTable>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemUser");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AccountPassword)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompnayId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'demo')");

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.IsRegistered)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MoneyPassword)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUserAccountBind>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemUserAccountBind");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ThirdPartyAccountId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ThirdPartyTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUserGroup>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemUserGroup");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUserInfo>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemUserInfo");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AnonymousName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EmailA).HasColumnType("datetime");

                entity.Property(e => e.EmailD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Tel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TelA).HasColumnType("datetime");

                entity.Property(e => e.TelD).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SystemUserNotify>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("SystemUserNotify");

                entity.Property(e => e.AppCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.AppName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contents).IsRequired();

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.NotifyTypeCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TitleContents).IsRequired();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.UserCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserCodeSend)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
