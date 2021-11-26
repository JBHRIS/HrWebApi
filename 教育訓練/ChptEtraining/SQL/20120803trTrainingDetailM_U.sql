/*
   2012年8月3日上午 09:26:37
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
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_iStudentNum
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_bIsPublished
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_sMaterialSelector
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_iEstimateAMT
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_iActualAMT
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_bIsNeedClassRpt
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_iClassRptDateSpan
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_CourseType
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_bIsNeedStudentScore
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_iStudentScoreDateSpan
GO
ALTER TABLE dbo.trTrainingDetailM
	DROP CONSTRAINT DF_trTrainingDetailM_IsTeacherFinishClassScore
GO
CREATE TABLE dbo.Tmp_trTrainingDetailM
	(
	iAutoKey int NOT NULL IDENTITY (1, 1),
	iYear int NULL,
	dDateTimeA datetime NULL,
	dDateTimeD datetime NULL,
	dDateA datetime NULL,
	dDateD datetime NULL,
	sTimeA nvarchar(50) NULL,
	sTimeD nvarchar(50) NULL,
	iSession int NULL,
	trCourse_sCode nvarchar(50) NOT NULL,
	sKey nvarchar(50) NOT NULL,
	sCourseGoal nvarchar(2000) NULL,
	sCourseSummary nvarchar(2000) NULL,
	trTeacher_sCode nvarchar(50) NULL,
	trClassroom_sCode nvarchar(50) NULL,
	bWebJoin bit NULL,
	dWebJoinDateB datetime NULL,
	dWebJoinDateE datetime NULL,
	sKeyMan nvarchar(50) NULL,
	dKeyDate datetime NULL,
	iUpLimitP int NULL,
	iLowLimitP int NULL,
	iStudentNum int NULL,
	bIsPublished bit NOT NULL,
	iYearPlanAutoKey int NULL,
	sMaterialSelector nvarchar(10) NOT NULL,
	iMaterialAutoKey int NULL,
	sMaterialKeyMan nvarchar(50) NULL,
	dMaterialKeyDate datetime NULL,
	iEstimateAMT int NOT NULL,
	iActualAMT int NOT NULL,
	iCourseTime int NULL,
	iJobScore int NULL,
	dExpiryDate datetime NULL,
	trTrainingMethod_sCode nvarchar(50) NULL,
	trTeacherType_sCode nvarchar(50) NULL,
	bIsNeedClassRpt bit NOT NULL,
	iClassRptDateSpan int NOT NULL,
	dClassRptDeadline datetime NULL,
	CourseType nvarchar(50) NULL,
	bIsNeedStudentScore bit NOT NULL,
	iStudentScoreDateSpan int NOT NULL,
	dStudentScoreDeadline datetime NULL,
	IsTeacherFinishClassScore bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_iStudentNum DEFAULT ((0)) FOR iStudentNum
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_bIsPublished DEFAULT ((0)) FOR bIsPublished
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_sMaterialSelector DEFAULT (N'N') FOR sMaterialSelector
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_iEstimateAMT DEFAULT ((0)) FOR iEstimateAMT
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_iActualAMT DEFAULT ((0)) FOR iActualAMT
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_bIsNeedClassRpt DEFAULT ((0)) FOR bIsNeedClassRpt
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_iClassRptDateSpan DEFAULT ((0)) FOR iClassRptDateSpan
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_CourseType DEFAULT (N'OTHERS') FOR CourseType
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_bIsNeedStudentScore DEFAULT ((0)) FOR bIsNeedStudentScore
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_iStudentScoreDateSpan DEFAULT ((0)) FOR iStudentScoreDateSpan
GO
ALTER TABLE dbo.Tmp_trTrainingDetailM ADD CONSTRAINT
	DF_trTrainingDetailM_IsTeacherFinishClassScore DEFAULT ((0)) FOR IsTeacherFinishClassScore
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingDetailM ON
GO
IF EXISTS(SELECT * FROM dbo.trTrainingDetailM)
	 EXEC('INSERT INTO dbo.Tmp_trTrainingDetailM (iAutoKey, iYear, dDateTimeA, dDateTimeD, dDateA, dDateD, sTimeA, sTimeD, iSession, trCourse_sCode, sKey, sCourseGoal, sCourseSummary, trTeacher_sCode, trClassroom_sCode, bWebJoin, dWebJoinDateB, dWebJoinDateE, sKeyMan, dKeyDate, iUpLimitP, iLowLimitP, iStudentNum, bIsPublished, iYearPlanAutoKey, sMaterialSelector, iMaterialAutoKey, sMaterialKeyMan, dMaterialKeyDate, iEstimateAMT, iActualAMT, iCourseTime, iJobScore, dExpiryDate, trTrainingMethod_sCode, trTeacherType_sCode, bIsNeedClassRpt, iClassRptDateSpan, dClassRptDeadline, CourseType, bIsNeedStudentScore, iStudentScoreDateSpan, dStudentScoreDeadline, IsTeacherFinishClassScore)
		SELECT iAutoKey, iYear, dDateTimeA, dDateTimeD, dDateA, dDateD, sTimeA, sTimeD, iSession, trCourse_sCode, sKey, sCourseGoal, sCourseSummary, trTeacher_sCode, trClassroom_sCode, bWebJoin, dWebJoinDateB, dWebJoinDateE, sKeyMan, dKeyDate, iUpLimitP, iLowLimitP, iStudentNum, bIsPublished, iYearPlanAutoKey, sMaterialSelector, iMaterialAutoKey, sMaterialKeyMan, dMaterialKeyDate, iEstimateAMT, iActualAMT, iCourseTime, iJobScore, dExpiryDate, trTrainingMethod_sCode, trTeacherType_sCode, bIsNeedClassRpt, iClassRptDateSpan, dClassRptDeadline, CourseType, bIsNeedStudentScore, iStudentScoreDateSpan, dStudentScoreDeadline, IsTeacherFinishClassScore FROM dbo.trTrainingDetailM WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_trTrainingDetailM OFF
GO
DROP TABLE dbo.trTrainingDetailM
GO
EXECUTE sp_rename N'dbo.Tmp_trTrainingDetailM', N'trTrainingDetailM', 'OBJECT' 
GO
ALTER TABLE dbo.trTrainingDetailM ADD CONSTRAINT
	PK_trTrainingDetailM PRIMARY KEY CLUSTERED 
	(
	iAutoKey
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
