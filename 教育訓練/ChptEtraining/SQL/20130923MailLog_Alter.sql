/*
   2013年9月23日上午 11:37:03
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
CREATE TABLE dbo.Tmp_MailLog
	(
	iAutoKey int NOT NULL IDENTITY (1, 1),
	MailTemplate int NULL,
	MailSubject nvarchar(MAX) NULL,
	MailContent nvarchar(MAX) NULL,
	MailAddressee nvarchar(MAX) NULL,
	ErrorMsg nvarchar(MAX) NULL,
	sKeyMan nvarchar(50) NULL,
	dKeyDate datetime NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_MailLog SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_MailLog ON
GO
IF EXISTS(SELECT * FROM dbo.MailLog)
	 EXEC('INSERT INTO dbo.Tmp_MailLog (iAutoKey, MailTemplate, MailSubject, MailContent, MailAddressee, ErrorMsg, sKeyMan, dKeyDate)
		SELECT iAutoKey, MailTemplate, CONVERT(nvarchar(MAX), MailSubject), CONVERT(nvarchar(MAX), MailContent), CONVERT(nvarchar(MAX), MailAddressee), CONVERT(nvarchar(MAX), ErrorMsg), sKeyMan, dKeyDate FROM dbo.MailLog WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_MailLog OFF
GO
DROP TABLE dbo.MailLog
GO
EXECUTE sp_rename N'dbo.Tmp_MailLog', N'MailLog', 'OBJECT' 
GO
ALTER TABLE dbo.MailLog ADD CONSTRAINT
	PK_MailLog PRIMARY KEY CLUSTERED 
	(
	iAutoKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
