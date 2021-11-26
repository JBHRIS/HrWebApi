/*
   2012年2月20日上午 09:16:00
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
ALTER TABLE dbo.trTrainingPlan
	DROP CONSTRAINT DF_trTrainingPlan_bEditable
GO
CREATE TABLE dbo.Tmp_trTrainingPlan
	(
	iAutoKey int NOT NULL IDENTITY (1, 1),
	iYear int NOT NULL,
	sPolicy nvarchar(2000) NULL,
	sProspect nvarchar(2000) NULL,
	sGoal nvarchar(2000) NULL,
	sNote nvarchar(2000) NULL,
	sKeyMan nvarchar(50) NULL,
	dKeyDate datetime NULL,
	bEditable bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_trTrainingPlan SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_trTrainingPlan ADD CONSTRAINT
	DF_trTrainingPlan_bEditable DEFAULT ((1)) FOR bEditable
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingPlan ON
GO
IF EXISTS(SELECT * FROM dbo.trTrainingPlan)
	 EXEC('INSERT INTO dbo.Tmp_trTrainingPlan (iAutoKey, iYear, sPolicy, sKeyMan, dKeyDate, bEditable)
		SELECT iAutoKey, iYear, sPolicy, sKeyMan, dKeyDate, bEditable FROM dbo.trTrainingPlan WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingPlan OFF
GO
DROP TABLE dbo.trTrainingPlan
GO
EXECUTE sp_rename N'dbo.Tmp_trTrainingPlan', N'trTrainingPlan', 'OBJECT' 
GO
ALTER TABLE dbo.trTrainingPlan ADD CONSTRAINT
	PK_trTrainingPlan PRIMARY KEY CLUSTERED 
	(
	iAutoKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
