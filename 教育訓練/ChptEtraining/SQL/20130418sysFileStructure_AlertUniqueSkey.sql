/*
   2013年4月18日上午 09:48:58
   使用者: jb
   伺服器: jb-vsts
   資料庫: Formosa_eTraining
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
DROP INDEX IX_sysFileStructure ON dbo.sysFileStructure
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_sysFileStructure_1 ON dbo.sysFileStructure
	(
	sKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.sysFileStructure SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.sysFileStructure', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.sysFileStructure', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.sysFileStructure', 'Object', 'CONTROL') as Contr_Per 