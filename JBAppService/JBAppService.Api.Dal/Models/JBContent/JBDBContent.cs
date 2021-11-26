using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class JBDBContent : DbContext
    {
        public JBDBContent()
        {
        }

        public JBDBContent(DbContextOptions<JBDBContent> options)
            : base(options)
        {
        }

        public virtual DbSet<COLDEF> COLDEF { get; set; }
        public virtual DbSet<GROUPMENUCONTROL> GROUPMENUCONTROL { get; set; }
        public virtual DbSet<GROUPMENUS> GROUPMENUS { get; set; }
        public virtual DbSet<GROUPS> GROUPS { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND> HRM_ATTEND_ATTEND { get; set; }
        public virtual DbSet<HRM_ATTEND_ATTEND_CARD> HRM_ATTEND_ATTEND_CARD { get; set; }
        public virtual DbSet<HRM_ATTEND_CARD_DATA_TEMP> HRM_ATTEND_CARD_DATA_TEMP { get; set; }
        public virtual DbSet<HRM_ATTEND_ROTE> HRM_ATTEND_ROTE { get; set; }
        public virtual DbSet<HRM_BASE_BASE> HRM_BASE_BASE { get; set; }
        public virtual DbSet<HRM_BASE_BASEIO> HRM_BASE_BASEIO { get; set; }
        public virtual DbSet<HRM_DEPT> HRM_DEPT { get; set; }
        public virtual DbSet<MENUCHECKLOG> MENUCHECKLOG { get; set; }
        public virtual DbSet<MENUFAVOR> MENUFAVOR { get; set; }
        public virtual DbSet<MENUITEMTYPE> MENUITEMTYPE { get; set; }
        public virtual DbSet<MENUTABLE> MENUTABLE { get; set; }
        public virtual DbSet<MENUTABLECONTROL> MENUTABLECONTROL { get; set; }
        public virtual DbSet<MENUTABLELOG> MENUTABLELOG { get; set; }
        public virtual DbSet<SYSAUTONUM> SYSAUTONUM { get; set; }
        public virtual DbSet<SYSEEPLOG> SYSEEPLOG { get; set; }
        public virtual DbSet<SYSERRLOG> SYSERRLOG { get; set; }
        public virtual DbSet<SYS_ANYQUERY> SYS_ANYQUERY { get; set; }
        public virtual DbSet<SYS_EEP_USERS> SYS_EEP_USERS { get; set; }
        public virtual DbSet<SYS_EXTAPPROVE> SYS_EXTAPPROVE { get; set; }
        public virtual DbSet<SYS_FLDEFINITION> SYS_FLDEFINITION { get; set; }
        public virtual DbSet<SYS_FLINSTANCESTATE> SYS_FLINSTANCESTATE { get; set; }
        public virtual DbSet<SYS_LANGUAGE> SYS_LANGUAGE { get; set; }
        public virtual DbSet<SYS_MESSENGER> SYS_MESSENGER { get; set; }
        public virtual DbSet<SYS_ORG> SYS_ORG { get; set; }
        public virtual DbSet<SYS_ORGKIND> SYS_ORGKIND { get; set; }
        public virtual DbSet<SYS_ORGLEVEL> SYS_ORGLEVEL { get; set; }
        public virtual DbSet<SYS_ORGROLES> SYS_ORGROLES { get; set; }
        public virtual DbSet<SYS_PERSONAL> SYS_PERSONAL { get; set; }
        public virtual DbSet<SYS_REFVAL> SYS_REFVAL { get; set; }
        public virtual DbSet<SYS_REFVAL_D1> SYS_REFVAL_D1 { get; set; }
        public virtual DbSet<SYS_REPORT> SYS_REPORT { get; set; }
        public virtual DbSet<SYS_ROLES_AGENT> SYS_ROLES_AGENT { get; set; }
        public virtual DbSet<SYS_TODOHIS> SYS_TODOHIS { get; set; }
        public virtual DbSet<SYS_TODOLIST> SYS_TODOLIST { get; set; }
        public virtual DbSet<USERGROUPS> USERGROUPS { get; set; }
        public virtual DbSet<USERMENUCONTROL> USERMENUCONTROL { get; set; }
        public virtual DbSet<USERMENUS> USERMENUS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<ViewDept> ViewDept { get; set; }
        public virtual DbSet<ViewDeptTree> ViewDeptTree { get; set; }
        public virtual DbSet<ViewEmp> ViewEmp { get; set; }
        public virtual DbSet<ViewJob> ViewJob { get; set; }
        public virtual DbSet<ViewJobl> ViewJobl { get; set; }
        public virtual DbSet<View_SYS_ORG> View_SYS_ORG { get; set; }
        public virtual DbSet<View_SYS_TODOLIST> View_SYS_TODOLIST { get; set; }
        public virtual DbSet<View_SYS_TODOLIST_STEP> View_SYS_TODOLIST_STEP { get; set; }
        public virtual DbSet<View_ToDoList_Applicant> View_ToDoList_Applicant { get; set; }
        public virtual DbSet<View_ToDoList_Auditor> View_ToDoList_Auditor { get; set; }
        public virtual DbSet<View_ToDoList_Flow_Desc> View_ToDoList_Flow_Desc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =211.78.84.42;Initial Catalog =EIPHRSYS; User ID = JBUSER;Password =8421qq1021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COLDEF>(entity =>
            {
                entity.HasKey(e => new { e.TABLE_NAME, e.FIELD_NAME })
                    .HasName("PK__COLDEF__86D771FC7F60ED59");

                entity.HasIndex(e => new { e.TABLE_NAME, e.FIELD_NAME })
                    .HasName("TABLENAME");

                entity.Property(e => e.TABLE_NAME).HasMaxLength(20);

                entity.Property(e => e.FIELD_NAME).HasMaxLength(20);

                entity.Property(e => e.CANREPORT).HasMaxLength(1);

                entity.Property(e => e.CAPTION).HasMaxLength(40);

                entity.Property(e => e.CAPTION1).HasMaxLength(40);

                entity.Property(e => e.CAPTION2).HasMaxLength(40);

                entity.Property(e => e.CAPTION3).HasMaxLength(40);

                entity.Property(e => e.CAPTION4).HasMaxLength(40);

                entity.Property(e => e.CAPTION5).HasMaxLength(40);

                entity.Property(e => e.CAPTION6).HasMaxLength(40);

                entity.Property(e => e.CAPTION7).HasMaxLength(40);

                entity.Property(e => e.CAPTION8).HasMaxLength(40);

                entity.Property(e => e.CHECK_NULL).HasMaxLength(1);

                entity.Property(e => e.DD_NAME).HasMaxLength(40);

                entity.Property(e => e.DEFAULT_VALUE).HasMaxLength(100);

                entity.Property(e => e.EDITMASK).HasMaxLength(10);

                entity.Property(e => e.EXT_MENUID).HasMaxLength(20);

                entity.Property(e => e.FIELD_LENGTH).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.FIELD_SCALE).HasColumnType("numeric(12, 0)");

                entity.Property(e => e.FIELD_TYPE).HasMaxLength(20);

                entity.Property(e => e.IS_KEY)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.NEEDBOX).HasMaxLength(13);

                entity.Property(e => e.QUERYMODE).HasMaxLength(20);

                entity.Property(e => e.SEQ).HasColumnType("numeric(12, 0)");
            });

            modelBuilder.Entity<GROUPMENUCONTROL>(entity =>
            {
                entity.HasKey(e => new { e.GROUPID, e.MENUID, e.CONTROLNAME })
                    .HasName("PK__GROUPMEN__31B502DA398D8EEE");

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CONTROLNAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ALLOWADD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWDELETE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWPRINT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWUPDATE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ENABLED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VISIBLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<GROUPMENUS>(entity =>
            {
                entity.HasKey(e => new { e.GROUPID, e.MENUID })
                    .HasName("PK__GROUPMEN__C793EFB308EA5793");

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID).HasMaxLength(30);
            });

            modelBuilder.Entity<GROUPS>(entity =>
            {
                entity.HasKey(e => e.GROUPID)
                    .HasName("PK__GROUPS__2F41C629108B795B");

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(100);

                entity.Property(e => e.GROUPNAME).HasMaxLength(50);

                entity.Property(e => e.ISROLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MSAD).HasMaxLength(1);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND>(entity =>
            {
                entity.HasKey(e => e.ATTEND_ID);

                entity.Property(e => e.ATTEND_ID).ValueGeneratedNever();

                entity.Property(e => e.ABSENT_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ACTUAL_ATTEND_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ATTEND_DATE).HasColumnType("date");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EARLY_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CNT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_ABSENT).HasMaxLength(50);

                entity.Property(e => e.LATE_MINS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ATTEND_CARD>(entity =>
            {
                entity.HasKey(e => e.ATTEND_CARD_ID);

                entity.Property(e => e.ATTEND_CARD_ID).ValueGeneratedNever();

                entity.Property(e => e.CARD_DATE).HasColumnType("date");

                entity.Property(e => e.CARD_DATE_TIME_OFF).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_OFF_TRAN)
                    .HasColumnType("datetime")
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.CARD_DATE_TIME_ON).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME_ON_TRAN)
                    .HasColumnType("datetime")
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.NOT_MODIFY).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_FORGET).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME_TRAN)
                    .HasMaxLength(50)
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.ON_TIME).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_FORGET).HasMaxLength(50);

                entity.Property(e => e.ON_TIME_TRAN)
                    .HasMaxLength(50)
                    .HasComment("打算報表用的，不過目前沒用到2014/10/28");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_CARD_DATA_TEMP>(entity =>
            {
                entity.HasKey(e => e.CARD_DATA_ID);

                entity.Property(e => e.CARD_DATE).HasColumnType("datetime");

                entity.Property(e => e.CARD_DATE_TIME).HasColumnType("datetime");

                entity.Property(e => e.CARD_NO).HasMaxLength(50);

                entity.Property(e => e.CARD_TIME).HasMaxLength(50);

                entity.Property(e => e.CARD_TYPE).HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(50);

                entity.Property(e => e.FORGET_CARD_CAUSE_ID).HasMaxLength(50);

                entity.Property(e => e.IP_ADDRESS).HasMaxLength(50);

                entity.Property(e => e.IS_FORGET_CARD).HasMaxLength(50);

                entity.Property(e => e.MEMO).HasMaxLength(250);

                entity.Property(e => e.NOT_TRAN).HasMaxLength(50);

                entity.Property(e => e.SERIAL_NO).HasMaxLength(50);

                entity.Property(e => e.SOURCE_CODE).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_ATTEND_ROTE>(entity =>
            {
                entity.HasKey(e => e.ROTE_ID);

                entity.Property(e => e.ROTE_ID).ValueGeneratedNever();

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.D_WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FIX_OVERTIME_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.FLEXIBLE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.IS_CARD).HasMaxLength(50);

                entity.Property(e => e.IS_FIX_OVERTIME).HasMaxLength(50);

                entity.Property(e => e.IS_ROTE_ALLOWANCE).HasMaxLength(50);

                entity.Property(e => e.LATE_MINUTE).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.LEAVE_OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.OFF_TIME).HasMaxLength(50);

                entity.Property(e => e.ON_TIME).HasMaxLength(50);

                entity.Property(e => e.OT_BEGIN_TIME).HasMaxLength(50);

                entity.Property(e => e.ROTE_ALLOWANCE_AMT).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.ROTE_ALLOWANCE_SALCODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_CNAME).HasMaxLength(50);

                entity.Property(e => e.ROTE_CODE).HasMaxLength(50);

                entity.Property(e => e.ROTE_ENAME).HasMaxLength(50);

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WORK_HRS).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.YEAR_REST_HRS).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<HRM_BASE_BASE>(entity =>
            {
                entity.HasKey(e => e.EMPLOYEE_ID)
                    .HasName("PK_PK_HRM_BASE");

                entity.HasIndex(e => e.EMPLOYEE_CODE)
                    .HasName("Unique_HRM_BASE_BASE_EMPLOYEE_CODE")
                    .IsUnique();

                entity.Property(e => e.EMPLOYEE_ID)
                    .HasMaxLength(50)
                    .HasComment("Key");

                entity.Property(e => e.ADMIT_DATE).HasColumnType("date");

                entity.Property(e => e.ALIEN_RESIDENT_TYPE)
                    .HasMaxLength(50)
                    .HasComment("外籍類別");

                entity.Property(e => e.ARMY)
                    .HasMaxLength(50)
                    .HasComment("兵役狀態-Code表");

                entity.Property(e => e.ARMY_TYPE)
                    .HasMaxLength(50)
                    .HasComment("兵種");

                entity.Property(e => e.BIRTHDAY)
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.BIRTHPLACE)
                    .HasMaxLength(50)
                    .HasComment("出生地-資料表");

                entity.Property(e => e.BLOOD)
                    .HasMaxLength(50)
                    .HasComment("血型-Code表");

                entity.Property(e => e.COMPANY_MAIL)
                    .HasMaxLength(50)
                    .HasComment("公司MAIL");

                entity.Property(e => e.CONTACT_COUNTY).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_ID).HasComment("國別-資料表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .HasMaxLength(50)
                    .HasComment("員工編號");

                entity.Property(e => e.EXTERNAL_SENIORITY).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.GROUP_EFFECT_DATE).HasColumnType("date");

                entity.Property(e => e.HEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasComment("身高");

                entity.Property(e => e.IDNO)
                    .HasMaxLength(50)
                    .HasComment("身分證字號");

                entity.Property(e => e.INTRODUCER_CODE).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_ID).HasMaxLength(50);

                entity.Property(e => e.INTRODUCER_NAME).HasMaxLength(50);

                entity.Property(e => e.INTRODUCE_COMPANY_ID).HasMaxLength(50);

                entity.Property(e => e.MARRIAGE)
                    .HasMaxLength(50)
                    .HasComment("婚姻-Code表");

                entity.Property(e => e.NAME_C)
                    .HasMaxLength(50)
                    .HasComment("員工姓名");

                entity.Property(e => e.NAME_E)
                    .HasMaxLength(50)
                    .HasComment("英文名稱");

                entity.Property(e => e.PASSPORT_NAME)
                    .HasMaxLength(50)
                    .HasComment("護照姓名");

                entity.Property(e => e.PASSPORT_NUMBER)
                    .HasMaxLength(50)
                    .HasComment("護照號碼");

                entity.Property(e => e.PHOTO)
                    .HasMaxLength(50)
                    .HasComment("照片");

                entity.Property(e => e.REGISTER_COUNTY).HasMaxLength(50);

                entity.Property(e => e.RESIDENT_CERTIFICATE)
                    .HasMaxLength(50)
                    .HasComment("居留證號");

                entity.Property(e => e.SEX)
                    .HasMaxLength(50)
                    .HasComment("性別-Code表");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);

                entity.Property(e => e.WEIGHT)
                    .HasColumnType("decimal(5, 2)")
                    .HasComment("體重");
            });

            modelBuilder.Entity<HRM_BASE_BASEIO>(entity =>
            {
                entity.HasKey(e => e.BASEIO_ID);

                entity.Property(e => e.BASEIO_ID)
                    .HasComment("Employee-資料表")
                    .ValueGeneratedNever();

                entity.Property(e => e.ACTION_TYPE)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("進出類別(1:到職2:離職3:留停)Code表");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.EFFECT_DATE)
                    .HasColumnType("date")
                    .HasComment("生效日");

                entity.Property(e => e.EMPLOYEE_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MEMO)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("備註");

                entity.Property(e => e.REINSTATEMENT_DATE).HasColumnType("date");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<HRM_DEPT>(entity =>
            {
                entity.HasKey(e => e.DEPT_ID);

                entity.Property(e => e.DEPT_ID).ValueGeneratedNever();

                entity.Property(e => e.ALERT_EMAIL).HasMaxLength(500);

                entity.Property(e => e.ALERT_EMAIL_LIST).HasMaxLength(500);

                entity.Property(e => e.ALERT_TO_EMAIL).HasMaxLength(50);

                entity.Property(e => e.ALERT_TO_MANAGER).HasMaxLength(50);

                entity.Property(e => e.BEGIN_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.DEPT_ASSISTANT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_CNAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_CODE).HasMaxLength(50);

                entity.Property(e => e.DEPT_ENAME).HasMaxLength(50);

                entity.Property(e => e.DEPT_MANAGER).HasMaxLength(50);

                entity.Property(e => e.DEPT_PERSON).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.DEPT_TREE).HasMaxLength(50);

                entity.Property(e => e.END_EFFECTIVE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<MENUCHECKLOG>(entity =>
            {
                entity.HasKey(e => e.LOGID)
                    .HasName("PK__MENUCHEC__E39E279E276EDEB3");

                entity.Property(e => e.FILECONTENT).HasColumnType("image");

                entity.Property(e => e.FILEDATE).HasColumnType("datetime");

                entity.Property(e => e.FILENAME).HasMaxLength(60);

                entity.Property(e => e.FILETYPE).HasMaxLength(10);

                entity.Property(e => e.ITEMTYPE)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PACKAGE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<MENUFAVOR>(entity =>
            {
                entity.HasKey(e => new { e.MENUID, e.USERID })
                    .HasName("PK__MENUFAVO__CA9B7E5C44FF419A");

                entity.Property(e => e.MENUID).HasMaxLength(30);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CAPTION)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GROUPNAME).HasMaxLength(20);

                entity.Property(e => e.ITEMTYPE).HasMaxLength(20);
            });

            modelBuilder.Entity<MENUITEMTYPE>(entity =>
            {
                entity.HasKey(e => e.ITEMTYPE)
                    .HasName("PK__MENUITEM__5929D29C145C0A3F");

                entity.Property(e => e.ITEMTYPE).HasMaxLength(20);

                entity.Property(e => e.DBALIAS).HasMaxLength(50);

                entity.Property(e => e.ITEMNAME).HasMaxLength(20);
            });

            modelBuilder.Entity<MENUTABLE>(entity =>
            {
                entity.HasKey(e => e.MENUID)
                    .HasName("PK__MENUTABL__8D2299AF182C9B23");

                entity.Property(e => e.MENUID).HasMaxLength(30);

                entity.Property(e => e.CAPTION)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CAPTION0).HasMaxLength(50);

                entity.Property(e => e.CAPTION1).HasMaxLength(50);

                entity.Property(e => e.CAPTION2).HasMaxLength(50);

                entity.Property(e => e.CAPTION3).HasMaxLength(50);

                entity.Property(e => e.CAPTION4).HasMaxLength(50);

                entity.Property(e => e.CAPTION5).HasMaxLength(50);

                entity.Property(e => e.CAPTION6).HasMaxLength(50);

                entity.Property(e => e.CAPTION7).HasMaxLength(50);

                entity.Property(e => e.CHECKOUT).HasMaxLength(20);

                entity.Property(e => e.CHECKOUTDATE).HasColumnType("datetime");

                entity.Property(e => e.FORM).HasMaxLength(50);

                entity.Property(e => e.IMAGE).HasColumnType("image");

                entity.Property(e => e.IMAGEURL).HasMaxLength(100);

                entity.Property(e => e.ISSERVER).HasMaxLength(1);

                entity.Property(e => e.ISSHOWMODAL).HasMaxLength(1);

                entity.Property(e => e.ITEMPARAM).HasMaxLength(200);

                entity.Property(e => e.ITEMTYPE).HasMaxLength(20);

                entity.Property(e => e.MODULETYPE).HasMaxLength(1);

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PACKAGE).HasMaxLength(60);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");

                entity.Property(e => e.PARENT).HasMaxLength(20);

                entity.Property(e => e.SEQ_NO).HasMaxLength(4);

                entity.Property(e => e.VERSIONNO).HasMaxLength(20);
            });

            modelBuilder.Entity<MENUTABLECONTROL>(entity =>
            {
                entity.HasKey(e => new { e.MENUID, e.CONTROLNAME })
                    .HasName("PK__MENUTABL__EF4C4F3035BCFE0A");

                entity.Property(e => e.MENUID)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CONTROLNAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MENUTABLELOG>(entity =>
            {
                entity.HasKey(e => e.LOGID)
                    .HasName("PK__MENUTABL__E39E279E239E4DCF");

                entity.Property(e => e.LASTDATE).HasColumnType("datetime");

                entity.Property(e => e.MENUID)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.OLDDATE).HasMaxLength(20);

                entity.Property(e => e.OLDVERSION).HasColumnType("image");

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PACKAGE)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PACKAGEDATE).HasColumnType("datetime");
            });

            modelBuilder.Entity<SYSAUTONUM>(entity =>
            {
                entity.HasKey(e => new { e.AUTOID, e.FIXED })
                    .HasName("PK__SYSAUTON__8B6A240B03317E3D");

                entity.Property(e => e.AUTOID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FIXED)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CURRNUM).HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYSEEPLOG>(entity =>
            {
                entity.HasKey(e => new { e.CONNID, e.LOGID })
                    .HasName("PK__SYSEEPLO__361B53D82B3F6F97");

                entity.Property(e => e.CONNID).HasMaxLength(20);

                entity.Property(e => e.LOGID).ValueGeneratedOnAdd();

                entity.Property(e => e.COMPUTERIP).HasMaxLength(16);

                entity.Property(e => e.COMPUTERNAME).HasMaxLength(64);

                entity.Property(e => e.DESCRIPTION).HasColumnType("text");

                entity.Property(e => e.DOMAINID).HasMaxLength(30);

                entity.Property(e => e.LOGDATETIME).HasColumnType("datetime");

                entity.Property(e => e.LOGSTYLE)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LOGTYPE).HasMaxLength(1);

                entity.Property(e => e.TITLE).HasMaxLength(64);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYSERRLOG>(entity =>
            {
                entity.HasKey(e => e.ERRID)
                    .HasName("PK__SYSERRLO__D2855E082F10007B");

                entity.Property(e => e.ERRDATE).HasColumnType("datetime");

                entity.Property(e => e.ERRDESCRIP).HasMaxLength(255);

                entity.Property(e => e.ERRMESSAGE).HasMaxLength(255);

                entity.Property(e => e.ERRSCREEN).HasColumnType("image");

                entity.Property(e => e.ERRSTACK).HasColumnType("text");

                entity.Property(e => e.MODULENAME).HasMaxLength(30);

                entity.Property(e => e.OWNER).HasMaxLength(20);

                entity.Property(e => e.PROCESSDATE).HasColumnType("datetime");

                entity.Property(e => e.PRODESCRIP).HasMaxLength(255);

                entity.Property(e => e.STATUS).HasMaxLength(2);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_ANYQUERY>(entity =>
            {
                entity.HasKey(e => new { e.QUERYID, e.USERID, e.TEMPLATEID })
                    .HasName("PK__SYS_ANYQ__B689B07448CFD27E");

                entity.Property(e => e.QUERYID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TEMPLATEID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CONTENT).HasColumnType("text");

                entity.Property(e => e.LASTDATE).HasColumnType("datetime");

                entity.Property(e => e.TABLENAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_EEP_USERS>(entity =>
            {
                entity.HasKey(e => new { e.USERID, e.COMPUTER })
                    .HasName("PK__SYS_EEP___CA1CD5475441852A");

                entity.Property(e => e.USERID).HasMaxLength(50);

                entity.Property(e => e.COMPUTER).HasMaxLength(50);

                entity.Property(e => e.LASTACTIVETIME).HasMaxLength(50);

                entity.Property(e => e.LOGINTIME).HasMaxLength(50);

                entity.Property(e => e.USERNAME).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_EXTAPPROVE>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.APPROVEID).HasMaxLength(50);

                entity.Property(e => e.GROUPID).HasMaxLength(50);

                entity.Property(e => e.MAXIMUM).HasMaxLength(50);

                entity.Property(e => e.MINIMUM).HasMaxLength(50);

                entity.Property(e => e.ROLEID).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_FLDEFINITION>(entity =>
            {
                entity.HasKey(e => e.FLTYPEID)
                    .HasName("PK_SYS_FL");

                entity.Property(e => e.FLTYPEID).HasMaxLength(50);

                entity.Property(e => e.FLDEFINITION)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.FLTYPENAME)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<SYS_FLINSTANCESTATE>(entity =>
            {
                entity.HasKey(e => e.FLINSTANCEID)
                    .HasName("PK__SYS_FLIN__CEF2B5B56EF57B66");

                entity.Property(e => e.FLINSTANCEID).HasMaxLength(50);

                entity.Property(e => e.INFO).HasMaxLength(200);

                entity.Property(e => e.STATE)
                    .IsRequired()
                    .HasColumnType("image");
            });

            modelBuilder.Entity<SYS_LANGUAGE>(entity =>
            {
                entity.Property(e => e.CHS).HasMaxLength(80);

                entity.Property(e => e.CHT).HasMaxLength(80);

                entity.Property(e => e.EN).HasMaxLength(80);

                entity.Property(e => e.HK).HasMaxLength(80);

                entity.Property(e => e.IDENTIFICATION).HasMaxLength(80);

                entity.Property(e => e.JA).HasMaxLength(80);

                entity.Property(e => e.KEYS).HasMaxLength(80);

                entity.Property(e => e.KO).HasMaxLength(80);

                entity.Property(e => e.LAN1).HasMaxLength(80);

                entity.Property(e => e.LAN2).HasMaxLength(80);
            });

            modelBuilder.Entity<SYS_MESSENGER>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MESSAGE).HasMaxLength(255);

                entity.Property(e => e.PARAS).HasMaxLength(255);

                entity.Property(e => e.RECTIME).HasMaxLength(14);

                entity.Property(e => e.SENDERID).HasMaxLength(20);

                entity.Property(e => e.SENDTIME).HasMaxLength(14);

                entity.Property(e => e.STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.USERID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_ORG>(entity =>
            {
                entity.HasKey(e => e.ORG_NO)
                    .HasName("PK__SYS_ORG__666FC9CB5812160E");

                entity.HasIndex(e => e.ORG_NO)
                    .HasName("IDX_ORG_NO");

                entity.HasIndex(e => e.UPPER_ORG)
                    .HasName("IDX_UPPER_ORG");

                entity.Property(e => e.ORG_NO).HasMaxLength(8);

                entity.Property(e => e.COSTCENTERID).HasMaxLength(10);

                entity.Property(e => e.END_ORG).HasMaxLength(4);

                entity.Property(e => e.LEVEL_NO)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.ORG_DESC)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ORG_FULLNAME).HasMaxLength(254);

                entity.Property(e => e.ORG_KIND)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.ORG_MAN)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ORG_TREE).HasMaxLength(40);

                entity.Property(e => e.UPPER_ORG).HasMaxLength(8);
            });

            modelBuilder.Entity<SYS_ORGKIND>(entity =>
            {
                entity.HasKey(e => e.ORG_KIND)
                    .HasName("PK__SYS_ORGK__DD6566D15BE2A6F2");

                entity.Property(e => e.ORG_KIND).HasMaxLength(4);

                entity.Property(e => e.KIND_DESC)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<SYS_ORGLEVEL>(entity =>
            {
                entity.HasKey(e => e.LEVEL_NO)
                    .HasName("PK__SYS_ORGL__C485BA795FB337D6");

                entity.Property(e => e.LEVEL_NO).HasMaxLength(6);

                entity.Property(e => e.LEVEL_DESC)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<SYS_ORGROLES>(entity =>
            {
                entity.HasKey(e => new { e.ORG_NO, e.ROLE_ID })
                    .HasName("PK__SYS_ORGR__53C384E96383C8BA");

                entity.HasIndex(e => e.ORG_NO)
                    .HasName("IDX_ORG_NO");

                entity.HasIndex(e => e.ROLE_ID)
                    .HasName("IDX_ROLE_ID");

                entity.Property(e => e.ORG_NO).HasMaxLength(8);

                entity.Property(e => e.ROLE_ID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ORG_KIND).HasMaxLength(4);
            });

            modelBuilder.Entity<SYS_PERSONAL>(entity =>
            {
                entity.HasKey(e => new { e.FORMNAME, e.COMPNAME, e.USERID })
                    .HasName("PK__SYS_PERS__78C6C0565070F446");

                entity.Property(e => e.FORMNAME).HasMaxLength(60);

                entity.Property(e => e.COMPNAME).HasMaxLength(30);

                entity.Property(e => e.USERID).HasMaxLength(20);

                entity.Property(e => e.CREATEDATE).HasColumnType("datetime");

                entity.Property(e => e.PROPCONTENT).HasColumnType("ntext");

                entity.Property(e => e.REMARK).HasMaxLength(30);
            });

            modelBuilder.Entity<SYS_REFVAL>(entity =>
            {
                entity.HasKey(e => e.REFVAL_NO);

                entity.Property(e => e.REFVAL_NO)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CAPTION)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DESCRIPTION)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DISPLAY_MEMBER)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SELECT_ALIAS)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SELECT_COMMAND)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TABLE_NAME)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VALUE_MEMBER)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_REFVAL_D1>(entity =>
            {
                entity.HasKey(e => new { e.REFVAL_NO, e.FIELD_NAME });

                entity.Property(e => e.REFVAL_NO)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FIELD_NAME)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HEADER_TEXT)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SYS_REPORT>(entity =>
            {
                entity.HasKey(e => new { e.REPORTID, e.FILENAME })
                    .HasName("PK__SYS_REPO__B22E3EEE4CA06362");

                entity.Property(e => e.REPORTID).HasMaxLength(50);

                entity.Property(e => e.FILENAME).HasMaxLength(50);

                entity.Property(e => e.CLIENT_QUERY).HasColumnType("image");

                entity.Property(e => e.DATASOURCES).HasColumnType("image");

                entity.Property(e => e.DATASOURCE_PROVIDER).HasMaxLength(50);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(50);

                entity.Property(e => e.FIELDFONT).HasColumnType("image");

                entity.Property(e => e.FIELDITEMS).HasColumnType("image");

                entity.Property(e => e.FILEPATH).HasMaxLength(50);

                entity.Property(e => e.FOOTERFONT).HasColumnType("image");

                entity.Property(e => e.FOOTERITEMS).HasColumnType("image");

                entity.Property(e => e.FORMAT).HasColumnType("image");

                entity.Property(e => e.HEADERFONT).HasColumnType("image");

                entity.Property(e => e.HEADERITEMS).HasColumnType("image");

                entity.Property(e => e.HEADERREPEAT).HasMaxLength(5);

                entity.Property(e => e.IMAGES).HasColumnType("image");

                entity.Property(e => e.MAILSETTING).HasColumnType("image");

                entity.Property(e => e.OUTPUTMODE).HasMaxLength(20);

                entity.Property(e => e.PARAMETERS).HasColumnType("image");

                entity.Property(e => e.REPORTNAME).HasMaxLength(50);

                entity.Property(e => e.REPORT_TYPE).HasMaxLength(1);

                entity.Property(e => e.SETTING).HasColumnType("image");

                entity.Property(e => e.TEMPLATE_DESC).HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_ROLES_AGENT>(entity =>
            {
                entity.HasKey(e => new { e.ROLE_ID, e.AGENT, e.FLOW_DESC })
                    .HasName("PK__SYS_ROLE__E4CD69766754599E");

                entity.HasIndex(e => e.ROLE_ID)
                    .HasName("ROLEID");

                entity.Property(e => e.ROLE_ID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AGENT).HasMaxLength(20);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(40);

                entity.Property(e => e.END_DATE)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.END_TIME).HasMaxLength(6);

                entity.Property(e => e.PAR_AGENT)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.REMARK).HasMaxLength(254);

                entity.Property(e => e.START_DATE)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.START_TIME).HasMaxLength(6);
            });

            modelBuilder.Entity<SYS_TODOHIS>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.LISTID)
                    .HasName("LISTID");

                entity.HasIndex(e => e.USER_ID)
                    .HasName("USERID");

                entity.Property(e => e.ATTACHMENTS).HasMaxLength(255);

                entity.Property(e => e.CREATE_TIME).HasMaxLength(50);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EXP_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FLNAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FLOWIMPORTANT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOWURGENT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(40);

                entity.Property(e => e.FLOW_ID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FORM_KEYS).HasMaxLength(254);

                entity.Property(e => e.FORM_NAME).HasMaxLength(30);

                entity.Property(e => e.FORM_PRESENTATION).HasMaxLength(254);

                entity.Property(e => e.FORM_PRESENT_CT).HasMaxLength(254);

                entity.Property(e => e.FORM_TABLE).HasMaxLength(30);

                entity.Property(e => e.LEVEL_NO).HasMaxLength(6);

                entity.Property(e => e.LISTID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.NAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.PARAMETERS).HasMaxLength(254);

                entity.Property(e => e.PROC_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.REMARK).HasMaxLength(254);

                entity.Property(e => e.ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SENDBACKSTEP).HasMaxLength(2);

                entity.Property(e => e.STATUS).HasMaxLength(4);

                entity.Property(e => e.S_ROLE_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.S_STEP_DESC).HasMaxLength(64);

                entity.Property(e => e.S_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.S_USERNAME).HasMaxLength(30);

                entity.Property(e => e.S_USER_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TIME_UNIT)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(10);

                entity.Property(e => e.UPDATE_TIME).HasMaxLength(8);

                entity.Property(e => e.USERNAME).HasMaxLength(30);

                entity.Property(e => e.USER_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VDSNAME).HasMaxLength(40);

                entity.Property(e => e.VERSION).HasMaxLength(2);

                entity.Property(e => e.WEBFORM_NAME)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SYS_TODOLIST>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.FLOW_DESC)
                    .HasName("idx_FLOW_DESC");

                entity.HasIndex(e => e.FORM_KEYS)
                    .HasName("idx_FROM_KEY");

                entity.HasIndex(e => e.FORM_PRESENTATION)
                    .HasName("idx_FORM_PRESENTATION");

                entity.HasIndex(e => e.LISTID)
                    .HasName("idx_ListID");

                entity.HasIndex(e => e.SENDTO_ID)
                    .HasName("idx_SENDTO_ID");

                entity.Property(e => e.APPLICANT)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ATTACHMENTS).HasMaxLength(255);

                entity.Property(e => e.CREATE_TIME).HasMaxLength(50);

                entity.Property(e => e.D_STEP_DESC).HasMaxLength(64);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EMAIL_ADD).HasMaxLength(40);

                entity.Property(e => e.EMAIL_STATUS)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EXP_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.FLNAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FLOWIMPORTANT)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FLOWPATH)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FLOWURGENT)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(40);

                entity.Property(e => e.FLOW_ID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FORM_KEYS).HasMaxLength(254);

                entity.Property(e => e.FORM_NAME).HasMaxLength(30);

                entity.Property(e => e.FORM_PRESENTATION).HasMaxLength(254);

                entity.Property(e => e.FORM_PRESENT_CT)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.FORM_TABLE).HasMaxLength(30);

                entity.Property(e => e.LEVEL_NO).HasMaxLength(6);

                entity.Property(e => e.LISTID)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.MULTISTEPRETURN)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NAVIGATOR_MODE)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.PARAMETERS).HasMaxLength(254);

                entity.Property(e => e.PLUSAPPROVE)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PLUSROLES)
                    .IsRequired()
                    .HasMaxLength(254);

                entity.Property(e => e.PROVIDER_NAME).HasMaxLength(254);

                entity.Property(e => e.REMARK).HasMaxLength(254);

                entity.Property(e => e.SENDBACKSTEP).HasMaxLength(2);

                entity.Property(e => e.SENDTO_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SENDTO_KIND)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.SENDTO_NAME).HasMaxLength(30);

                entity.Property(e => e.STATUS).HasMaxLength(4);

                entity.Property(e => e.S_STEP_DESC).HasMaxLength(64);

                entity.Property(e => e.S_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.S_USER_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TIME_UNIT)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.UPDATE_DATE).HasMaxLength(10);

                entity.Property(e => e.UPDATE_TIME).HasMaxLength(8);

                entity.Property(e => e.URGENT_TIME).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.USERNAME).HasMaxLength(30);

                entity.Property(e => e.VDSNAME).HasMaxLength(40);

                entity.Property(e => e.VERSION).HasMaxLength(2);

                entity.Property(e => e.WEBFORM_NAME)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<USERGROUPS>(entity =>
            {
                entity.HasKey(e => new { e.USERID, e.GROUPID })
                    .HasName("PK__USERGROU__F96A63571BFD2C07");

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GROUPID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<USERMENUCONTROL>(entity =>
            {
                entity.HasKey(e => new { e.USERID, e.MENUID, e.CONTROLNAME })
                    .HasName("PK__USERMENU__656ABBC63D5E1FD2");

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CONTROLNAME)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ALLOWADD)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWDELETE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWPRINT)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ALLOWUPDATE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ENABLED)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TYPE)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VISIBLE)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<USERMENUS>(entity =>
            {
                entity.HasKey(e => new { e.USERID, e.MENUID })
                    .HasName("PK__USERMENU__934C56AF0CBAE877");

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MENUID).HasMaxLength(30);
            });

            modelBuilder.Entity<USERS>(entity =>
            {
                entity.HasKey(e => e.USERID)
                    .HasName("PK__USERS__7B9E7F351FCDBCEB");

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AGENT).HasMaxLength(20);

                entity.Property(e => e.AUTOLOGIN).HasMaxLength(1);

                entity.Property(e => e.CREATEDATE).HasMaxLength(8);

                entity.Property(e => e.CREATER).HasMaxLength(20);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(100);

                entity.Property(e => e.EMAIL).HasMaxLength(40);

                entity.Property(e => e.Ext).HasMaxLength(8);

                entity.Property(e => e.LASTDATE).HasMaxLength(8);

                entity.Property(e => e.LASTTIME).HasMaxLength(8);

                entity.Property(e => e.MSAD).HasMaxLength(1);

                entity.Property(e => e.PWD).HasMaxLength(10);

                entity.Property(e => e.SIGNATURE).HasMaxLength(30);

                entity.Property(e => e.USERNAME).HasMaxLength(30);
            });

            modelBuilder.Entity<ViewDept>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDept");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.DisplayCode)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.ManagerEmpId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ParentCode).HasMaxLength(8);
            });

            modelBuilder.Entity<ViewDeptTree>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDeptTree");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ViewEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewEmp");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CompCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.DeptCode)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.JobCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.JoblCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(10);

                entity.Property(e => e.Ttscode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewJob");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ViewJobl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewJobl");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EmpCategoryCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_SYS_ORG>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_SYS_ORG");

                entity.Property(e => e.ORG_DESC)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ORG_MAN)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ORG_NO)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.UPPER_ORG).HasMaxLength(8);

                entity.Property(e => e.USERID)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<View_SYS_TODOLIST>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_SYS_TODOLIST");

                entity.Property(e => e.APPLICANT)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.APPLYDESCR).HasMaxLength(100);

                entity.Property(e => e.AUDITOR).HasMaxLength(100);

                entity.Property(e => e.BILLNO).HasMaxLength(100);

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FLOW_DESC).HasMaxLength(40);

                entity.Property(e => e.S_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UPDATEDATE).HasMaxLength(19);

                entity.Property(e => e.USERNAME).HasMaxLength(30);
            });

            modelBuilder.Entity<View_SYS_TODOLIST_STEP>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_SYS_TODOLIST_STEP");

                entity.Property(e => e.D_STEP_ID)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<View_ToDoList_Applicant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ToDoList_Applicant");

                entity.Property(e => e.APPLICANT)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<View_ToDoList_Auditor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ToDoList_Auditor");

                entity.Property(e => e.AUDITOR).HasMaxLength(30);
            });

            modelBuilder.Entity<View_ToDoList_Flow_Desc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_ToDoList_Flow_Desc");

                entity.Property(e => e.FLOW_DESC).HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
