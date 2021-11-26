/*
   2013年5月17日下午 02:18:19
   使用者: jb
   伺服器: jb-vsts\sql2012
   資料庫: NYLOKHR_eTraining
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
ALTER TABLE dbo.trTeacher ADD
	CompanyName nvarchar(200) NULL,
	ContactPerson nvarchar(50) NULL,
	ContactPhoneNumber nvarchar(50) NULL
GO
ALTER TABLE dbo.trTeacher SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.trTeacher', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.trTeacher', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.trTeacher', 'Object', 'CONTROL') as Contr_Per 