/*
   2014年3月4日下午 02:15:42
   使用者: jb
   伺服器: jb-vsts
   資料庫: CHPTHR
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
ALTER TABLE dbo.QA_Published
	DROP CONSTRAINT DF_QA_Published_IsPublished
GO
CREATE TABLE dbo.Tmp_QA_Published
	(
	Id int NOT NULL IDENTITY (1, 1),
	QTplCode nvarchar(50) NOT NULL,
	PublishDatetime datetime NOT NULL,
	FillFormDatetimeB datetime NOT NULL,
	FillFormDatetimeE datetime NOT NULL,
	IsPublished bit NOT NULL,
	WritedBy nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_QA_Published SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_QA_Published ADD CONSTRAINT
	DF_QA_Published_IsPublished DEFAULT ((0)) FOR IsPublished
GO
SET IDENTITY_INSERT dbo.Tmp_QA_Published ON
GO
IF EXISTS(SELECT * FROM dbo.QA_Published)
	 EXEC('INSERT INTO dbo.Tmp_QA_Published (Id, QTplCode, PublishDatetime, FillFormDatetimeB, FillFormDatetimeE, IsPublished, WritedBy)
		SELECT Id, CONVERT(nvarchar(50), QTplId), PublishDatetime, FillFormDatetimeB, FillFormDatetimeE, IsPublished, WritedBy FROM dbo.QA_Published WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_QA_Published OFF
GO
DROP TABLE dbo.QA_Published
GO
EXECUTE sp_rename N'dbo.Tmp_QA_Published', N'QA_Published', 'OBJECT' 
GO
ALTER TABLE dbo.QA_Published ADD CONSTRAINT
	PK_QA_Published PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.QA_Published', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.QA_Published', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.QA_Published', 'Object', 'CONTROL') as Contr_Per 