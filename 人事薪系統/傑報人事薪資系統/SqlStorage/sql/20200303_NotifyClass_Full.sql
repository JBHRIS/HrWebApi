/*
   2013�~9��18��W�� 09:59:02
   �ϥΪ�: jb
   ���A��: jb-vsts\sql2012
   ��Ʈw: NYLOKHR
   ���ε{��: 
*/

/* ���F�קK����i��o�͸�ƿ򥢪����D�A�z���ӥ��Բ��˵������O�X�A�M��~��b��Ʈw�]�p�u�����ҥH�~����m����C*/
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

INSERT dbo.NotifyClass VALUES ('ARCExpire', 'A', '�~�d�Ҵ����q��', 'JBHR.BLL', 'JBHR.BLL.Sys.ARCExpireNotifyObject', '', '{Sponsor}{SponsorName}�~�d�Ҵ����q��', '{Sponsor}{SponsorName}
�N�b{ExpireDate}�~�d�Ҵ���', 'Auto', 0, '2017-06-21 15:09:35.490', '���رl', 0, NULL)
INSERT dbo.NotifyClass VALUES ('Birthday', 'A', '�ͤ鴣��', 'JBHR.BLL', 'JBHR.BLL.Sys.BirthdayNotifyObject', '', '', '', 'Auto', 0, '2017-06-21 15:09:35.487', '���رl', 0, NULL)
INSERT dbo.NotifyClass VALUES ('Contract', 'A', '�X�P����q��', 'JBHR.BLL', 'JBHR.BLL.Sys.ContractNotifyObject', '', '{SponsorName}{Sponsor}�N�b{EventDate}�X�P����', '{SponsorName}{Sponsor}�N�b{EventDate}�X�P����', 'Auto', 0, '2017-06-21 15:09:35.490', '���رl', 0, NULL)
--INSERT dbo.NotifyClass VALUES ('ReinstateDate', 'A', '�w�p�_¾�q��', 'JBHR.CustomBLL', 'JBHR.CustomBLL.Sys.ExpectReinstatementNotifyObject', '', '{Sponsor}�w�p��{EventDate}�_¾', '{SponsorName}{Sponsor}
--�w�p��{EventDate}�_¾', 'Auto', 0, '2017-06-21 15:09:35.493', '���رl', 0, NULL)
INSERT dbo.NotifyClass VALUES ('TrialExpire', 'A', '�եδ����q��', 'JBHR.BLL', 'JBHR.BLL.Sys.TrialExpireNotifyObject', '', '{SponsorName}{Sponsor}�եδ����q��', '{SponsorName}{Sponsor}
�N�b{ExpireDate}�եδ���', 'Auto', 0, '2017-06-21 15:09:35.490', '���رl', 0, NULL)
GO

update mtcode set display=1 where category='NotifyTarget'
go
