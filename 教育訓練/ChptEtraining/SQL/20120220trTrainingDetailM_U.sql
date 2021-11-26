/*
   2012年2月20日上午 11:35:55
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
ALTER TABLE dbo.trTrainingDetailM ADD
	CourseType nvarchar(50) NOT NULL CONSTRAINT DF_trTrainingDetailM_CourseType DEFAULT N'OTHERS',
	bIsNeedStudentScore bit NOT NULL CONSTRAINT DF_trTrainingDetailM_bIsNeedStudentScore DEFAULT 0,
	iStudentScoreDateSpan int NOT NULL CONSTRAINT DF_trTrainingDetailM_iStudentScoreDateSpan DEFAULT 0,
	dStudentScoreDeadline datetime NULL
GO
ALTER TABLE dbo.trTrainingDetailM SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
