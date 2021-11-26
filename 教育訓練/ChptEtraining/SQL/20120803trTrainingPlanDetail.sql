/*
   2012年8月3日上午 09:33:04
   使用者: jb
   伺服器: jb-vsts
   資料庫: Formosa_eLearning
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
ALTER TABLE dbo.trTrainingPlanDetail
	DROP CONSTRAINT DF_trTrainingPlanDetail_CourseType
GO
CREATE TABLE dbo.Tmp_trTrainingPlanDetail
	(
	iAutoKey int NOT NULL IDENTITY (1, 1),
	iYear int NOT NULL,
	iSession int NULL,
	iMonth int NOT NULL,
	trCourse_sCode nvarchar(50) NOT NULL,
	sKey nvarchar(50) NOT NULL,
	CourseType nvarchar(50) NULL,
	iMins int NOT NULL,
	iNumOfPeople int NOT NULL,
	iAmt int NOT NULL,
	iClassAutoKey int NULL,
	sKeyMan nvarchar(50) NULL,
	dKeyDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_trTrainingPlanDetail SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_trTrainingPlanDetail ADD CONSTRAINT
	DF_trTrainingPlanDetail_CourseType DEFAULT (N'OTHERS') FOR CourseType
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingPlanDetail ON
GO
IF EXISTS(SELECT * FROM dbo.trTrainingPlanDetail)
	 EXEC('INSERT INTO dbo.Tmp_trTrainingPlanDetail (iAutoKey, iYear, iSession, iMonth, trCourse_sCode, sKey, CourseType, iMins, iNumOfPeople, iAmt, iClassAutoKey, sKeyMan, dKeyDate)
		SELECT iAutoKey, iYear, iSession, iMonth, trCourse_sCode, sKey, CourseType, iMins, iNumOfPeople, iAmt, iClassAutoKey, sKeyMan, dKeyDate FROM dbo.trTrainingPlanDetail WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingPlanDetail OFF
GO
DROP TABLE dbo.trTrainingPlanDetail
GO
EXECUTE sp_rename N'dbo.Tmp_trTrainingPlanDetail', N'trTrainingPlanDetail', 'OBJECT' 
GO
ALTER TABLE dbo.trTrainingPlanDetail ADD CONSTRAINT
	PK_trTrainingPlanDetail PRIMARY KEY CLUSTERED 
	(
	iAutoKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_trTrainingPlanDetail_iMonth ON dbo.trTrainingPlanDetail
	(
	iMonth
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_trTrainingPlanDetail_iSession ON dbo.trTrainingPlanDetail
	(
	iSession
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
COMMIT
