CREATE TABLE [dbo].[DiversionGroup] (
    [EmployeeId]         NVARCHAR (50)    NOT NULL,
    [BeginDate]          DATETIME         NOT NULL,
    [EndDate]            DATETIME         NOT NULL,
    [DiversionGroupType] NVARCHAR (50)    NOT NULL,
    [WorkLocation]       NVARCHAR (50)    NOT NULL,
    [KeyDate]            DATETIME         NOT NULL,
    [KeyMan]             NVARCHAR (50)    NOT NULL,
    [AutoKey]            INT              IDENTITY (1, 1) NOT NULL,
    [Guid]               UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_DiversionGroup] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

