﻿CREATE TABLE [dbo].[BASETTS] (
    [NOBR]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_NOBR] DEFAULT ('') NOT NULL,
    [ADATE]         DATETIME        CONSTRAINT [DF_BASETTS_ADATE] DEFAULT (getdate()) NOT NULL,
    [TTSCODE]       NVARCHAR (50)   CONSTRAINT [DF_BASETTS_TTSCODE] DEFAULT ('') NOT NULL,
    [DDATE]         DATETIME        CONSTRAINT [DF_BASETTS_DDATE] DEFAULT (getdate()) NULL,
    [INDT]          DATETIME        CONSTRAINT [DF_BASETTS_INDT] DEFAULT (getdate()) NULL,
    [CINDT]         DATETIME        CONSTRAINT [DF_BASETTS_CINDT] DEFAULT (getdate()) NULL,
    [OUDT]          DATETIME        CONSTRAINT [DF_BASETTS_OUDT] DEFAULT (getdate()) NULL,
    [STDT]          DATETIME        CONSTRAINT [DF_BASETTS_STDT] DEFAULT (getdate()) NULL,
    [STINDT]        DATETIME        CONSTRAINT [DF_BASETTS_STINDT] DEFAULT (getdate()) NULL,
    [STOUDT]        DATETIME        CONSTRAINT [DF_BASETTS_STOUDT] DEFAULT (getdate()) NULL,
    [COMP]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_COMP] DEFAULT ('') NOT NULL,
    [DEPT]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_DEPT] DEFAULT ('') NOT NULL,
    [DEPTS]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_DEPTS] DEFAULT ('') NOT NULL,
    [JOB]           NVARCHAR (50)   CONSTRAINT [DF_BASETTS_JOB] DEFAULT ('') NOT NULL,
    [JOBL]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_JOBL] DEFAULT ('') NOT NULL,
    [CARD]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_CARD] DEFAULT ('') NOT NULL,
    [ROTET]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_ROTET] DEFAULT ('') NOT NULL,
    [DI]            NVARCHAR (50)   CONSTRAINT [DF_BASETTS_DI] DEFAULT ('') NOT NULL,
    [KEY_MAN]       NVARCHAR (50)   CONSTRAINT [DF_BASETTS_KEY_MAN] DEFAULT ('') NOT NULL,
    [KEY_DATE]      DATETIME        CONSTRAINT [DF_BASETTS_KEY_DATE] DEFAULT (getdate()) NOT NULL,
    [MANG]          BIT             CONSTRAINT [DF_BASETTS_MANG] DEFAULT ((0)) NOT NULL,
    [YR_DAYS]       DECIMAL (16, 2) CONSTRAINT [DF_BASETTS_YR_DAYS] DEFAULT ((0)) NOT NULL,
    [WK_YRS]        DECIMAL (16, 2) CONSTRAINT [DF_BASETTS_WK_YRS] DEFAULT ((0)) NOT NULL,
    [SALTP]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_SALTP] DEFAULT ('') NOT NULL,
    [JOBS]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_JOBS] DEFAULT ('') NOT NULL,
    [WORKCD]        NVARCHAR (50)   CONSTRAINT [DF_BASETTS_WORKCD] DEFAULT ('') NOT NULL,
    [CARCD]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_CARCD] DEFAULT ('') NOT NULL,
    [EMPCD]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_EMPCD] DEFAULT ('') NOT NULL,
    [OUTCD]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_OUTCD] DEFAULT ('') NOT NULL,
    [CALABS]        BIT             CONSTRAINT [DF_BASETTS_CALABS] DEFAULT ((0)) NOT NULL,
    [CALOT]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_CALOT] DEFAULT ('') NOT NULL,
    [FULATT]        BIT             CONSTRAINT [DF_BASETTS_FULATT] DEFAULT ((0)) NOT NULL,
    [NOTER]         BIT             CONSTRAINT [DF_BASETTS_NOTER] DEFAULT ((0)) NOT NULL,
    [NOWEL]         BIT             CONSTRAINT [DF_BASETTS_NOWEL] DEFAULT ((0)) NOT NULL,
    [NORET]         BIT             CONSTRAINT [DF_BASETTS_NORET] DEFAULT ((0)) NOT NULL,
    [NOTLATE]       BIT             CONSTRAINT [DF_BASETTS_NOTLATE] DEFAULT ((0)) NOT NULL,
    [HOLI_CODE]     NVARCHAR (50)   CONSTRAINT [DF_BASETTS_HOLI_CODE] DEFAULT ('') NOT NULL,
    [NOOT]          BIT             CONSTRAINT [DF_BASETTS_NOOT] DEFAULT ((0)) NOT NULL,
    [NOSPEC]        BIT             CONSTRAINT [DF_BASETTS_NOSPEC] DEFAULT ((0)) NOT NULL,
    [NOCARD]        BIT             CONSTRAINT [DF_BASETTS_NOCARD] DEFAULT ((0)) NOT NULL,
    [NOEAT]         BIT             CONSTRAINT [DF_BASETTS_NOEAT] DEFAULT ((0)) NOT NULL,
    [APGRPCD]       NVARCHAR (50)   CONSTRAINT [DF_BASETTS_APGRPCD] DEFAULT ('') NOT NULL,
    [DEPTM]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_DEPTM] DEFAULT ('') NOT NULL,
    [TTSCD]         NVARCHAR (50)   CONSTRAINT [DF_BASETTS_TTSCD] DEFAULT ('') NOT NULL,
    [MENO]          NVARCHAR (180)  CONSTRAINT [DF_BASETTS_MENO] DEFAULT ('') NOT NULL,
    [SALADR]        NVARCHAR (50)   CONSTRAINT [DF_BASETTS_SALADR] DEFAULT ('') NOT NULL,
    [NOWAGE]        BIT             CONSTRAINT [DF_BASETTS_NOWAGE] DEFAULT ((0)) NOT NULL,
    [MANGE]         BIT             CONSTRAINT [DF_BASETTS_MANGE] DEFAULT ((0)) NOT NULL,
    [RETRATE]       DECIMAL (16, 2) CONSTRAINT [DF_BASETTS_RETRATE] DEFAULT ((0)) NOT NULL,
    [RETDATE]       DATETIME        CONSTRAINT [DF_BASETTS_RETDATE] DEFAULT (getdate()) NULL,
    [RETCHOO]       NVARCHAR (50)   CONSTRAINT [DF_BASETTS_RETCHOO] DEFAULT ('') NOT NULL,
    [RETDATE1]      DATETIME        CONSTRAINT [DF_BASETTS_RETDATE1] DEFAULT (getdate()) NULL,
    [ONLYONTIME]    BIT             CONSTRAINT [DF_BASETTS_ONLYONTIME] DEFAULT ((0)) NOT NULL,
    [JOBO]          NVARCHAR (50)   CONSTRAINT [DF_BASETTS_JOBO] DEFAULT ('') NOT NULL,
    [COUNT_PASS]    BIT             CONSTRAINT [DF_BASETTS_COUNT_PASS] DEFAULT ((0)) NOT NULL,
    [PASS_DATE]     DATETIME        CONSTRAINT [DF_BASETTS_PASS_DATE] DEFAULT (getdate()) NULL,
    [MANG1]         BIT             CONSTRAINT [DF_BASETTS_MANG1] DEFAULT ((0)) NOT NULL,
    [AP_DATE]       DATETIME        CONSTRAINT [DF_BASETTS_AP_DATE] DEFAULT (getdate()) NULL,
    [GRP_AMT]       DECIMAL (16, 2) CONSTRAINT [DF_BASETTS_GRP_AMT] DEFAULT ((0)) NOT NULL,
    [TAX_DATE]      DATETIME        CONSTRAINT [DF_BASETTS_TAX_DATE] DEFAULT (getdate()) NULL,
    [NOSPAMT]       BIT             CONSTRAINT [DF_BASETTS_NOSPAMT] DEFAULT ((0)) NOT NULL,
    [FIXRATE]       BIT             CONSTRAINT [DF_BASETTS_FIXRATE] DEFAULT ((0)) NOT NULL,
    [TAX_EDATE]     DATETIME        CONSTRAINT [DF_BASETTS_TAX_EDATE] DEFAULT (getdate()) NULL,
    [IS_SELFOUT]    BIT             CONSTRAINT [DF_BASETTS_IS_SELFOUT] DEFAULT ((0)) NOT NULL,
    [INSG_TYPE]     NVARCHAR (50)   CONSTRAINT [DF_BASETTS_INSG_TYPE] DEFAULT ('') NOT NULL,
    [OldSaladr]     NVARCHAR (50)   NULL,
    [STATION]       NVARCHAR (50)   NULL,
    [CardJobName]   NVARCHAR (50)   NULL,
    [CardJobEnName] NVARCHAR (50)   NULL,
    [OilSubsidy]    NVARCHAR (50)   NULL,
    [CardID]        NVARCHAR (50)   NULL,
    [DoorGuard]     NVARCHAR (50)   NULL,
    [OutPost]       NVARCHAR (50)   NULL,
    [NOOLDRET]      BIT             CONSTRAINT [DF_BASETTS_NOOLDRET] DEFAULT ((0)) NOT NULL,
    [ReinstateDate] DATETIME        NULL,
    [PASS_TYPE]     NVARCHAR (50)   NULL,
    [AuditDate]     DATETIME        NULL,
    [AssessManage1] NVARCHAR (50)   NULL,
    [AssessManage2] NVARCHAR (50)   NULL,
    CONSTRAINT [PK_BASETTS_1] PRIMARY KEY CLUSTERED ([NOBR] ASC, [ADATE] ASC, [TTSCODE] ASC)
);




GO
create trigger [dbo].[BASETTS_Log_Trigger] 
on [dbo].[BASETTS]
after insert,update,delete
as
begin try
declare @Source nvarchar(50)
set @Source='BASETTS'
declare @InsertedXml xml
declare @DeletedXml xml
if(exists(select 1 from inserted))--Add
set @InsertedXml=(select * from inserted for xml raw)
if(exists(select 1 from deleted))--Add
set @DeletedXml=(select * from deleted for xml raw)
insert into TraceLog select @Source,@InsertedXml,@DeletedXml,GETDATE()
end try
begin catch
print(ERROR_MESSAGE() )
end catch