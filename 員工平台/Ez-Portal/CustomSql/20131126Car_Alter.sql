/*
   2013年11月26日下午 03:13:14
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
ALTER TABLE dbo.Car
	DROP CONSTRAINT DF_Car_EnableSchedueRent
GO
ALTER TABLE dbo.Car
	DROP CONSTRAINT DF_Car_CanRent
GO
CREATE TABLE dbo.Tmp_Car
	(
	Id int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL,
	CarId nvarchar(50) NOT NULL,
	LicensePlate nvarchar(50) NULL,
	EnableSchedueRent bit NOT NULL,
	CanRent bit NOT NULL,
	DispBackColor int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Car SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Car ADD CONSTRAINT
	DF_Car_EnableSchedueRent DEFAULT ((0)) FOR EnableSchedueRent
GO
ALTER TABLE dbo.Tmp_Car ADD CONSTRAINT
	DF_Car_CanRent DEFAULT ((1)) FOR CanRent
GO
SET IDENTITY_INSERT dbo.Tmp_Car ON
GO
IF EXISTS(SELECT * FROM dbo.Car)
	 EXEC('INSERT INTO dbo.Tmp_Car (Id, Name, CarId, LicensePlate, EnableSchedueRent, CanRent)
		SELECT Id, Name, CarId, LicensePlate, EnableSchedueRent, CanRent FROM dbo.Car WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Car OFF
GO
DROP TABLE dbo.Car
GO
EXECUTE sp_rename N'dbo.Tmp_Car', N'Car', 'OBJECT' 
GO
ALTER TABLE dbo.Car ADD CONSTRAINT
	PK_Car PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.Car', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Car', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Car', 'Object', 'CONTROL') as Contr_Per 