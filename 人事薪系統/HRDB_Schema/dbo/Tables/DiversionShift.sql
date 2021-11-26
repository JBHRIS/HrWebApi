CREATE TABLE [dbo].[DiversionShift] (
    [DiversionGroup]      NVARCHAR (50)    NOT NULL,
    [AttendDate]          DATETIME         NOT NULL,
    [DiversionAttendType] NVARCHAR (50)    NULL,
    [KeyDate]             DATETIME         NOT NULL,
    [KeyMan]              NVARCHAR (50)    NOT NULL,
    [AutoKey]             INT              IDENTITY (1, 1) NOT NULL,
    [Guid]                UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_DiversionShift] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

