using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JBHRIS.Api.Dal.ezFlow.Entity.ezFlow
{
    public partial class ezFlowContext : DbContext
    {
        public ezFlowContext()
        {
        }

        public ezFlowContext(DbContextOptions<ezFlowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheckAgent> CheckAgents { get; set; }
        public virtual DbSet<CheckAgentDate> CheckAgentDates { get; set; }
        public virtual DbSet<CheckAgentDept> CheckAgentDepts { get; set; }
        public virtual DbSet<CheckAgentFlowTree> CheckAgentFlowTrees { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<DeptLevel> DeptLevels { get; set; }
        public virtual DbSet<Emp> Emps { get; set; }
        public virtual DbSet<EmpAgentDate> EmpAgentDates { get; set; }
        public virtual DbSet<EmpBak> EmpBaks { get; set; }
        public virtual DbSet<FlowControl> FlowControls { get; set; }
        public virtual DbSet<FlowControlCode> FlowControlCodes { get; set; }
        public virtual DbSet<FlowGroup> FlowGroups { get; set; }
        public virtual DbSet<FlowLink> FlowLinks { get; set; }
        public virtual DbSet<FlowLinkPower> FlowLinkPowers { get; set; }
        public virtual DbSet<FlowNode> FlowNodes { get; set; }
        public virtual DbSet<FlowTree> FlowTrees { get; set; }
        public virtual DbSet<FlowTreePower> FlowTreePowers { get; set; }
        public virtual DbSet<FlowTreePowerRoleOnly> FlowTreePowerRoleOnlies { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormsApp> FormsApps { get; set; }
        public virtual DbSet<FormsAppAb> FormsAppAbs { get; set; }
        public virtual DbSet<FormsAppAbn> FormsAppAbns { get; set; }
        public virtual DbSet<FormsAppAbsDay> FormsAppAbsDays { get; set; }
        public virtual DbSet<FormsAppAbsc> FormsAppAbscs { get; set; }
        public virtual DbSet<FormsAppAppoint> FormsAppAppoints { get; set; }
        public virtual DbSet<FormsAppAppointChangeLog> FormsAppAppointChangeLogs { get; set; }
        public virtual DbSet<FormsAppCard> FormsAppCards { get; set; }
        public virtual DbSet<FormsAppEmploy> FormsAppEmploys { get; set; }
        public virtual DbSet<FormsAppEmployChangeLog> FormsAppEmployChangeLogs { get; set; }
        public virtual DbSet<FormsAppEmploySalary> FormsAppEmploySalaries { get; set; }
        public virtual DbSet<FormsAppInfo> FormsAppInfos { get; set; }
        public virtual DbSet<FormsAppOt> FormsAppOts { get; set; }
        public virtual DbSet<FormsAppShiftLong> FormsAppShiftLongs { get; set; }
        public virtual DbSet<FormsAppShiftShort> FormsAppShiftShorts { get; set; }
        public virtual DbSet<FormsExtend> FormsExtends { get; set; }
        public virtual DbSet<FormsSign> FormsSigns { get; set; }
        public virtual DbSet<HRD_MESSAGE> HRD_MESSAGEs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<NodeAgentInit> NodeAgentInits { get; set; }
        public virtual DbSet<NodeCustom> NodeCustoms { get; set; }
        public virtual DbSet<NodeDynamic> NodeDynamics { get; set; }
        public virtual DbSet<NodeEnd> NodeEnds { get; set; }
        public virtual DbSet<NodeForm> NodeForms { get; set; }
        public virtual DbSet<NodeInit> NodeInits { get; set; }
        public virtual DbSet<NodeMail> NodeMails { get; set; }
        public virtual DbSet<NodeMang> NodeMangs { get; set; }
        public virtual DbSet<NodeMangLoopBreak> NodeMangLoopBreaks { get; set; }
        public virtual DbSet<NodeMultiInit> NodeMultiInits { get; set; }
        public virtual DbSet<NodeMultiStart> NodeMultiStarts { get; set; }
        public virtual DbSet<NodeService> NodeServices { get; set; }
        public virtual DbSet<NodeStart> NodeStarts { get; set; }
        public virtual DbSet<Notice> Notices { get; set; }
        public virtual DbSet<OrgImport> OrgImports { get; set; }
        public virtual DbSet<Po> Pos { get; set; }
        public virtual DbSet<PosLevel> PosLevels { get; set; }
        public virtual DbSet<ProcessApParm> ProcessApParms { get; set; }
        public virtual DbSet<ProcessApView> ProcessApViews { get; set; }
        public virtual DbSet<ProcessCheck> ProcessChecks { get; set; }
        public virtual DbSet<ProcessException> ProcessExceptions { get; set; }
        public virtual DbSet<ProcessFlow> ProcessFlows { get; set; }
        public virtual DbSet<ProcessFlowShare> ProcessFlowShares { get; set; }
        public virtual DbSet<ProcessID> ProcessIDs { get; set; }
        public virtual DbSet<ProcessMultiFlow> ProcessMultiFlows { get; set; }
        public virtual DbSet<ProcessNode> ProcessNodes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SendMailParm> SendMailParms { get; set; }
        public virtual DbSet<SysAdmin> SysAdmins { get; set; }
        public virtual DbSet<SysVar> SysVars { get; set; }
        public virtual DbSet<View_wfAppAbsAndShiftRote> View_wfAppAbsAndShiftRotes { get; set; }
        public virtual DbSet<WorkAgent> WorkAgents { get; set; }
        public virtual DbSet<WorkAgentPower> WorkAgentPowers { get; set; }
        public virtual DbSet<tempBase> tempBases { get; set; }
        public virtual DbSet<tempDept> tempDepts { get; set; }
        public virtual DbSet<tempPo> tempPos { get; set; }
        public virtual DbSet<wfAppAb> wfAppAbs { get; set; }
        public virtual DbSet<wfAppAbsDetail> wfAppAbsDetails { get; set; }
        public virtual DbSet<wfAppAbsTran> wfAppAbsTrans { get; set; }
        public virtual DbSet<wfAppAbsc> wfAppAbscs { get; set; }
        public virtual DbSet<wfAppAgent> wfAppAgents { get; set; }
        public virtual DbSet<wfAppAttendUnusual> wfAppAttendUnusuals { get; set; }
        public virtual DbSet<wfAppCard> wfAppCards { get; set; }
        public virtual DbSet<wfAppCardPatch> wfAppCardPatches { get; set; }
        public virtual DbSet<wfAppOt> wfAppOts { get; set; }
        public virtual DbSet<wfAppShiftRote> wfAppShiftRotes { get; set; }
        public virtual DbSet<wfAppShiftRoteDetail> wfAppShiftRoteDetails { get; set; }
        public virtual DbSet<wfDynamic> wfDynamics { get; set; }
        public virtual DbSet<wfForm> wfForms { get; set; }
        public virtual DbSet<wfFormApp> wfFormApps { get; set; }
        public virtual DbSet<wfFormAppCode> wfFormAppCodes { get; set; }
        public virtual DbSet<wfFormAppInfo> wfFormAppInfos { get; set; }
        public virtual DbSet<wfFormCode> wfFormCodes { get; set; }
        public virtual DbSet<wfFormColumn> wfFormColumns { get; set; }
        public virtual DbSet<wfFormDataGroup> wfFormDataGroups { get; set; }
        public virtual DbSet<wfFormMail> wfFormMails { get; set; }
        public virtual DbSet<wfFormSignM> wfFormSignMs { get; set; }
        public virtual DbSet<wfFormUploadFile> wfFormUploadFiles { get; set; }
        public virtual DbSet<wfMultiFlow> wfMultiFlows { get; set; }
        public virtual DbSet<wfSendMail> wfSendMails { get; set; }
        public virtual DbSet<wfSendMailLog> wfSendMailLogs { get; set; }
        public virtual DbSet<wfWebValidate> wfWebValidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =192.168.1.12;Initial Catalog =ezFlow; User ID = jb;Password =^Hsx9bu5t@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<CheckAgent>(entity =>
            {
                entity.HasKey(e => e.auto)
                    .HasName("PK_CheckAgent_1");

                entity.ToTable("CheckAgent");

                entity.Property(e => e.Emp_idSource).HasMaxLength(50);

                entity.Property(e => e.Emp_idTarget).HasMaxLength(50);

                entity.Property(e => e.Guid).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Role_idSource).HasMaxLength(100);

                entity.Property(e => e.Role_idTarget).HasMaxLength(100);
            });

            modelBuilder.Entity<CheckAgentDate>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("CheckAgentDate");

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.Emp_idSource)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Emp_idTarget)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.Role_idSource)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CheckAgentDept>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("CheckAgentDept");

                entity.Property(e => e.CheckAgent_Guid).HasMaxLength(50);

                entity.Property(e => e.Dept_id).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);
            });

            modelBuilder.Entity<CheckAgentFlowTree>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("CheckAgentFlowTree");

                entity.Property(e => e.CheckAgent_Guid).HasMaxLength(50);

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.ToTable("Dept");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.DeptLevel_id).HasMaxLength(50);

                entity.Property(e => e.idParent).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.path).HasMaxLength(2000);
            });

            modelBuilder.Entity<DeptLevel>(entity =>
            {
                entity.ToTable("DeptLevel");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.sorting).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.ToTable("Emp");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.login).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(100);

                entity.Property(e => e.pw).HasMaxLength(50);

                entity.Property(e => e.sex).HasMaxLength(50);
            });

            modelBuilder.Entity<EmpAgentDate>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("EmpAgentDate");

                entity.HasIndex(e => new { e.Emp_id, e.dateB, e.dateE, e.IsValid }, "IX_EmpAgentDate")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Emp_id)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.KeyMan).HasMaxLength(50);

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmpBak>(entity =>
            {
                entity.ToTable("EmpBak");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.login).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(100);

                entity.Property(e => e.pw).HasMaxLength(50);

                entity.Property(e => e.sex).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowControl>(entity =>
            {
                entity.HasKey(e => e.iAutokey);

                entity.ToTable("FlowControl");

                entity.Property(e => e.dKeydate).HasColumnType("datetime");

                entity.Property(e => e.sForm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sValue).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowControlCode>(entity =>
            {
                entity.HasKey(e => e.Autokey);

                entity.ToTable("FlowControlCode");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Form)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Value).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowGroup>(entity =>
            {
                entity.ToTable("FlowGroup");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");

                entity.Property(e => e.idParent).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowLink>(entity =>
            {
                entity.ToTable("FlowLink");

                entity.HasIndex(e => new { e.id, e.FlowTree_id, e.FlowNode_idSource }, "IX_FlowLink");

                entity.HasIndex(e => new { e.FlowNode_idSource, e.FlowTree_id }, "IX_FlowLink_1");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.FlowNode_ArrowSource).HasMaxLength(50);

                entity.Property(e => e.FlowNode_ArrowTarget).HasMaxLength(50);

                entity.Property(e => e.FlowNode_idSource).HasMaxLength(50);

                entity.Property(e => e.FlowNode_idTarget).HasMaxLength(50);

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.linkStyle).HasMaxLength(50);

                entity.Property(e => e.linkType).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowLinkPower>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("FlowLinkPower");

                entity.HasIndex(e => e.FlowLink_id, "IX_FlowLinkPower");

                entity.Property(e => e.FlowLink_id).HasMaxLength(50);

                entity.Property(e => e.criteria1).HasMaxLength(50);

                entity.Property(e => e.criteria2).HasMaxLength(50);

                entity.Property(e => e.criteria3).HasMaxLength(50);

                entity.Property(e => e.criteria4).HasMaxLength(50);

                entity.Property(e => e.criteria5).HasMaxLength(50);

                entity.Property(e => e.criteria6).HasMaxLength(50);

                entity.Property(e => e.fdName1).HasMaxLength(50);

                entity.Property(e => e.fdName2).HasMaxLength(50);

                entity.Property(e => e.fdName3).HasMaxLength(50);

                entity.Property(e => e.fdName4).HasMaxLength(50);

                entity.Property(e => e.fdName5).HasMaxLength(50);

                entity.Property(e => e.fdName6).HasMaxLength(50);

                entity.Property(e => e.fdType1).HasMaxLength(50);

                entity.Property(e => e.fdType2).HasMaxLength(50);

                entity.Property(e => e.fdType3).HasMaxLength(50);

                entity.Property(e => e.fdType4).HasMaxLength(50);

                entity.Property(e => e.fdType5).HasMaxLength(50);

                entity.Property(e => e.fdType6).HasMaxLength(50);

                entity.Property(e => e.maxValue1).HasMaxLength(50);

                entity.Property(e => e.maxValue2).HasMaxLength(50);

                entity.Property(e => e.maxValue3).HasMaxLength(50);

                entity.Property(e => e.maxValue4).HasMaxLength(50);

                entity.Property(e => e.maxValue5).HasMaxLength(50);

                entity.Property(e => e.maxValue6).HasMaxLength(50);

                entity.Property(e => e.minValue1).HasMaxLength(50);

                entity.Property(e => e.minValue2).HasMaxLength(50);

                entity.Property(e => e.minValue3).HasMaxLength(50);

                entity.Property(e => e.minValue4).HasMaxLength(50);

                entity.Property(e => e.minValue5).HasMaxLength(50);

                entity.Property(e => e.minValue6).HasMaxLength(50);

                entity.Property(e => e.note).HasMaxLength(255);

                entity.Property(e => e.tableName).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowNode>(entity =>
            {
                entity.ToTable("FlowNode");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.Batch).HasDefaultValueSql("((1))");

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.nodeType).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowTree>(entity =>
            {
                entity.ToTable("FlowTree");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.FlowGroup_id).HasMaxLength(50);

                entity.Property(e => e.Tpye).HasMaxLength(50);

                entity.Property(e => e.ViewImage).HasColumnType("image");

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowTreePower>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("FlowTreePower");

                entity.Property(e => e.Dept_path).HasMaxLength(2000);

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);
            });

            modelBuilder.Entity<FlowTreePowerRoleOnly>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("FlowTreePowerRoleOnly");

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(50);
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.FlowTreeId).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SaveMethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SaveUrl)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsApp>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsApp");

                entity.HasIndex(e => new { e.AutoKey, e.EmpId, e.Sign, e.SignState, e.idProcess, e.RoleId }, "IX_FormsApp");

                entity.HasIndex(e => new { e.AutoKey, e.EmpId, e.ProcessID, e.Sign, e.SignState, e.RoleId }, "IX_FormsApp_1");

                entity.HasIndex(e => new { e.AutoKey, e.EmpId, e.ProcessID, e.DateTimeA, e.DateTimeD }, "IX_FormsApp_2");

                entity.Property(e => e.Cond01).HasMaxLength(50);

                entity.Property(e => e.Cond02).HasMaxLength(50);

                entity.Property(e => e.Cond03).HasMaxLength(50);

                entity.Property(e => e.Cond04).HasMaxLength(50);

                entity.Property(e => e.Cond05).HasMaxLength(50);

                entity.Property(e => e.Cond06).HasMaxLength(50);

                entity.Property(e => e.Cond07).HasMaxLength(50);

                entity.Property(e => e.Cond08).HasMaxLength(50);

                entity.Property(e => e.Cond09).HasMaxLength(50);

                entity.Property(e => e.Cond10).HasMaxLength(50);

                entity.Property(e => e.DateTimeA).HasColumnType("datetime");

                entity.Property(e => e.DateTimeD).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.FormsCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SignState).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppAb>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.Property(e => e.AgentEmpId).HasMaxLength(50);

                entity.Property(e => e.AgentEmpName).HasMaxLength(50);

                entity.Property(e => e.Balance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventMan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ExceptionUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.HolidayCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.Use).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<FormsAppAbn>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppAbn");

                entity.Property(e => e.AbnCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppAbsDay>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppAbsDay");

                entity.Property(e => e.AbsCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE).HasColumnType("datetime");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoteCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RotehCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.Use).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.idProcess)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppAbsc>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppAbsc");

                entity.Property(e => e.AppAbsCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.HolidayCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.Use).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<FormsAppAppoint>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppAppoint");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.ChangeItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ChangeItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateAppoint).HasColumnType("datetime");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.DeptNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmCode).HasMaxLength(50);

                entity.Property(e => e.DeptmCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmName).HasMaxLength(50);

                entity.Property(e => e.DeptmNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.Evaluation).IsRequired();

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.JobNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblCode).HasMaxLength(50);

                entity.Property(e => e.JoblCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblName).HasMaxLength(50);

                entity.Property(e => e.JoblNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Performance1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Performance2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Performance3)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qualified).IsRequired();

                entity.Property(e => e.ReasonChange).IsRequired();

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SchoolCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sex).HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppAppointChangeLog>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppAppointChangeLog");

                entity.Property(e => e.AppointCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAppoint).HasColumnType("datetime");

                entity.Property(e => e.DeptCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SalaryContent).IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppCard>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppCard");

                entity.Property(e => e.CardLostCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CardLostName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

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

            modelBuilder.Entity<FormsAppEmploy>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppEmploy");

                entity.Property(e => e.AttendContent).IsRequired();

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateA).HasColumnType("datetime");

                entity.Property(e => e.DateAppoint).HasColumnType("datetime");

                entity.Property(e => e.DateD).HasColumnType("datetime");

                entity.Property(e => e.DateIn).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.DeptNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmCode).HasMaxLength(50);

                entity.Property(e => e.DeptmCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmName).HasMaxLength(50);

                entity.Property(e => e.DeptmNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.JobNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblCode).HasMaxLength(50);

                entity.Property(e => e.JoblCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblName).HasMaxLength(50);

                entity.Property(e => e.JoblNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResultAreaCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResultAreaName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.SchoolCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.WorkExperience).IsRequired();
            });

            modelBuilder.Entity<FormsAppEmployChangeLog>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppEmployChangeLog");

                entity.Property(e => e.DateAppoint).HasColumnType("datetime");

                entity.Property(e => e.DeptCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptmNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmployCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblCodeChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JoblNameChange)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Performance01).IsRequired();

                entity.Property(e => e.Performance02).IsRequired();

                entity.Property(e => e.Performance03).IsRequired();

                entity.Property(e => e.Performance04).IsRequired();

                entity.Property(e => e.Performance05).IsRequired();

                entity.Property(e => e.ResultAreaCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResultAreaName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SalaryContent).IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppEmploySalary>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppEmploySalary");

                entity.Property(e => e.EmployCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EncodeMoneyValue).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.MoneyValue).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.SalaryCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SalaryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppInfo>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppInfo");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KeyDate).HasColumnType("datetime");

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppOt>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppOt");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateB1).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DateE1).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB).HasColumnType("datetime");

                entity.Property(e => e.DateTimeB1).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE).HasColumnType("datetime");

                entity.Property(e => e.DateTimeE1).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.DeptsCode).HasMaxLength(50);

                entity.Property(e => e.DeptsName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.ExceptionUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.OtCateCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtCateName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtrcdCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtrcdName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.RoteCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RotehCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RotehName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeB1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeE1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);

                entity.Property(e => e.Use).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<FormsAppShiftLong>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppShiftLong");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.RotetCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RotetCodeOrigin)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RotetName).HasMaxLength(50);

                entity.Property(e => e.RotetNameOrigin).HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsAppShiftShort>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsAppShiftShort");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateB).HasColumnType("datetime");

                entity.Property(e => e.DateE).HasColumnType("datetime");

                entity.Property(e => e.DeptCode).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobName).HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId).HasMaxLength(100);

                entity.Property(e => e.RoteCodeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoteCodeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoteNameB).HasMaxLength(50);

                entity.Property(e => e.RoteNameE).HasMaxLength(50);

                entity.Property(e => e.SignState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<FormsExtend>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsExtend");

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

            modelBuilder.Entity<FormsSign>(entity =>
            {
                entity.HasKey(e => e.AutoKey);

                entity.ToTable("FormsSign");

                entity.HasIndex(e => new { e.AutoKey, e.EmpId, e.ProcessId }, "IX_FormsSign");

                entity.HasIndex(e => new { e.AutoKey, e.EmpId, e.idProcess }, "IX_FormsSign_1");

                entity.Property(e => e.DeptCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormsCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.InsertMan).HasMaxLength(50);

                entity.Property(e => e.JobCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Key2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProcessId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateMan).HasMaxLength(50);
            });

            modelBuilder.Entity<HRD_MESSAGE>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("HRD_MESSAGE");

                entity.Property(e => e.CODE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CREATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.CREATE_MAN).HasMaxLength(50);

                entity.Property(e => e.LANGUAGE1).HasMaxLength(200);

                entity.Property(e => e.LANGUAGE2).HasMaxLength(200);

                entity.Property(e => e.LANGUAGE3).HasMaxLength(200);

                entity.Property(e => e.LANGUAGE4).HasMaxLength(200);

                entity.Property(e => e.LANGUAGE5).HasMaxLength(200);

                entity.Property(e => e.MESSAGE_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.UPDATE_DATE).HasColumnType("datetime");

                entity.Property(e => e.UPDATE_MAN).HasMaxLength(50);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.sCode);

                entity.ToTable("Menu");

                entity.Property(e => e.sCode).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sParentCode).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeAgentInit>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeAgentInit");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeCustom>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeCustom");

                entity.HasIndex(e => new { e.FlowNode_id, e.Role_id }, "IX_NodeCustom");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(100);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeDynamic>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeDynamic");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);

                entity.Property(e => e.fdEmp).HasMaxLength(50);

                entity.Property(e => e.fdRole).HasMaxLength(100);

                entity.Property(e => e.tableName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeEnd>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeEnd");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeForm>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeForm");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeInit>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeInit");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeMail>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeMail");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.customEmail).HasMaxLength(50);

                entity.Property(e => e.dynamicFdMail).HasMaxLength(50);

                entity.Property(e => e.dynamicTable).HasMaxLength(50);

                entity.Property(e => e.mailContent).HasMaxLength(255);

                entity.Property(e => e.receiveType).HasMaxLength(50);

                entity.Property(e => e.subject).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeMang>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeMang");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeMangLoopBreak>(entity =>
            {
                entity.HasKey(e => e.auto)
                    .HasName("PK_NodeCheckLoopBreak");

                entity.ToTable("NodeMangLoopBreak");

                entity.HasIndex(e => e.FlowNode_id, "IX_NodeMangLoopBreak");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.criteria1).HasMaxLength(50);

                entity.Property(e => e.criteria2).HasMaxLength(50);

                entity.Property(e => e.criteria3).HasMaxLength(50);

                entity.Property(e => e.criteria4).HasMaxLength(50);

                entity.Property(e => e.criteria5).HasMaxLength(50);

                entity.Property(e => e.criteria6).HasMaxLength(50);

                entity.Property(e => e.fdName1).HasMaxLength(50);

                entity.Property(e => e.fdName2).HasMaxLength(50);

                entity.Property(e => e.fdName3).HasMaxLength(50);

                entity.Property(e => e.fdName4).HasMaxLength(50);

                entity.Property(e => e.fdName5).HasMaxLength(50);

                entity.Property(e => e.fdName6).HasMaxLength(50);

                entity.Property(e => e.fdType1).HasMaxLength(50);

                entity.Property(e => e.fdType2).HasMaxLength(50);

                entity.Property(e => e.fdType3).HasMaxLength(50);

                entity.Property(e => e.fdType4).HasMaxLength(50);

                entity.Property(e => e.fdType5).HasMaxLength(50);

                entity.Property(e => e.fdType6).HasMaxLength(50);

                entity.Property(e => e.maxValue1).HasMaxLength(50);

                entity.Property(e => e.maxValue2).HasMaxLength(50);

                entity.Property(e => e.maxValue3).HasMaxLength(50);

                entity.Property(e => e.maxValue4).HasMaxLength(50);

                entity.Property(e => e.maxValue5).HasMaxLength(50);

                entity.Property(e => e.maxValue6).HasMaxLength(50);

                entity.Property(e => e.minValue1).HasMaxLength(50);

                entity.Property(e => e.minValue2).HasMaxLength(50);

                entity.Property(e => e.minValue3).HasMaxLength(50);

                entity.Property(e => e.minValue4).HasMaxLength(50);

                entity.Property(e => e.minValue5).HasMaxLength(50);

                entity.Property(e => e.minValue6).HasMaxLength(50);

                entity.Property(e => e.note).HasMaxLength(255);

                entity.Property(e => e.tableName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeMultiInit>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeMultiInit");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.apName).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeMultiStart>(entity =>
            {
                entity.HasKey(e => e.auto)
                    .HasName("PK_NodeMulti");

                entity.ToTable("NodeMultiStart");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.FlowTree_idSub).HasMaxLength(50);
            });

            modelBuilder.Entity<NodeService>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeService");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.Metod).HasMaxLength(255);

                entity.Property(e => e.webSrvUrl).HasMaxLength(255);
            });

            modelBuilder.Entity<NodeStart>(entity =>
            {
                entity.HasKey(e => e.FlowNode_id);

                entity.ToTable("NodeStart");

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.tableName).HasMaxLength(50);

                entity.Property(e => e.viewAp).HasMaxLength(50);

                entity.Property(e => e.virtualPath).HasMaxLength(50);
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("Notice");

                entity.Property(e => e.dDateA).HasColumnType("datetime");

                entity.Property(e => e.dDateD).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTitle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<OrgImport>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("OrgImport");

                entity.Property(e => e.sDeptTopCode).HasMaxLength(50);

                entity.Property(e => e.sFrontLoginID).HasMaxLength(50);

                entity.Property(e => e.sTestMail).HasMaxLength(200);
            });

            modelBuilder.Entity<Po>(entity =>
            {
                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.PosLevel_id).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<PosLevel>(entity =>
            {
                entity.ToTable("PosLevel");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<ProcessApParm>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessApParm");

                entity.HasIndex(e => e.ProcessFlow_id, "IX_ProcessApParm")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ProcessCheck_auto, e.ProcessFlow_id, e.ProcessNode_auto }, "IX_ProcessApParm_1")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(100);
            });

            modelBuilder.Entity<ProcessApView>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessApView");

                entity.HasIndex(e => e.ProcessFlow_id, "IX_ProcessApView")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.Emp_id, "IX_ProcessApView_1")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(100);

                entity.Property(e => e.tag1).HasMaxLength(50);

                entity.Property(e => e.tag2).HasMaxLength(50);

                entity.Property(e => e.tag3).HasMaxLength(50);
            });

            modelBuilder.Entity<ProcessCheck>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessCheck");

                entity.HasIndex(e => e.ProcessNode_auto, "IX_ProcessCheck")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ProcessNode_auto, e.Emp_idDefault }, "IX_ProcessCheck_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.Emp_idAgent, e.Emp_idDefault, e.Emp_idReal, e.adate, e.ProcessNode_auto }, "IX_ProcessCheck_2")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ProcessNode_auto, e.Emp_idDefault, e.Emp_idAgent }, "IX_ProcessCheck_3")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.auto, e.Emp_idDefault, e.Emp_idAgent }, "IX_ProcessCheck_4")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Emp_idAgent).HasMaxLength(50);

                entity.Property(e => e.Emp_idDefault).HasMaxLength(50);

                entity.Property(e => e.Emp_idReal).HasMaxLength(50);

                entity.Property(e => e.Role_idAgent).HasMaxLength(100);

                entity.Property(e => e.Role_idDefault).HasMaxLength(100);

                entity.Property(e => e.Role_idReal).HasMaxLength(100);

                entity.Property(e => e.adate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProcessException>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessException");

                entity.Property(e => e.adate).HasColumnType("datetime");

                entity.Property(e => e.errorMsg).HasMaxLength(255);

                entity.Property(e => e.errorType).HasMaxLength(50);
            });

            modelBuilder.Entity<ProcessFlow>(entity =>
            {
                entity.ToTable("ProcessFlow");

                entity.HasIndex(e => new { e.id, e.isFinish, e.isCancel, e.isError }, "IX_ProcessFlow")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.id, e.isCancel, e.isError, e.isFinish, e.adate }, "IX_ProcessFlow_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.isFinish, e.isCancel }, "IX_ProcessFlow_2");

                entity.HasIndex(e => new { e.id, e.Emp_id, e.FlowTree_id, e.isFinish }, "IX_ProcessFlow_3")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.ProcessNode_auto).HasDefaultValueSql("((0))");

                entity.Property(e => e.Role_id).HasMaxLength(100);

                entity.Property(e => e.adate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProcessFlowShare>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessFlowShare");

                entity.HasIndex(e => e.ProcessFlow_id, "IX_ProcessFlowShare")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.Emp_id, "IX_ProcessFlowShare_1")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(100);
            });

            modelBuilder.Entity<ProcessID>(entity =>
            {
                entity.HasKey(e => e.value)
                    .HasName("PK_GetProcessID");

                entity.ToTable("ProcessID");

                entity.HasIndex(e => e.value, "IX_ProcessID")
                    .IsUnique();

                entity.Property(e => e.genDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(sysdatetime())");

                entity.Property(e => e.key).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ProcessMultiFlow>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessMultiFlow");

                entity.Property(e => e.SubDynamicEmp_id).HasMaxLength(50);

                entity.Property(e => e.SubDynamicRole_id).HasMaxLength(100);

                entity.Property(e => e.SubFlowTree_id).HasMaxLength(50);

                entity.Property(e => e.SubInitEmp_id).HasMaxLength(50);

                entity.Property(e => e.SubInitRole_id).HasMaxLength(100);
            });

            modelBuilder.Entity<ProcessNode>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("ProcessNode");

                entity.HasIndex(e => new { e.ProcessNode_idPrior, e.ProcessFlow_id, e.FlowNode_id }, "IX_ProcessNode")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.isFinish, "IX_ProcessNode4");

                entity.HasIndex(e => e.ProcessFlow_id, "IX_ProcessNode_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ProcessFlow_id, e.isFinish }, "IX_ProcessNode_2")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.auto, e.isFinish }, "IX_ProcessNode_3")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.FlowNode_id).HasMaxLength(50);

                entity.Property(e => e.ManageLevel).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.adate).HasColumnType("datetime");

                entity.Property(e => e.isMulti).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("Role");

                entity.HasIndex(e => e.Emp_id, "IX_Role")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.id, "IX_Role_1")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Dept_id).HasMaxLength(50);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Pos_id).HasMaxLength(50);

                entity.Property(e => e.dateB).HasColumnType("datetime");

                entity.Property(e => e.dateE).HasColumnType("datetime");

                entity.Property(e => e.id).HasMaxLength(100);

                entity.Property(e => e.idParent).HasMaxLength(100);

                entity.Property(e => e.sort).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SendMailParm>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("SendMailParm");

                entity.Property(e => e.customEmail).HasMaxLength(50);
            });

            modelBuilder.Entity<SysAdmin>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("SysAdmin");

                entity.Property(e => e.Emp_id).HasMaxLength(50);
            });

            modelBuilder.Entity<SysVar>(entity =>
            {
                entity.HasKey(e => e.urlRoot);

                entity.ToTable("SysVar");

                entity.Property(e => e.urlRoot).HasMaxLength(50);

                entity.Property(e => e.mailID).HasMaxLength(50);

                entity.Property(e => e.mailPW).HasMaxLength(50);

                entity.Property(e => e.mailServer).HasMaxLength(50);

                entity.Property(e => e.senderMail).HasMaxLength(50);

                entity.Property(e => e.senderName).HasMaxLength(50);

                entity.Property(e => e.webSrvURL).HasMaxLength(100);
            });

            modelBuilder.Entity<View_wfAppAbsAndShiftRote>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_wfAppAbsAndShiftRote");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.employid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.enddate).HasColumnType("datetime");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.startdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WorkAgent>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("WorkAgent");

                entity.Property(e => e.Emp_idSource).HasMaxLength(50);

                entity.Property(e => e.Emp_idTarget).HasMaxLength(50);

                entity.Property(e => e.Guid).HasMaxLength(50);

                entity.Property(e => e.Role_idSource).HasMaxLength(100);

                entity.Property(e => e.Role_idTarget).HasMaxLength(100);
            });

            modelBuilder.Entity<WorkAgentPower>(entity =>
            {
                entity.HasKey(e => e.auto);

                entity.ToTable("WorkAgentPower");

                entity.Property(e => e.FlowTree_id).HasMaxLength(50);

                entity.Property(e => e.WorkAgent_Guid).HasMaxLength(50);
            });

            modelBuilder.Entity<tempBase>(entity =>
            {
                entity.ToTable("tempBase");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.dept).HasMaxLength(50);

                entity.Property(e => e.depts).HasMaxLength(50);

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.job).HasMaxLength(50);

                entity.Property(e => e.jobl).HasMaxLength(50);

                entity.Property(e => e.jobs).HasMaxLength(50);

                entity.Property(e => e.login).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);

                entity.Property(e => e.pw).HasMaxLength(50);

                entity.Property(e => e.sex).HasMaxLength(50);
            });

            modelBuilder.Entity<tempDept>(entity =>
            {
                entity.ToTable("tempDept");

                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.DeptLevel_id).HasMaxLength(50);

                entity.Property(e => e.idParent).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<tempPo>(entity =>
            {
                entity.Property(e => e.id).HasMaxLength(50);

                entity.Property(e => e.PosLevel_id).HasMaxLength(50);

                entity.Property(e => e.name).HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppAb>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.Property(e => e.BaseHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseD).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseH).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateE).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dEventDate).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.iBalance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iDay).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iExceptionHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iMinute).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iTotalDay).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iTotalHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.sAgentName).HasMaxLength(50);

                entity.Property(e => e.sAgentNobr).HasMaxLength(50);

                entity.Property(e => e.sAgentNote).HasMaxLength(2000);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sHcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sHname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sKeyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sPlace).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sRote).HasMaxLength(50);

                entity.Property(e => e.sSalYYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sUnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<wfAppAbsDetail>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppAbsDetail");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.iUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.sAbsKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppAbsTran>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.Property(e => e.dAbsPlusDateB).HasColumnType("datetime");

                entity.Property(e => e.dAbsPlusDateE).HasColumnType("datetime");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dEventDate).HasColumnType("datetime");

                entity.Property(e => e.iAbsPlusBalance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iAbsPlusMax).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iAbsPlusUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iBalance).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.sAbsDetailKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sAbsPlusHcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sAbsPlusKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sAbsPlusTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sAbsPlusTimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sHcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppAbsc>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppAbsc");

                entity.Property(e => e.BaseHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseD).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseH).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.UseM).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.dDate).HasColumnType("datetime");

                entity.Property(e => e.dDateTime).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.iUse).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.sCode1).HasMaxLength(50);

                entity.Property(e => e.sCode2).HasMaxLength(50);

                entity.Property(e => e.sCode3).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sHcode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sHname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sName1).HasMaxLength(50);

                entity.Property(e => e.sName2).HasMaxLength(50);

                entity.Property(e => e.sName3).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sUnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sYYMM)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppAgent>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppAgent");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sAgentMail).HasMaxLength(200);

                entity.Property(e => e.sAgentName).HasMaxLength(50);

                entity.Property(e => e.sAgentNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sNote).HasMaxLength(2000);
            });

            modelBuilder.Entity<wfAppAttendUnusual>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppAttendUnusual");

                entity.Property(e => e.ErrorStateCode).HasMaxLength(50);

                entity.Property(e => e.ErrorStateName).HasMaxLength(50);

                entity.Property(e => e.dCardDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dCardDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dDate).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.sCode1).HasMaxLength(50);

                entity.Property(e => e.sCode2).HasMaxLength(50);

                entity.Property(e => e.sCode3).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sName1).HasMaxLength(50);

                entity.Property(e => e.sName2).HasMaxLength(50);

                entity.Property(e => e.sName3).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonName).HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppCard>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppCard");

                entity.Property(e => e.dCardDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dCardDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dDate).HasColumnType("datetime");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateE).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.sCode1).HasMaxLength(50);

                entity.Property(e => e.sCode2).HasMaxLength(50);

                entity.Property(e => e.sCode3).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sName1).HasMaxLength(50);

                entity.Property(e => e.sName2).HasMaxLength(50);

                entity.Property(e => e.sName3).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonCode1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonCode2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonName1).HasMaxLength(50);

                entity.Property(e => e.sReasonName2).HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppCardPatch>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppCardPatch");

                entity.Property(e => e.ErrorStateCode).HasMaxLength(50);

                entity.Property(e => e.ErrorStateName).HasMaxLength(50);

                entity.Property(e => e.dCardDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dCardDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dDate).HasColumnType("datetime");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateE).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dRoteDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.sCode1).HasMaxLength(50);

                entity.Property(e => e.sCode2).HasMaxLength(50);

                entity.Property(e => e.sCode3).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sName1).HasMaxLength(50);

                entity.Property(e => e.sName2).HasMaxLength(50);

                entity.Property(e => e.sName3).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonCode1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonCode2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReasonName1).HasMaxLength(50);

                entity.Property(e => e.sReasonName2).HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppOt>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppOt");

                entity.Property(e => e.dDateB).HasColumnType("datetime");

                entity.Property(e => e.dDateB1).HasColumnType("datetime");

                entity.Property(e => e.dDateE).HasColumnType("datetime");

                entity.Property(e => e.dDateE1).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeB1).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeE1).HasColumnType("datetime");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.iExceptionHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iTotalHour).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.iTotalHour1).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.sDI).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpcd).HasMaxLength(50);

                entity.Property(e => e.sEmpcdName).HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid).HasMaxLength(50);

                entity.Property(e => e.sInfo).HasMaxLength(2000);

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sJobl).HasMaxLength(50);

                entity.Property(e => e.sJoblName).HasMaxLength(50);

                entity.Property(e => e.sMailBody).HasMaxLength(2000);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sNote).HasMaxLength(2000);

                entity.Property(e => e.sOtDeptCode).HasMaxLength(50);

                entity.Property(e => e.sOtDeptName).HasMaxLength(50);

                entity.Property(e => e.sOtcatCode).HasMaxLength(50);

                entity.Property(e => e.sOtcatName).HasMaxLength(50);

                entity.Property(e => e.sOtrcdCode).HasMaxLength(50);

                entity.Property(e => e.sOtrcdName).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReserve1).HasMaxLength(2000);

                entity.Property(e => e.sReserve2).HasMaxLength(2000);

                entity.Property(e => e.sReserve3).HasMaxLength(2000);

                entity.Property(e => e.sReserve4).HasMaxLength(2000);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sRote).HasMaxLength(50);

                entity.Property(e => e.sRoteCode).HasMaxLength(50);

                entity.Property(e => e.sRoteName).HasMaxLength(50);

                entity.Property(e => e.sSalYYMM)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeB1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sTimeE1)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppShiftRote>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppShiftRote");

                entity.Property(e => e.bDifferShift)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sCode1).HasMaxLength(50);

                entity.Property(e => e.sCode2).HasMaxLength(50);

                entity.Property(e => e.sCode3).HasMaxLength(50);

                entity.Property(e => e.sDept1).HasMaxLength(50);

                entity.Property(e => e.sDept2).HasMaxLength(50);

                entity.Property(e => e.sDeptName1).HasMaxLength(50);

                entity.Property(e => e.sDeptName2).HasMaxLength(50);

                entity.Property(e => e.sEmpCode1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sEmpCode2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sEmpID1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sEmpID2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sJob1).HasMaxLength(50);

                entity.Property(e => e.sJob2).HasMaxLength(50);

                entity.Property(e => e.sJobName1).HasMaxLength(50);

                entity.Property(e => e.sJobName2).HasMaxLength(50);

                entity.Property(e => e.sName1).HasMaxLength(50);

                entity.Property(e => e.sName11).HasMaxLength(50);

                entity.Property(e => e.sName2).HasMaxLength(50);

                entity.Property(e => e.sName21).HasMaxLength(50);

                entity.Property(e => e.sName3).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRole1).HasMaxLength(100);

                entity.Property(e => e.sRole2).HasMaxLength(100);

                entity.Property(e => e.sShiftDate).HasMaxLength(200);

                entity.Property(e => e.sShiftRoteName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sShiftRoteType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfAppShiftRoteDetail>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfAppShiftRoteDetail");

                entity.Property(e => e.dShiftRoteDate).HasColumnType("datetime");

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRote1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRote2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRoteName1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRoteName2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sShiftRoteKey)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfDynamic>(entity =>
            {
                entity.HasKey(e => new { e.idProcess, e.idFlowNode });

                entity.ToTable("wfDynamic");

                entity.Property(e => e.idFlowNode).HasMaxLength(50);

                entity.Property(e => e.Emp_id).HasMaxLength(50);

                entity.Property(e => e.Role_id).HasMaxLength(100);
            });

            modelBuilder.Entity<wfForm>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfForm");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.s1).HasMaxLength(200);

                entity.Property(e => e.s2).HasMaxLength(200);

                entity.Property(e => e.s3).HasMaxLength(200);

                entity.Property(e => e.s4).HasMaxLength(200);

                entity.Property(e => e.s5).HasMaxLength(200);

                entity.Property(e => e.sCheckNote).HasMaxLength(2000);

                entity.Property(e => e.sEtcNote).HasMaxLength(2000);

                entity.Property(e => e.sFlowTree).HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormName).HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(200);

                entity.Property(e => e.sSaveMetod).HasMaxLength(50);

                entity.Property(e => e.sSaveUrl).HasMaxLength(255);

                entity.Property(e => e.sStdNote).HasMaxLength(2000);

                entity.Property(e => e.sTableName).HasMaxLength(200);

                entity.Property(e => e.sViewNote).HasMaxLength(2000);
            });

            modelBuilder.Entity<wfFormApp>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormApp");

                entity.Property(e => e.dDateTimeA).HasColumnType("datetime");

                entity.Property(e => e.dDateTimeD).HasColumnType("datetime");

                entity.Property(e => e.sConditions1).HasMaxLength(50);

                entity.Property(e => e.sConditions2).HasMaxLength(50);

                entity.Property(e => e.sConditions3).HasMaxLength(50);

                entity.Property(e => e.sConditions4).HasMaxLength(50);

                entity.Property(e => e.sConditions5).HasMaxLength(50);

                entity.Property(e => e.sConditions6).HasMaxLength(50);

                entity.Property(e => e.sDI).HasMaxLength(50);

                entity.Property(e => e.sDecode).HasMaxLength(50);

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName).HasMaxLength(50);

                entity.Property(e => e.sEmpCode).HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormName).HasMaxLength(50);

                entity.Property(e => e.sInfo).HasMaxLength(2000);

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sJobl).HasMaxLength(50);

                entity.Property(e => e.sJoblName).HasMaxLength(50);

                entity.Property(e => e.sJsonInfo).HasMaxLength(2000);

                entity.Property(e => e.sLevel).HasMaxLength(50);

                entity.Property(e => e.sLimitTime).HasMaxLength(50);

                entity.Property(e => e.sMailSign).HasMaxLength(2000);

                entity.Property(e => e.sMailSubject).HasMaxLength(2000);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sNote).HasMaxLength(2000);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sReserve1).HasMaxLength(2000);

                entity.Property(e => e.sReserve2).HasMaxLength(2000);

                entity.Property(e => e.sReserve3).HasMaxLength(2000);

                entity.Property(e => e.sReserve4).HasMaxLength(2000);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sState).HasMaxLength(50);

                entity.Property(e => e.sYear).HasMaxLength(50);
            });

            modelBuilder.Entity<wfFormAppCode>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormAppCode");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sContent).HasMaxLength(2000);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormName).HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(200);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfFormAppInfo>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormAppInfo");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sInfo).HasMaxLength(2000);

                entity.Property(e => e.sName).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sState)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfFormCode>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormCode");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sCategory)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sContent).HasMaxLength(2000);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<wfFormColumn>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(200);
            });

            modelBuilder.Entity<wfFormDataGroup>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormDataGroup");

                entity.Property(e => e.sDataGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<wfFormMail>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormMail");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sName).HasMaxLength(200);
            });

            modelBuilder.Entity<wfFormSignM>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormSignM");

                entity.Property(e => e.ChiefCode).HasMaxLength(50);

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sDept).HasMaxLength(50);

                entity.Property(e => e.sDeptName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sDeptNameTo).HasMaxLength(50);

                entity.Property(e => e.sDeptTo).HasMaxLength(50);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sJob).HasMaxLength(50);

                entity.Property(e => e.sJobName).HasMaxLength(50);

                entity.Property(e => e.sJobNameTo).HasMaxLength(50);

                entity.Property(e => e.sJobTo).HasMaxLength(50);

                entity.Property(e => e.sKey1).HasMaxLength(50);

                entity.Property(e => e.sKey2).HasMaxLength(50);

                entity.Property(e => e.sName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sNameTo).HasMaxLength(50);

                entity.Property(e => e.sNobr).HasMaxLength(50);

                entity.Property(e => e.sNobrTo).HasMaxLength(50);

                entity.Property(e => e.sNodeCode).HasMaxLength(50);

                entity.Property(e => e.sNodeName).HasMaxLength(50);

                entity.Property(e => e.sProcessID).HasMaxLength(50);

                entity.Property(e => e.sRole).HasMaxLength(100);

                entity.Property(e => e.sRoleTo).HasMaxLength(100);
            });

            modelBuilder.Entity<wfFormUploadFile>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfFormUploadFile");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sDescription).HasMaxLength(2000);

                entity.Property(e => e.sFormCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFormName).HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey2).HasMaxLength(50);

                entity.Property(e => e.sNobr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sServerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.sType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.sUpName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<wfMultiFlow>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfMultiFlow");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sEmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sFlowTreeId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sRoleId)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.sSubEmpId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sSubName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sSubProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sSubRoleId)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<wfSendMail>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfSendMail");

                entity.HasIndex(e => new { e.idProcess, e.sGuid, e.bOnly, e.dKeyDate }, "IX_wfSendMail")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sBody).IsRequired();

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sSubject)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.sToAddress).HasMaxLength(200);

                entity.Property(e => e.sToName).HasMaxLength(50);
            });

            modelBuilder.Entity<wfSendMailLog>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfSendMailLog");

                entity.HasIndex(e => new { e.sGuid, e.sKey1, e.sKey2 }, "IX_wfSendMailLog")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.sGuid, "IX_wfSendMailLog_1")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.sGuid, "sGuid_20200515");

                entity.Property(e => e.dKeyDate).HasColumnType("datetime");

                entity.Property(e => e.sFromAddress).HasMaxLength(200);

                entity.Property(e => e.sFromName).HasMaxLength(50);

                entity.Property(e => e.sGuid)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sKey1).HasMaxLength(50);

                entity.Property(e => e.sKey2).HasMaxLength(50);

                entity.Property(e => e.sKeyMan).HasMaxLength(50);

                entity.Property(e => e.sProcessID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.sSubject).HasMaxLength(200);

                entity.Property(e => e.sToAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.sToName).HasMaxLength(50);
            });

            modelBuilder.Entity<wfWebValidate>(entity =>
            {
                entity.HasKey(e => e.iAutoKey);

                entity.ToTable("wfWebValidate");

                entity.HasIndex(e => e.sValidateKey, "IX_wfWebValidate")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.dDateOpen).HasColumnType("datetime");

                entity.Property(e => e.dDateWriter).HasColumnType("datetime");

                entity.Property(e => e.sParm)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.sValidateKey)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
