/*
   2013年11月25日下午 10:09:42
   使用者: jb
   伺服器: 192.168.1.24
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
CREATE TABLE dbo.MeetingRoom
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	EnableSchedueRent bit NOT NULL,
	CanRent bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.MeetingRoom ADD CONSTRAINT
	DF_MeetingRoom_EnableSchedueRent DEFAULT 0 FOR EnableSchedueRent
GO
ALTER TABLE dbo.MeetingRoom ADD CONSTRAINT
	DF_MeetingRoom_CanRent DEFAULT 1 FOR CanRent
GO
ALTER TABLE dbo.MeetingRoom ADD CONSTRAINT
	PK_MeetingRoom PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.MeetingRoom SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'CONTROL') as Contr_Per 