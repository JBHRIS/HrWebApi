CREATE TABLE [dbo].[TemperoturyReport] (
    [EmployeeId]  NVARCHAR (50)    NOT NULL,
    [AttendDate]  DATETIME         NOT NULL,
    [ReportType]  NVARCHAR (50)    NOT NULL,
    [Temperotury] DECIMAL (16, 2)  NOT NULL,
    [Description] NVARCHAR (50)    NULL,
    [KeyDate]     DATETIME         NOT NULL,
    [KeyMan]      NVARCHAR (50)    NOT NULL,
    [AutoKey]     INT              IDENTITY (1, 1) NOT NULL,
    [Guid]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_TemperoturyReport] PRIMARY KEY CLUSTERED ([AutoKey] ASC)
);

