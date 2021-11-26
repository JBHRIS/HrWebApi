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
ALTER TABLE dbo.NotifyDetail
	DROP CONSTRAINT DF_NotifyDetail_Recipient
GO
ALTER TABLE dbo.NotifyDetail
	DROP CONSTRAINT DF_NotifyDetail_ContentArgQuery
GO
CREATE TABLE dbo.Tmp_NotifyDetail
	(
	Id int NOT NULL IDENTITY (1, 1),
	Pid int NOT NULL,
	Comp nvarchar(50) NOT NULL,
	Subject nvarchar(500) NOT NULL,
	Body nvarchar(MAX) NOT NULL,
	Recipient nvarchar(MAX) NOT NULL,
	Status nvarchar(50) NOT NULL,
	Remark nvarchar(500) NOT NULL,
	CreateTime datetime NOT NULL,
	CreateMan nvarchar(50) NOT NULL,
	ContentArgQuery nvarchar(MAX) NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_NotifyDetail SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_NotifyDetail ADD CONSTRAINT
	DF_NotifyDetail_Recipient DEFAULT ('') FOR Recipient
GO
ALTER TABLE dbo.Tmp_NotifyDetail ADD CONSTRAINT
	DF_NotifyDetail_ContentArgQuery DEFAULT ('') FOR ContentArgQuery
GO
SET IDENTITY_INSERT dbo.Tmp_NotifyDetail ON
GO
IF EXISTS(SELECT * FROM dbo.NotifyDetail)
	 EXEC('INSERT INTO dbo.Tmp_NotifyDetail (Id, Pid, Comp, Subject, Body, Recipient, Status, Remark, CreateTime, CreateMan, ContentArgQuery)
		SELECT Id, Pid, Comp, Subject, Body, Recipient, Status, Remark, CreateTime, CreateMan, ContentArgQuery FROM dbo.NotifyDetail WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_NotifyDetail OFF
GO
DROP TABLE dbo.NotifyDetail
GO
EXECUTE sp_rename N'dbo.Tmp_NotifyDetail', N'NotifyDetail', 'OBJECT' 
GO
ALTER TABLE dbo.NotifyDetail ADD CONSTRAINT
	PK_NotifyDetail PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
