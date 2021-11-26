/*
   2013年9月4日上午 10:16:29
   使用者: jb
   伺服器: jb-vsts
   資料庫: CHPT_eTraining
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
ALTER TABLE dbo.QuestDeptCustom3
	DROP CONSTRAINT DF_QuestDeptCustom3_IsRejection
GO
CREATE TABLE dbo.Tmp_QuestDeptCustom3
	(
	Id int NOT NULL IDENTITY (1, 1),
	Year int NOT NULL,
	CourseName nvarchar(50) NOT NULL,
	DeptCode nvarchar(50) NOT NULL,
	TrainingMethodCode nvarchar(50) NULL,
	Amt int NULL,
	StudentNum int NULL,
	Month int NULL,
	Minutes int NULL,
	IsRejection bit NOT NULL,
	IsRequired bit NOT NULL,
	Rejecter nvarchar(50) NULL,
	DeptReject nvarchar(50) NULL,
	SuggestionPassItem nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_QuestDeptCustom3 SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_QuestDeptCustom3 ADD CONSTRAINT
	DF_QuestDeptCustom3_IsRejection DEFAULT ((0)) FOR IsRejection
GO
ALTER TABLE dbo.Tmp_QuestDeptCustom3 ADD CONSTRAINT
	DF_QuestDeptCustom3_IsRequired DEFAULT 1 FOR IsRequired
GO
SET IDENTITY_INSERT dbo.Tmp_QuestDeptCustom3 ON
GO
IF EXISTS(SELECT * FROM dbo.QuestDeptCustom3)
	 EXEC('INSERT INTO dbo.Tmp_QuestDeptCustom3 (Id, Year, CourseName, DeptCode, TrainingMethodCode, Amt, StudentNum, Month, Minutes, IsRejection, Rejecter, DeptReject, SuggestionPassItem)
		SELECT Id, Year, CourseName, DeptCode, TrainingMethodCode, Amt, StudentNum, Month, Minutes, IsRejection, Rejecter, DeptReject, SuggestionPassItem FROM dbo.QuestDeptCustom3 WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_QuestDeptCustom3 OFF
GO
DROP TABLE dbo.QuestDeptCustom3
GO
EXECUTE sp_rename N'dbo.Tmp_QuestDeptCustom3', N'QuestDeptCustom3', 'OBJECT' 
GO
ALTER TABLE dbo.QuestDeptCustom3 ADD CONSTRAINT
	PK_QuestDeptCustom3 PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.QuestDeptCustom3', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.QuestDeptCustom3', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.QuestDeptCustom3', 'Object', 'CONTROL') as Contr_Per 