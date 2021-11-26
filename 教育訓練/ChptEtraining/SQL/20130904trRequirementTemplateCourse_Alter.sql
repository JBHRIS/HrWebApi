/*
   2013年9月4日下午 03:49:21
   使用者: jb
   伺服器: jb-vsts
   資料庫: CHPT_eTraining
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
ALTER TABLE dbo.trRequirementTemplateCourse ADD
	Budget int NOT NULL CONSTRAINT DF_trRequirementTemplateCourse_Budget DEFAULT 0
GO
ALTER TABLE dbo.trRequirementTemplateCourse SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.trRequirementTemplateCourse', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.trRequirementTemplateCourse', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.trRequirementTemplateCourse', 'Object', 'CONTROL') as Contr_Per 