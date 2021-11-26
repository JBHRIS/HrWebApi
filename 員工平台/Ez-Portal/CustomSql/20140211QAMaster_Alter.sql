/*
   2014年2月11日下午 04:02:17
   使用者: jb
   伺服器: jb-vsts
   資料庫: SUPERMILL_eTraining
   應用程式: 
*/

/* 為了避免任何可能發生資料遺失的問題，您應該先詳細檢視此指令碼，然後才能在資料庫設計工具環境以外的位置執行。*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_QAMaster
	(
	Id int NOT NULL IDENTITY (1, 1),
	ClassAutoKey int NOT NULL,
	QTplCode nvarchar(50) NOT NULL,
	Nobr nvarchar(50) NULL,
	sysRole int NULL,
	TeacherCode nvarchar(50) NULL,
	SupervisorNobr nvarchar(50) NULL,
	FillerCategory nvarchar(50) NOT NULL,
	DeptCode nvarchar(50) NULL,
	WriteDate datetime NULL,
	FillFormDatetimeB datetime NULL,
	FillFormDatetimeE datetime NULL,
	TeacherCheckedDate datetime NULL,
	TRCheckedDate datetime NULL,
	TotalScore int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_QAMaster SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_QAMaster ON
GO
IF EXISTS(SELECT * FROM dbo.QAMaster)
	 EXEC('INSERT INTO dbo.Tmp_QAMaster (Id, ClassAutoKey, QTplCode, Nobr, sysRole, TeacherCode, FillerCategory, DeptCode, WriteDate, FillFormDatetimeB, FillFormDatetimeE, TeacherCheckedDate, TRCheckedDate, TotalScore)
		SELECT Id, ClassAutoKey, QTplCode, Nobr, sysRole, TeacherCode, FillerCategory, DeptCode, WriteDate, FillFormDatetimeB, FillFormDatetimeE, TeacherCheckedDate, TRCheckedDate, TotalScore FROM dbo.QAMaster WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_QAMaster OFF
GO
DROP TABLE dbo.QAMaster
GO
EXECUTE sp_rename N'dbo.Tmp_QAMaster', N'QAMaster', 'OBJECT' 
GO
ALTER TABLE dbo.QAMaster ADD CONSTRAINT
	PK_QAMaster PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.QAMaster', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.QAMaster', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.QAMaster', 'Object', 'CONTROL') as Contr_Per 