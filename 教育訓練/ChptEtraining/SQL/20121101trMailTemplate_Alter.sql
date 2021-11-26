/*
   2012年11月1日下午 02:16:20
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
CREATE TABLE dbo.Tmp_trMailTemplate
	(
	iAutoKey int NOT NULL IDENTITY (1, 1),
	sName nvarchar(50) NOT NULL,
	sMailSubject nvarchar(50) NULL,
	sMailContent nvarchar(MAX) NULL,
	dKeyMan nvarchar(50) NULL,
	dKeyDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_trMailTemplate SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_trMailTemplate ON
GO
IF EXISTS(SELECT * FROM dbo.trMailTemplate)
	 EXEC('INSERT INTO dbo.Tmp_trMailTemplate (iAutoKey, sName, sMailSubject, sMailContent, dKeyMan, dKeyDate)
		SELECT iAutoKey, sName, sMailSubject, CONVERT(nvarchar(MAX), sMailContent), dKeyMan, dKeyDate FROM dbo.trMailTemplate WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_trMailTemplate OFF
GO
DROP TABLE dbo.trMailTemplate
GO
EXECUTE sp_rename N'dbo.Tmp_trMailTemplate', N'trMailTemplate', 'OBJECT' 
GO
ALTER TABLE dbo.trMailTemplate ADD CONSTRAINT
	PK_trMailTemplate PRIMARY KEY CLUSTERED 
	(
	iAutoKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
