/*
   2013年11月27日上午 09:17:55
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
ALTER TABLE dbo.MeetingRoom ADD
	DispBackColor int NULL
GO
ALTER TABLE dbo.MeetingRoom SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.MeetingRoom', 'Object', 'CONTROL') as Contr_Per 