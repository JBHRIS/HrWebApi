/*
   2013年9月18日上午 09:59:02
   使用者: jb
   伺服器: jb-vsts\sql2012
   資料庫: NYLOKHR
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
ALTER TABLE dbo.NotifyClass ADD
	NotifyDay int NULL
GO
ALTER TABLE dbo.NotifyClass SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
update NotifyClass set notifyday= (select top 1 notifyday from NotifyTemplate)
go
ALTER TABLE dbo.NotifyClass
alter column	NotifyDay int not NULL
go

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
ALTER TABLE dbo.NotifyClass ADD
	RelationApp nvarchar(50) NULL
GO
ALTER TABLE dbo.NotifyClass SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

INSERT dbo.NotifyClass VALUES ('ARCExpire', 'A', '居留證期滿通知', 'JBHR.BLL', 'JBHR.BLL.Sys.ARCExpireNotifyObject', '', '{Sponsor}{SponsorName}居留證期滿通知', '{Sponsor}{SponsorName}
將在{ExpireDate}居留證期滿', 'Auto', 0, '2017-06-21 15:09:35.490', '姚建彬', 0, NULL)
INSERT dbo.NotifyClass VALUES ('Birthday', 'A', '生日提醒', 'JBHR.BLL', 'JBHR.BLL.Sys.BirthdayNotifyObject', '', '', '', 'Auto', 0, '2017-06-21 15:09:35.487', '姚建彬', 0, NULL)
INSERT dbo.NotifyClass VALUES ('Contract', 'A', '合同到期通知', 'JBHR.BLL', 'JBHR.BLL.Sys.ContractNotifyObject', '', '{SponsorName}{Sponsor}將在{EventDate}合同期滿', '{SponsorName}{Sponsor}將在{EventDate}合同期滿', 'Auto', 0, '2017-06-21 15:09:35.490', '姚建彬', 0, NULL)
--INSERT dbo.NotifyClass VALUES ('ReinstateDate', 'A', '預計復職通知', 'JBHR.CustomBLL', 'JBHR.CustomBLL.Sys.ExpectReinstatementNotifyObject', '', '{Sponsor}預計於{EventDate}復職', '{SponsorName}{Sponsor}
--預計於{EventDate}復職', 'Auto', 0, '2017-06-21 15:09:35.493', '姚建彬', 0, NULL)
INSERT dbo.NotifyClass VALUES ('TrialExpire', 'A', '試用期滿通知', 'JBHR.BLL', 'JBHR.BLL.Sys.TrialExpireNotifyObject', '', '{SponsorName}{Sponsor}試用期滿通知', '{SponsorName}{Sponsor}
將在{ExpireDate}試用期滿', 'Auto', 0, '2017-06-21 15:09:35.490', '姚建彬', 0, NULL)
GO

update mtcode set display=1 where category='NotifyTarget'
go
