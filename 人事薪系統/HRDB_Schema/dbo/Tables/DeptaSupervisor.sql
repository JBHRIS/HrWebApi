CREATE TABLE [dbo].[DeptaSupervisor] (
    [AutoKey]        INT           IDENTITY (1, 1) NOT NULL,
    [D_No]           NVARCHAR (50) NOT NULL,
    [SupervisorNobr] NVARCHAR (50) NOT NULL,
    [AddOrDel]       BIT           CONSTRAINT [DF_DeptaSupervisor_AddOrDel] DEFAULT ((1)) NOT NULL,
    [KeyMan]         NVARCHAR (50) NULL,
    [KeyDate]        DATETIME      NULL,
    CONSTRAINT [PK_DeptaSupervisor] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

